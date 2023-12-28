using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSVChatEditor : MonoBehaviour
{
    ChatManager chatManager;
    public string chr, text, time;
    public int ID = 0, BGID, nextID;
    public GameObject nextButton, finButton;

    private void Start()
    {
        chatManager = GameObject.Find("ChatManager").GetComponent<ChatManager>();
        finButton = GameObject.Find("FinButton");
        finButton.SetActive(false);
    }

    public void CSVChat()
    {
        //CSV 데이터 변수에 저장하기
        chr = (string)DataManager.Instance.dataJWS[ID]["CHARACTER"].ToString();
        text = (string)DataManager.Instance.dataJWS[ID]["TEXT"];
        BGID = (int)DataManager.Instance.dataJWS[ID]["BGID"];
        nextID = (int)DataManager.Instance.dataJWS[ID]["NEXT"];

        chatManager.Chat(chr, text, BGID);
        text = "";
        //GUI.FocusControl(null);
        Debug.Log(ID);
        if (chr == "8")
        {
            chatManager.Chat("4", "▶ 동의한다", BGID);
            text = "";
            //GUI.FocusControl(null);
            chatManager.Chat("5", "▶ 거절한다", BGID);
            text = "";
            GUI.FocusControl(null);
            Debug.Log("선택지1");
        }
        else if (chr == "9")
        {
            chatManager.Chat("6", "▶ 01구역으로 이동", BGID);
            text = "";
            //GUI.FocusControl(null);
            chatManager.Chat("7", "▶ 바깥으로 우회", BGID);
            text = "";
            GUI.FocusControl(null);
            Debug.Log("선택지2");
        }

        if (nextID == -1)
        {
            ID++;
        }
        else if (nextID == 1)
        {
            nextButton = GameObject.Find("NextButton");
            nextButton.SetActive(false);
        }
        else if (nextID == 2)
        {
            nextButton = GameObject.Find("NextButton");
            nextButton.SetActive(false);
            finButton.SetActive(true);
        }
    }

    public void Choice1()
    {
        ID = 59;
        GameObject.Find("Choice1(Clone)").SetActive(false);
        GameObject.Find("Choice2(Clone)").SetActive(false);
        chatManager.Chat("1", "▶ 동의한다", BGID);
        nextButton.SetActive(true);
    }
    public void Choice2()
    {
        ID = 148;
        GameObject.Find("Choice1(Clone)").SetActive(false);
        GameObject.Find("Choice2(Clone)").SetActive(false);
        chatManager.Chat("1", "▶ 거절한다", BGID);
        nextButton.SetActive(true);
    }
    public void Choice3()
    {
        ID = 70;
        GameObject.Find("Choice3(Clone)").SetActive(false);
        GameObject.Find("Choice4(Clone)").SetActive(false);
        chatManager.Chat("1", "▶ 01구역으로 이동", BGID);
        nextButton.SetActive(true);
    }
    public void Choice4()
    {
        ID = 123;
        GameObject.Find("Choice3(Clone)").SetActive(false);
        GameObject.Find("Choice4(Clone)").SetActive(false);
        chatManager.Chat("1", "▶ 바깥으로 우회", BGID);
        nextButton.SetActive(true);
    }
}
