using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro를 사용하기 위해 필요!

public class GD4_1 : MonoBehaviour
{
    public GameObject car; // 차량 오브젝트에 대한 참조
    public GameObject flag; // 깃발 오브젝트에 대한 참조
    public GameObject distance; // 거리를 표시할 텍스트에 대한 참조
    float flagPosX;

    void Start()
    {
        // 게임 시작 시 각각의 게임 오브젝트를 찾아 참조
        this.car = GameObject.Find("car"); // 하이어라키에 "켜져있는" 오브젝트들 중 이름으로 찾는 방법
        this.flag = GameObject.Find("flag"); // 처음엔 켜놔서 정보를 불러오고 다음엔 꺼서 유저에게 보이지 않게 할 수 있음
        this.distance = GameObject.Find("Distance");
        // GameObject.FindObjectsOfType
        // Find엔 여러 종류가 있으므로 필요한 방법을 골라 사용하면 됨

        flagPosX = this.flag.transform.position.x;
    }

    void Update()
    {
        // 깃발과 차량 사이의 거리 계산
        float length = flagPosX - this.car.transform.position.x; // flag와 car의 좌표값을 받아와 빼기 실행, 깃발은 매 프레임 위치 잡을 필요없이 스타트에서 한번만 잡아주면 됨

        // 거리를 소수점 2자리까지 포맷하여 거리 텍스트 업데이트
        this.distance.GetComponent<TextMeshProUGUI>().text = "Distance:" + length.ToString("F2") + "m";
        // GetComponent<TextMeshProUGUI>().text 소괄호 빼먹으면 안됨
        //length.ToString("F2") == 소수점 2째자리까지 표시. 형식 다양하니 ToString 찾아볼 것
    }
}