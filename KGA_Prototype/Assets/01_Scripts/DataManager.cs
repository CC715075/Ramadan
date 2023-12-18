using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 싱글톤으로 만드는 방법 MonoBehavior 부분을 지우고 Singleton<클래스명> 해주면 됨
// Singleton이라고 쓰는 이유는 Generic으로 만든 스크립트의 이름이 Singleton이기 때문
public class DataManager : Singleton<DataManager>
{
    public float stageNum;
    public int killCount;

    private void Start()
    {
        Time.timeScale = 1f;
    }
}
