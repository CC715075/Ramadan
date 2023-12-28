using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVChatEditor : MonoBehaviour
{
    ChatManager chatManager;
    public string chr, text, time;
    public int ID = 0, BGID, nextID;

    private void Start()
    {
        chatManager = GameObject.Find("ChatManager").GetComponent<ChatManager>();
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
        GUI.FocusControl(null);

        if (nextID == -1)
        {
            ID++;
        }
        else if (nextID == 1)
        {
            ID = nextID;
        }
    }

    public void Choice1()
    {
        ID = 59;
    }
    public void Choice2()
    {
        ID = 148;
    }
    public void Choice3()
    {
        ID = 70;
    }
    public void Choice4()
    {
        ID = 123;
    }
}
