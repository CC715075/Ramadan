using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using static Unity.Burst.Intrinsics.X86;
using static UnityEditor.LightingExplorerTableColumn;

public class Study_List : MonoBehaviour
{
    /*
    list 선언
    list<데이터 타입> 리스트 이름 = new list<데이터 타입();
    크기를 지정하고 만들고 싶을 때는
    List<Datatype> name = new List<DataType>(new DataType[size])
    빈거 size짜리 리스트를 만듬
    List도 생성과 동시에 초기화 해서 대입 가능
    List<string> ssh = new List<string>() { "신성호", "바보" };
    이러먼 ssh 리스트 안에 0번째는 "신성호", 1번째는 "바보"
    ssh[0] = "신성호", ssh[1] = "바보"
    리스트는 다른 리스트를 받아서 대입할 수 있음
    List<string> yyw = new List<string>(ssh);
    yyw = ssh
    리스트에 데이터 추가하는 방법
    Add 함수 이용
    얘는 리스트의 맨 뒤에 추가하는 방법임
    */
    List<string> ssh = new List<string>();
    // ssh라는 문자형 리스트 초기화


    private void Start()
    {
        ssh.Add("신성호우");
        // 여기서는 ssh 초기화 후 별도로 값을 안넣어놨어서 size가 0임 (아무것도 없음)
        // 그래서 "신성호우"가 ssh[0]에 들어감
        ssh.Add("신성호이");
        // 추가한 건 ssh[1]에 위치

        // insert 함수 이용 방법
        // 말 그대로 끼워넣는 방식임
        // 끼워 넣으니까 기존에 있던 애들은 뒤로 밀림
        ssh.Insert(0, "유용워이");
        // ssh == [유용워이, 신성호우, 신성호이]
        // ssh.Insert(3); // 빨간줄 뜸. 인서트엔 매개변수가 2개 들어가야 함

        /* 
        * 배열, 리스트의 크기를 구하는 법
        * 배열일 경우
        * 배열이름.Length;
        * 리스트일 경우
        * 리스트이름.Count
        * 배열과 리스트의 크기를 구하는 방법이 다름
        * 따라서 이름을 비슷하게 만들면 안됨
        * 
        * 리스트에서 데이터 삭제하는 방법
        * - Remove 함수
        * 원하는 "값"을 찾아서 지움
        * 같은 값이 여러 개면 맨 처음 값을 지우는데
        * 같은 아이디를 가지는 3마리 중에 2번 째를 지워야 할 상황도 있을 것
        * -RemoveAt 함수 사용
        * 얘는 인덱스 정보로 지움
        * 배열과 동일하게 0부터 시작
        * 
        * RemoveAll, Clear 함수가 있음
        * 근데 쓸일 없음
        * 리스트이름.RemoveAll(x => x == "yyw");
        * x => x == "yyw"이 부분은 람다식이라 하는데 x가 yyw인 애들 모두를 지운다는 내용
        */

        //-- for i = 2, 9 do
        //        --     for j = 1, 9 do
        //        --k = i * j
        //        ---- print(i.." * "..j.." = "..k)
        //        --         print((i - (i % j)) / j)
        //        --     end
        //        -- end

        // C#은 중괄호로 묶어 줌
        // for문은

        int sum = 0;
        int odd = 0;

        for (int i = 2; i < 10; i++) 
        {
            for (int j = 1; j < 10; j++)
            {
                int k = i*j;
                Debug.Log(i + " * " + j + " = " + k);
                Debug.Log((i - (i % j)) / j);
                sum += k;
                if (sum % 2 == 1)
                {
                    odd++;
                }
            }
        }

        // 스위치
        // 얘도 조건에 따른 제어문 (if랑 비슷)
        // 근데 얘는 하나의 값을 참조해서 일치하는 경우에만 해당 명령어를 실행하는 방식
        // 비교, 논리연산 불가 - 정확히 일치하는 값이 있어야 쓸 수 있음
        // int가 아니어도 됨

        /*        switch (비교값)
                {
                    case 일치값1:
                        실행할 명령어
                    break
                    case 일치값2:
                        실행할 명령어
                    break
                    default:
                        일치 값이 없을 때 실행할 내용
                        if로 치면 else에 해당
                    break
                }*/

        int randValue;
        randValue = UnityEngine.Random.Range(0, 3);
        // int일 때 끝값(3) 포함 안함
        // 0, 1, 2만 나옴
        randValue = (int)UnityEngine.Random.Range(0f, 3f);


        // 재화 상자를 열 때(골드, 재료1, 재료2가 나온다 쳤을 때)
        // 재화 종류를 판단하여 그 재화 수량에 해당하는 값을 획득

    }
    // 상자깡 만들기
    // 상자 1개는 골드, 에메랄드, 루비 중 1종류 1~100개 랜덤 지급(종류 무관)

    // 상자 내용물
    // 재화 갯수

    // 변수 선언
    List<string> box = new List<string>() { "골드", "에메랄드", "루비" };
    List<int> gachaGet = new List<int>() { 0, 0, 0 };
    int matter, amount;

    [SerializeField]
    int minValue, maxValue;
    List<InventoryItem> inventory = new List<InventoryItem>();

    //인벤토리에 들어갈 아이템 클래스 - 이름과 갯수
    public class InventoryItem
    {
        public string name { get; set; }
        public int amount { get; set; }
        public InventoryItem(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }
    }

    //100연차
    public void BoxGacha100()
    {
        minValue = 1;
        maxValue = 100;
        for (int i = 0; i < 100; i++)
        {
            // 재료 종류 랜덤
            matter = UnityEngine.Random.Range(0, 3);
            // 재료량 랜덤
            amount = UnityEngine.Random.Range(minValue, maxValue + 1);

            GetItem(box[matter], amount);
            gachaGet[matter] += amount;
        }
        for (int i = 0;i < 3;i++)
        {
            Debug.Log(box[i] + "을(를) 총 " + gachaGet[i] + "개 획득했습니다");
        }
    }

    //단차
    public void BoxGacha()
    {
        minValue = 1;
        maxValue = 100;
        // 재료 종류 랜덤
        matter = UnityEngine.Random.Range(0, 2);
        // 재료량 랜덤
        amount = UnityEngine.Random.Range(minValue, maxValue + 1);

        GetItem(box[matter], amount);
    }

    void GetItem(string itemName, int itemAmount)
    {
        int index = inventory.FindIndex(x => x.name.Equals(itemName));
        if (index != -1)
        {
            inventory[index].amount += itemAmount;
        }
        else
        {
            inventory.Add(new InventoryItem(itemName, itemAmount));
        }
        Debug.Log(itemName + "을(를) " + itemAmount + "개 획득했습니다");
    }

    List<string> gachaPool = new List<string>() { "1성", "2성", "3성", "4성", "5성"};
    List<int> chrGachaGet = new List<int>() { 0, 0, 0, 0, 0 };
    int getChrRank, getChrAmount, randomValue, randomAmount, chunjang;

    public class Chr
    {
        public string name { get; set; }
        public int rank { get; set; }
        public Chr(string name, int rank)
        {
            this.name = name;
            this.rank = rank;
        }
    }

    void GetChr(int getChrRank, int getChrAmount)
    {
        Debug.Log(gachaPool[getChrRank] + "을(를) " + getChrAmount + "개 획득했습니다");
    }

    public void ChrGacha100()
    {
        minValue = 1;
        maxValue = 100;
        for (int i = 0; i < 30; i++)
        {
            // 캐릭터 등급과 수량 랜덤
            randomValue = UnityEngine.Random.Range(0, 100);
            switch (chunjang)
            {
                case 29:
                    randomValue = 0;
                    Debug.Log("천장ㅊㅊ");
                break;
            }

            if (randomValue < 2)
            {
                getChrRank = 4;
                randomAmount = UnityEngine.Random.Range(1, 6);
                chrGachaGet[4] += randomAmount;
                chunjang = 0;
            }
            else if (randomValue < 10)
            {
                getChrRank = 3;
                randomAmount = UnityEngine.Random.Range(5, 11);
                chrGachaGet[3] += randomAmount;
                chunjang++;
            }
            else if (randomValue < 50)
            {
                getChrRank = 2;
                randomAmount = UnityEngine.Random.Range(10, 21);
                chrGachaGet[2] += randomAmount;
                chunjang++;
            }
            else if (randomValue < 80)
            {
                getChrRank = 1;
                randomAmount = UnityEngine.Random.Range(15, 26);
                chrGachaGet[1] += randomAmount;
                chunjang++;
            }
            else
            {
                getChrRank = 0;
                randomAmount = UnityEngine.Random.Range(20, 31);
                chrGachaGet[0] += randomAmount;
                chunjang++;
            }
            GetChr(getChrRank, randomAmount);
        }
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(gachaPool[i] + "을(를) 총 " + chrGachaGet[i] + "명 획득했습니다");
        }
    }
}
