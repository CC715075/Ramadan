using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;  // 회전 속도   

    void Start()
    {
        // 프레임레이트를 60으로 고정한다
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // 클릭하면 회전 속도를 설정한다
        if (Input.GetMouseButton(0)) //마우스가 눌려있는지(터치 1)를 감지 //업데이트 안에 있어서 매함 프레임 검사
        // Input.GetMouseButtonDown(1); 한번 눌렀는지
        {
            this.rotSpeed = 10;
        }

        // 회전 속도만큼 룰렛을 회전시킨다
        transform.Rotate(0, 0, this.rotSpeed);

        // 룰렛을 감속시킨다
        if (rotSpeed < 0.1f)
        {
            rotSpeed = 0;
        }
        else
        {
        rotSpeed *= 0.96f;
        }
    }
}
