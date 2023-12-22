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
        // 스와이프의 길이를 구한다
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스를 클릭한 좌표
            this.startPos = Input.mousePosition; //누른 좌표를 받아옴(3D 좌표지만 2D로 바로 사용 가능)
            Debug.Log(startPos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 마우스를 떼었을 때 좌표
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;
            Debug.Log(endPos);

            // 스와이프 길이를 처음 속도로 변환한다
            this.speed = swipeLength / 500.0f;
        }


        transform.Translate(this.speed, 0, 0);  // 이동
        this.speed *= 0.98f;                    // 감속
    }
}
