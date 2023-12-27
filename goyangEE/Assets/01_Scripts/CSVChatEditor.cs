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
        chr = (string)DataManager.Instance.dataJWS[ID]["Chr"];
        text = (string)DataManager.Instance.dataJWS[ID]["Dialog"];
        time = DataManager.Instance.dataJWS[ID]["Time"].ToString();
        BGID = (int)DataManager.Instance.dataJWS[ID]["BGID"];

        chatManager.Chat(chr, text, time);
        text = "";
        GUI.FocusControl(null);

        if ((int)DataManager.Instance.dataJWS[ID]["NextID"] == -1)
        {
            ID++;
        }
        else
        {
            ID = (int)DataManager.Instance.dataJWS[ID]["NextID"];
        }
    }
}
