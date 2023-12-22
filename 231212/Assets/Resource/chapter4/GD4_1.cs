using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro�� ����ϱ� ���� �ʿ�!

public class GD4_1 : MonoBehaviour
{
    public GameObject car; // ���� ������Ʈ�� ���� ����
    public GameObject flag; // ��� ������Ʈ�� ���� ����
    public GameObject distance; // �Ÿ��� ǥ���� �ؽ�Ʈ�� ���� ����
    float flagPosX;

    void Start()
    {
        // ���� ���� �� ������ ���� ������Ʈ�� ã�� ����
        this.car = GameObject.Find("car"); // ���̾��Ű�� "�����ִ�" ������Ʈ�� �� �̸����� ã�� ���
        this.flag = GameObject.Find("flag"); // ó���� �ѳ��� ������ �ҷ����� ������ ���� �������� ������ �ʰ� �� �� ����
        this.distance = GameObject.Find("Distance");
        // GameObject.FindObjectsOfType
        // Find�� ���� ������ �����Ƿ� �ʿ��� ����� ��� ����ϸ� ��

        flagPosX = this.flag.transform.position.x;
    }

    void Update()
    {
        // ��߰� ���� ������ �Ÿ� ���
        float length = flagPosX - this.car.transform.position.x; // flag�� car�� ��ǥ���� �޾ƿ� ���� ����, ����� �� ������ ��ġ ���� �ʿ���� ��ŸƮ���� �ѹ��� ����ָ� ��

        // �Ÿ��� �Ҽ��� 2�ڸ����� �����Ͽ� �Ÿ� �ؽ�Ʈ ������Ʈ
        this.distance.GetComponent<TextMeshProUGUI>().text = "Distance:" + length.ToString("F2") + "m";
        // GetComponent<TextMeshProUGUI>().text �Ұ�ȣ �������� �ȵ�
        //length.ToString("F2") == �Ҽ��� 2°�ڸ����� ǥ��. ���� �پ��ϴ� ToString ã�ƺ� ��
    }
}