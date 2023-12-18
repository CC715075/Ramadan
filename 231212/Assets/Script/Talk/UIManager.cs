using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�� �����ϱ� ���ؼ� �ʿ�
using TMPro; // �ؽ�Ʈ�޽����� ������ ���� �ҷ��;� ��

public class UIManager : MonoBehaviour
{
    // ��ƴ� ������ ���� ���� ���ϸ� global�� ���, ������ �տ� local �Է�����
    // ����Ƽ�� public�� �ٿ���� �������� ��� ����
    [HideInInspector] // �ۺ��� ������Ʈ���� ����� ����, �����ݷи��� �տ� �ٿ���� ��
    public int testValue = 1;
    // [HideInInspector] public int testValue = 1; //�� �ȹٲ㵵 ����
    public Image bg1;

    [SerializeField] // ������Ʈ���� ǥ�õ�
    Color _color;
    bool isChanged;

    [SerializeField]
    Sprite uiBg0; // �⺻ �̹���
    [SerializeField]
    Sprite uiBg1; // �ٲ� �̹���

    public TextMeshProUGUI _uitext0;

    private void Start()
    {
        Debug.Log(testValue);
        _color = bg1.color;
        uiBg0 = bg1.sprite;
    }
    
    public void ChangeColor()
    {
        if (!isChanged)
        {
            // bg1.color = Color.cyan;
            // new Color(0.5, 0.5, 0.5, 0.5); //255�� 0-1 ������ ���� ȯ���ؼ� �־���� ��
            bg1.sprite = uiBg1;
            _uitext0.text = "isChanged";
            isChanged = !isChanged;
        }
        else
        {
            //bg1.color = _color;
            bg1.sprite = uiBg0;
            _uitext0.text = "!isChanged";
            isChanged = !isChanged;
        }
    }

}
