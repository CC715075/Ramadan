//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor; // Editor 쓰려면 필요

//[CustomEditor(typeof(ChatManager))]
//public class ChatEditor : Editor
//{
//    ChatManager chatManager;
//    public string text, chr, time;
//    public int ID = 0, BGID, nextID;


//    void OnEnable()
//    {
//        chatManager = target as ChatManager;
//    }


//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();

//        EditorGUILayout.BeginHorizontal();
//        text = EditorGUILayout.TextArea(text);

//        if (GUILayout.Button("보내기", GUILayout.Width(60)) && text.Trim() != "")
//        {
//            chatManager.Chat(0, 0, "주인공", text, "00000000000");
//            text = "";
//            GUI.FocusControl(null);
//        }

//        if (GUILayout.Button("받기", GUILayout.Width(60)) && text.Trim() != "")
//        {
//            chatManager.Chat(0, 0, "상대방", text, "00000000000");
//            text = "";
//            GUI.FocusControl(null);
//        }

//        if (GUILayout.Button("시스템", GUILayout.Width(60)) && text.Trim() != "")
//        {
//            chatManager.Chat(0, 0, "시스템", text, "00000000000");
//            text = "";
//            GUI.FocusControl(null);
//        }

//        EditorGUILayout.EndHorizontal();
//    }

//    public void CSVChat()
//    {
//        //CSV 데이터 변수에 저장하기
//        text = (string)DataManager.Instance.dataJWS[ID]["Dialog"];
//        chr = (string)DataManager.Instance.dataJWS[ID]["Chr"];
//        time = (string)DataManager.Instance.dataJWS[ID]["Time"];
//        BGID = (int)DataManager.Instance.dataJWS[ID]["BGID"];

//        chatManager.Chat(ID, BGID, chr, text, time);
//        text = "";
//        GUI.FocusControl(null);

//        if ((int) DataManager.Instance.dataJWS[ID]["NextID"] == -1)
//        {
//            ID++;
//        }
//        else
//        {
//            ID = (int)DataManager.Instance.dataJWS[ID]["NextID"];
//        }
//    }
//}