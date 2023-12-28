using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ChatManager : MonoBehaviour
{
    public GameObject YellowArea, WhiteArea, SystemArea, WhiteArea1;
    public RectTransform ContentRect;
    public Scrollbar scrollBar;
    public Toggle MineToggle;
    AreaScript LastArea;
    AreaScript Area;
    Texture2D picture;


    public void ReceiveMessage(string text)
    {
        if (MineToggle.isOn) Chat("주인공", text, 0);
        else Chat("상대방", text, 0);
    }


    public void LayoutVisible(bool b)
    {
        AndroidJavaClass kotlin = new AndroidJavaClass("com.unity3d.player.SubActivity");
        kotlin.CallStatic("LayoutVisible", b);
    }


    public void Chat(string chr, string text, int bgID)
    {
        if (text.Trim() == "") return;

        // bool isBottom = scrollBar.value <= 0.00001f;


        //보내는 사람은 노랑, 받는 사람은 흰색영역을 크게 만들고 텍스트 대입
        if (chr == "1")
        {
            chr = "System";
            Area = Instantiate(SystemArea).GetComponent<AreaScript>();
        }
        else if (chr == "0")
        {
            chr = "NAVI747651C9";
            Area = Instantiate(YellowArea).GetComponent<AreaScript>();
        }
        else if (chr == "2")
        {
            chr = "관리자";
            Area = Instantiate(WhiteArea).GetComponent<AreaScript>();
        }
        else if (chr == "3")
        {
            chr = "병사A";
            Area = Instantiate(WhiteArea1).GetComponent<AreaScript>();
        }
        else
        {
            Area = Instantiate(SystemArea).GetComponent<AreaScript>();
        }

        Area.transform.SetParent(ContentRect.transform, false);
        Area.BoxRect.sizeDelta = new Vector2(600, Area.BoxRect.sizeDelta.y);
        Area.TextRect.GetComponent<TextMeshProUGUI>().text = text;
        Fit(Area.BoxRect);


        // 두 줄 이상이면 크기를 줄여가면서, 한 줄이 아래로 내려가면 바로 전 크기를 대입 
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


        // 현재 것에 유저이름 대입
        Area.User = chr;
        Area.UserText.text = chr;


        //// 이전 것과 같으면 이전 시간, 꼬리 없애기
        //bool isSame = LastArea != null && LastArea.Time == Area.Time && LastArea.User == Area.User;
        //if (isSame) LastArea.TimeText.text = "";
        //Area.Tail.SetActive(!isSame);


        //// 타인이 이전 것과 같으면 이미지, 이름 없애기
        //if (LastChr != chr)
        //{
        //    Area.UserImage.gameObject.SetActive(!isSame);
        //    Area.UserText.gameObject.SetActive(!isSame);
        //    Area.UserText.text = Area.User;
        //    if (chr == "상대방" && picture != null)
        //    {
        //        Area.UserImage.sprite = Sprite.Create(picture, new Rect(0, 0, picture.width, picture.height), new Vector2(0.5f, 0.5f));
        //    }
        //}


        Fit(Area.BoxRect);
        Fit(Area.AreaRect);
        Fit(ContentRect);
        LastArea = Area;

        // 스크롤바 내림
        Invoke("ScrollDelay", 0.03f);

    }


    void Fit(RectTransform Rect) => LayoutRebuilder.ForceRebuildLayoutImmediate(Rect);


    void ScrollDelay() => scrollBar.value = 0;

}
