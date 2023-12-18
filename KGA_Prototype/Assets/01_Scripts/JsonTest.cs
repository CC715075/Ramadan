using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 데이터(코드 = 클래스)를 만들어야 함. -> 저장할 데이터 생성
// 2. 그 데이터를 Json으로 변환. (택배상자로 포장)
// 3. Json(택배)를 다시 원래의 코드로 바꾸는 방법
// 제이슨(택배) -> 조립도 -> 클래스(코드)

class Data
{
    public string nickname;
    public int level;
    public int coin;
    public bool skill;
    // 기타 등등...
    // 여기서 바로 기본 값을 집어 넣을 수도 있음, 하지만 데이터마다 기본 값이 다를 수 있어 여기서 하면 안됨
}


public class JsonTest : MonoBehaviour
{
    Data player = new Data() { nickname = "나", level = 50, coin = 200, skill = false }; // Data클래스의 정보를 가진 player라는 데이터 생성

    // Start is called before the first frame update
    void Start()
    {
        // 2. Json으로 변환
        string jsonData = JsonUtility.ToJson(player);

        Data player2 = JsonUtility.FromJson<Data>(jsonData);
        print(player2.nickname);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
