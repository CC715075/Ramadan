//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor; // Editor ������ �ʿ�

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

//        if (GUILayout.Button("������", GUILayout.Width(60)) && text.Trim() != "")
//        {
//            chatManager.Chat(0, 0, "���ΰ�", text, "00000000000");
//            text = "";
//            GUI.FocusControl(null);
//        }

//        if (GUILayout.Button("�ޱ�", GUILayout.Width(60)) && text.Trim() != "")
//        {
//            chatManager.Chat(0, 0, "����", text, "00000000000");
//            text = "";
//            GUI.FocusControl(null);
//        }

//        if (GUILayout.Button("�ý���", GUILayout.Width(60)) && text.Trim() != "")
//        {
//            chatManager.Chat(0, 0, "�ý���", text, "00000000000");
//            text = "";
//            GUI.FocusControl(null);
//        }

//        EditorGUILayout.EndHorizontal();
//    }

//    public void CSVChat()
//    {
//        //CSV ������ ������ �����ϱ�
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