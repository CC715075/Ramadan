using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; // Editor ������ �ʿ�

[CustomEditor(typeof(ChatManager))]
public class ChatEditor : Editor
{
    ChatManager chatManager;
    string text;


    void OnEnable()
    {
        chatManager = target as ChatManager;
    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.BeginHorizontal();
        text = EditorGUILayout.TextArea(text);

        if (GUILayout.Button("������", GUILayout.Width(60)) && text.Trim() != "")
        {
            chatManager.Chat(true, text, "��", null);
            text = "";
            GUI.FocusControl(null);
        }

        if (GUILayout.Button("�ޱ�", GUILayout.Width(60)) && text.Trim() != "")
        {
            chatManager.Chat(false, text, "Ÿ��", null);
            text = "";
            GUI.FocusControl(null);
        }

        if (GUILayout.Button("�ý���", GUILayout.Width(60)) && text.Trim() != "")
        {
            chatManager.Chat(false, text, "�ý���", null);
            text = "";
            GUI.FocusControl(null);
        }

        EditorGUILayout.EndHorizontal();
    }

}