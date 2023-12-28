using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ChatManager : MonoBehaviour
{
    public GameObject YellowArea, WhiteArea, SystemArea, WhiteArea1, Choice1, Choice2, Choice3, Choice4;
    public RectTransform ContentRect;
    public Scrollbar scrollBar;
    public Toggle MineToggle;
    AreaScript Area;
    CSVChatEditor csvChatEditor;
    int CurBG, LastBG;
    GameObject BG0, BG1, BG2, BG3, BG4, BG5;

    private void Start()
    {
        csvChatEditor = GameObject.Find("ChatEditor").GetComponent<CSVChatEditor>();
        BG0 = GameObject.Find("BG0");
        BG1 = GameObject.Find("BG1");
        BG2 = GameObject.Find("BG2");
        BG3 = GameObject.Find("BG2");
        BG4 = GameObject.Find("BG4");
        BG5 = GameObject.Find("BG5");
        BG1.SetActive(false);
        BG2.SetActive(false);
        BG3.SetActive(false);
        BG4.SetActive(false);
        BG5.SetActive(false);
    }

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
        else if (chr == "4")
        {
            Area = Instantiate(Choice1).GetComponent<AreaScript>();
            Debug.Log("Choice1");
        }
        else if (chr == "5")
        {
            Area = Instantiate(Choice2).GetComponent<AreaScript>();
            Debug.Log("Choice2");
        }
        else if (chr == "6")
        {
            Area = Instantiate(Choice3).GetComponent<AreaScript>();
            Debug.Log("Choice3");
        }
        else if (chr == "7")
        {
            Area = Instantiate(Choice4).GetComponent<AreaScript>();
            Debug.Log("Choice4");
        }
        else
        {
            chr = "System";
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


        Fit(Area.BoxRect);
        Fit(Area.AreaRect);

        Fit(ContentRect);

        if (chr == "4")
        {
            Button btn1 = GameObject.Find("Choice1Box").GetComponent<Button>();
            btn1.onClick.AddListener(csvChatEditor.Choice1);
        }
        else if (chr == "5")
        {
            Button btn2 = GameObject.Find("Choice2Box").GetComponent<Button>();
            btn2.onClick.AddListener(csvChatEditor.Choice2);
        }
        else if (chr == "6")
        {
            Button btn1 = GameObject.Find("Choice3Box").GetComponent<Button>();
            btn1.onClick.AddListener(csvChatEditor.Choice3);
        }
        else if (chr == "7")
        {
            Button btn2 = GameObject.Find("Choice4Box").GetComponent<Button>();
            btn2.onClick.AddListener(csvChatEditor.Choice4);
        }

        CurBG = bgID;
        if (CurBG != LastBG)
        {
            if (CurBG == 1)
            {
                BG0.SetActive(false);
                BG1.SetActive(true);
            }
            if (CurBG == 2)
            {
                BG1.SetActive(false);
                BG2.SetActive(true);
            }
            if (CurBG == 3)
            {
                BG2.SetActive(false);
                BG3.SetActive(true);
            }
            if (CurBG == 4)
            {
                BG1.SetActive(false);
                BG3.SetActive(false);
                BG4.SetActive(true);
            }
            if (CurBG == 5)
            {
                BG1.SetActive(false);
                BG5.SetActive(true);
            }
        }
        LastBG = CurBG;

        // 스크롤바 내림
        Invoke("ScrollDelay", 0.03f);

    }


    void Fit(RectTransform Rect) => LayoutRebuilder.ForceRebuildLayoutImmediate(Rect);


    void ScrollDelay() => scrollBar.value = 0;

}
