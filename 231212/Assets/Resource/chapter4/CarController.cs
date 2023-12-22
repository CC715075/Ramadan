using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // ���������� ���̸� ���Ѵ�
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺�� Ŭ���� ��ǥ
            this.startPos = Input.mousePosition; //���� ��ǥ�� �޾ƿ�(3D ��ǥ���� 2D�� �ٷ� ��� ����)
            Debug.Log(startPos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ���콺�� ������ �� ��ǥ
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;
            Debug.Log(endPos);

            // �������� ���̸� ó�� �ӵ��� ��ȯ�Ѵ�
            this.speed = swipeLength / 500.0f;
        }


        transform.Translate(this.speed, 0, 0);  // �̵�
        this.speed *= 0.98f;                    // ����
    }
}
