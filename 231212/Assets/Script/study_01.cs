using System.Collections;
using System.Collections.Generic;
using UnityEngine; //����Ƽ ������ ����� ���� ���ڴٴ� �ǹ�
//using UnityEditor; //����Ƽ �������� ����� ����Ͽ��� �۵����� ����

// ���� �ּ�
/*
 *���� ��
 *�ּ�
 */
/* 
 * namespace testc
 * {
 * ȸ�翡 ���� ���� �浹�� �����ϱ� ���� ���ӽ����̽��� �տ��� �̸� �����صα⵵ ��
 * }
*/

public class study_01 : MonoBehaviour
{
    int test; //���� ���ִ� ���� ����
    //�̶� ���� �������� 0, string�� Null (lua�� nil�̾���)
    int test1; //����� ���ÿ� �� ���Ե� ����
    string test2;

    void Awake()
    {
        // Start���� ���� �����
        // �Ʒ��� ���ǵ� ����, �Լ� ���� �ҷ������ϸ� ���� �غ���� �ʾ� ���� ��
        // ������ ������ ��
        // awake�� �� ������ ����
        Debug.LogError("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log
        //  ("�㷣�� �׸���"
        //  + "hello, world");
        //Debug.LogError("����");
        //Debug.LogWarning("����");

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
        ////�� 3�� ��� ����
        ////for���̳� ī��Ʈ���� ���
        Debug.LogError("Start");
    }

    //void FixedUpdate()
    //{
    //    //�⺻������ 1 frame(1/60��)���� ����    
    //    Debug.LogError("Fixedupdate");
    //}

    void OnEnable() // �� ��ũ��Ʈ�� ����(������Ʈ�� �޸�) ������Ʈ�� Ȱ��ȭ �� ��, Start���� ������ Awake���� ����
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

    private void OnApplicationQuit() //Ȩ���� ���� �ڿ� ������ �������� �۵� ����
    {
        
    }

    private void OnApplicationFocus(bool focus) //�������� �ٽ� ���ƿ��� ��
    {
        
    }

    private void OnApplicationPause(bool pause) //��ȭ�� ���ų� ȭ���� ���� ������ ������ ��
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Debug.Log("Update");
    //}

    //void LateUpdate()
    //{
    //    //���� �ʰ� �����
    //    Debug.LogWarning("Lateupdate");
    //}
}
