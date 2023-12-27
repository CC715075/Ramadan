using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;



public class ChatManager : MonoBehaviour
{
    public GameObject YellowArea, WhiteArea, SystemArea;
    public RectTransform ContentRect;
    public Scrollbar scrollBar;
    public Toggle MineToggle;
    AreaScript LastArea;
    AreaScript Area;
    string LastChr;
    Texture2D picture;


    public void ReceiveMessage(string text)
    {
        if (MineToggle.isOn) Chat("���ΰ�", text, "00000000000");
        else Chat("����", text, "00000000000");
    }


    public void LayoutVisible(bool b)
    {
        AndroidJavaClass kotlin = new AndroidJavaClass("com.unity3d.player.SubActivity");
        kotlin.CallStatic("LayoutVisible", b);
    }


    public void Chat(string chr, string text, string time)
    {
        if (text.Trim() == "") return;

        // bool isBottom = scrollBar.value <= 0.00001f;


        //������ ����� ���, �޴� ����� ��������� ũ�� ����� �ؽ�Ʈ ����
        if (chr == "�ý���")
        {
            //Area = Instantiate(SystemArea).GetComponent<AreaScript>();
        }
        else if (chr == "���ΰ�")
        {
            Area = Instantiate(YellowArea).GetComponent<AreaScript>();
        }
        else
        {
            Area = Instantiate(WhiteArea).GetComponent<AreaScript>();
            //picture = �̹������
        }

        Area.transform.SetParent(ContentRect.transform, false);
        Area.BoxRect.sizeDelta = new Vector2(600, Area.BoxRect.sizeDelta.y);
        Area.TextRect.GetComponent<TextMeshProUGUI>().text = text;
        Fit(Area.BoxRect);


        // �� �� �̻��̸� ũ�⸦ �ٿ����鼭, �� ���� �Ʒ��� �������� �ٷ� �� ũ�⸦ ���� 
        float X = Area.TextRect.sizeDelta.x + 42;
        float Y = Area.TextRect.sizeDelta.y;
        if (Y > 49)
        {
            for (int i = 0; i < 200; i++)
            {
                Area.BoxRect.sizeDelta = new Vector2(X - i * 2, Area.BoxRect.sizeDelta.y);
                Fit(Area.BoxRect);

                if (Y != Area.TextRect.sizeDelta.y) { Area.BoxRect.sizeDelta = new Vector2(X - (i * 2) + 2, Y); break; }
            }
        }
        else Area.BoxRect.sizeDelta = new Vector2(X, Y);


        // ���� �Ϳ� �ð��� �����̸� ����
        Area.Time = time;
        Area.User = chr;
        Area.UserText.text = chr;


        //// ���� �Ͱ� ������ ���� �ð�, ���� ���ֱ�
        //bool isSame = LastArea != null && LastArea.Time == Area.Time && LastArea.User == Area.User;
        //if (isSame) LastArea.TimeText.text = "";
        //Area.Tail.SetActive(!isSame);


        //// Ÿ���� ���� �Ͱ� ������ �̹���, �̸� ���ֱ�
        //if (LastChr != chr)
        //{
        //    Area.UserImage.gameObject.SetActive(!isSame);
        //    Area.UserText.gameObject.SetActive(!isSame);
        //    Area.UserText.text = Area.User;
        //    if (chr == "����" && picture != null)
        //    {
        //        Area.UserImage.sprite = Sprite.Create(picture, new Rect(0, 0, picture.width, picture.height), new Vector2(0.5f, 0.5f));
        //    }
        //}


        // ���� �Ͱ� ��¥�� �ٸ��� ��¥���� ���̱�
        if (LastArea != null && LastArea.Time != Area.Time)
        {
            Transform CurDateArea = Instantiate(SystemArea).transform;
            CurDateArea.SetParent(ContentRect.transform, false);
            CurDateArea.SetSiblingIndex(CurDateArea.GetSiblingIndex() - 1);
        }

        //���������� ���� ĳ���� ���
        LastChr = chr;

        Fit(Area.BoxRect);
        Fit(Area.AreaRect);
        Fit(ContentRect);
        LastArea = Area;

        // ��ũ�ѹ� ����
        Invoke("ScrollDelay", 0.03f);

    }


    void Fit(RectTransform Rect) => LayoutRebuilder.ForceRebuildLayoutImmediate(Rect);


    void ScrollDelay() => scrollBar.value = 0;

}
