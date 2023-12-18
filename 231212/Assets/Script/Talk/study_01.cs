using System.Collections;
using System.Collections.Generic;
using UnityEngine; //유니티 엔진의 기능을 갖다 쓰겠다는 의미
//using UnityEditor; //유니티 에디터의 기능은 모바일에서 작동하지 않음

// 한줄 주석
/*
 *여러 줄
 *주석
 */
/* 
 * namespace testc
 * {
 * 회사에 따라 변수 충돌을 방지하기 위해 네임스페이스를 앞에서 미리 정의해두기도 함
 * }
*/

public class study_01 : MonoBehaviour
{
    int test; //선언만 해주는 것이 가능
    //이때 값은 숫자형은 0, string은 Null (lua는 nil이었음)
    int test1; //선언과 동시에 값 대입도 가능
    string test2;

    void Awake()
    {
        // Start보다 먼저 실행됨
        // 아래에 정의된 변수, 함수 등을 불러오려하면 아직 준비되지 않아 오류 뜸
        // 순차적 실행이 됨
        // awake는 잘 쓰지는 않음
        Debug.LogError("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log
        //  ("펑랜이 그립다"
        //  + "hello, world");
        //Debug.LogError("에러");
        //Debug.LogWarning("워닝");

        //test += 4; // test = test + 4;
        //Debug.Log(test1);
        //test1++;
        //Debug.Log(test1);
        //test1 += 1;
        //Debug.Log(test1);
        //test1 = test1 + 1;
        //Debug.Log(test1);
        //Debug.Log(test2);
        ////test2++;
        //Debug.Log(test2);
        //test2 += 1;
        //Debug.Log(test2);
        //test2 = test2 + 1;
        //Debug.Log(test2);
        ////위 3개 모두 같음
        ////for문이나 카운트에서 사용
        Debug.LogError("Start");
    }

    //void FixedUpdate()
    //{
    //    //기본적으로 1 frame(1/60초)마다 실행    
    //    Debug.LogError("Fixedupdate");
    //}

    void OnEnable() // 이 스크립트를 가진(컴포넌트로 달린) 오브젝트가 활성화 될 때, Start보다 빠르고 Awake보다 느림
    {
        Debug.Log("On");
    }

    void OnDisable()
    {
        Debug.Log("Off");
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy");
    }

    private void OnApplicationQuit() //홈으로 나간 뒤에 게임을 꺼버리면 작동 안함
    {
        
    }

    private void OnApplicationFocus(bool focus) //게임으로 다시 돌아왔을 때
    {
        
    }

    private void OnApplicationPause(bool pause) //전화가 오거나 화면을 내려 게임이 멈췄을 때
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Debug.Log("Update");
    //}

    //void LateUpdate()
    //{
    //    //조금 늦게 실행됨
    //    Debug.LogWarning("Lateupdate");
    //}
}
