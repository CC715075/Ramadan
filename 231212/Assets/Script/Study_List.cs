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
    list ����
    list<������ Ÿ��> ����Ʈ �̸� = new list<������ Ÿ��();
    ũ�⸦ �����ϰ� ����� ���� ����
    List<Datatype> name = new List<DataType>(new DataType[size])
    ��� size¥�� ����Ʈ�� ����
    List�� ������ ���ÿ� �ʱ�ȭ �ؼ� ���� ����
    List<string> ssh = new List<string>() { "�ż�ȣ", "�ٺ�" };
    �̷��� ssh ����Ʈ �ȿ� 0��°�� "�ż�ȣ", 1��°�� "�ٺ�"
    ssh[0] = "�ż�ȣ", ssh[1] = "�ٺ�"
    ����Ʈ�� �ٸ� ����Ʈ�� �޾Ƽ� ������ �� ����
    List<string> yyw = new List<string>(ssh);
    yyw = ssh
    ����Ʈ�� ������ �߰��ϴ� ���
    Add �Լ� �̿�
    ��� ����Ʈ�� �� �ڿ� �߰��ϴ� �����
    */
    List<string> ssh = new List<string>();
    // ssh��� ������ ����Ʈ �ʱ�ȭ


    private void Start()
    {
        ssh.Add("�ż�ȣ��");
        // ���⼭�� ssh �ʱ�ȭ �� ������ ���� �ȳ־��� size�� 0�� (�ƹ��͵� ����)
        // �׷��� "�ż�ȣ��"�� ssh[0]�� ��
        ssh.Add("�ż�ȣ��");
        // �߰��� �� ssh[1]�� ��ġ

        // insert �Լ� �̿� ���
        // �� �״�� �����ִ� �����
        // ���� �����ϱ� ������ �ִ� �ֵ��� �ڷ� �и�
        ssh.Insert(0, "�������");
        // ssh == [�������, �ż�ȣ��, �ż�ȣ��]
        // ssh.Insert(3); // ������ ��. �μ�Ʈ�� �Ű������� 2�� ���� ��

        /* 
        * �迭, ����Ʈ�� ũ�⸦ ���ϴ� ��
        * �迭�� ���
        * �迭�̸�.Length;
        * ����Ʈ�� ���
        * ����Ʈ�̸�.Count
        * �迭�� ����Ʈ�� ũ�⸦ ���ϴ� ����� �ٸ�
        * ���� �̸��� ����ϰ� ����� �ȵ�
        * 
        * ����Ʈ���� ������ �����ϴ� ���
        * - Remove �Լ�
        * ���ϴ� "��"�� ã�Ƽ� ����
        * ���� ���� ���� ���� �� ó�� ���� ����µ�
        * ���� ���̵� ������ 3���� �߿� 2�� °�� ������ �� ��Ȳ�� ���� ��
        * -RemoveAt �Լ� ���
        * ��� �ε��� ������ ����
        * �迭�� �����ϰ� 0���� ����
        * 
        * RemoveAll, Clear �Լ��� ����
        * �ٵ� ���� ����
        * ����Ʈ�̸�.RemoveAll(x => x == "yyw");
        * x => x == "yyw"�� �κ��� ���ٽ��̶� �ϴµ� x�� yyw�� �ֵ� ��θ� ����ٴ� ����
        */

        //-- for i = 2, 9 do
        //        --     for j = 1, 9 do
        //        --k = i * j
        //        ---- print(i.." * "..j.." = "..k)
        //        --         print((i - (i % j)) / j)
        //        --     end
        //        -- end

        // C#�� �߰�ȣ�� ���� ��
        // for����

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

        // ����ġ
        // �굵 ���ǿ� ���� ��� (if�� ���)
        // �ٵ� ��� �ϳ��� ���� �����ؼ� ��ġ�ϴ� ��쿡�� �ش� ��ɾ �����ϴ� ���
        // ��, ������ �Ұ� - ��Ȯ�� ��ġ�ϴ� ���� �־�� �� �� ����
        // int�� �ƴϾ ��

        /*        switch (�񱳰�)
                {
                    case ��ġ��1:
                        ������ ��ɾ�
                    break
                    case ��ġ��2:
                        ������ ��ɾ�
                    break
                    default:
                        ��ġ ���� ���� �� ������ ����
                        if�� ġ�� else�� �ش�
                    break
                }*/

        int randValue;
        randValue = UnityEngine.Random.Range(0, 3);
        // int�� �� ����(3) ���� ����
        // 0, 1, 2�� ����
        randValue = (int)UnityEngine.Random.Range(0f, 3f);


        // ��ȭ ���ڸ� �� ��(���, ���1, ���2�� ���´� ���� ��)
        // ��ȭ ������ �Ǵ��Ͽ� �� ��ȭ ������ �ش��ϴ� ���� ȹ��

    }
    // ���ڱ� �����
    // ���� 1���� ���, ���޶���, ��� �� 1���� 1~100�� ���� ����(���� ����)

    // ���� ���빰
    // ��ȭ ����

    // ���� ����
    List<string> box = new List<string>() { "���", "���޶���", "���" };
    List<int> gachaGet = new List<int>() { 0, 0, 0 };
    int matter, amount;

    [SerializeField]
    int minValue, maxValue;
    List<InventoryItem> inventory = new List<InventoryItem>();

    //�κ��丮�� �� ������ Ŭ���� - �̸��� ����
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

    //100����
    public void BoxGacha100()
    {
        minValue = 1;
        maxValue = 100;
        for (int i = 0; i < 100; i++)
        {
            // ��� ���� ����
            matter = UnityEngine.Random.Range(0, 3);
            // ��ᷮ ����
            amount = UnityEngine.Random.Range(minValue, maxValue + 1);

            GetItem(box[matter], amount);
            gachaGet[matter] += amount;
        }
        for (int i = 0;i < 3;i++)
        {
            Debug.Log(box[i] + "��(��) �� " + gachaGet[i] + "�� ȹ���߽��ϴ�");
        }
    }

    //����
    public void BoxGacha()
    {
        minValue = 1;
        maxValue = 100;
        // ��� ���� ����
        matter = UnityEngine.Random.Range(0, 2);
        // ��ᷮ ����
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
        Debug.Log(itemName + "��(��) " + itemAmount + "�� ȹ���߽��ϴ�");
    }

    List<string> gachaPool = new List<string>() { "1��", "2��", "3��", "4��", "5��"};
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
        Debug.Log(gachaPool[getChrRank] + "��(��) " + getChrAmount + "�� ȹ���߽��ϴ�");
    }

    public void ChrGacha100()
    {
        minValue = 1;
        maxValue = 100;
        for (int i = 0; i < 30; i++)
        {
            // ĳ���� ��ް� ���� ����
            randomValue = UnityEngine.Random.Range(0, 100);
            switch (chunjang)
            {
                case 29:
                    randomValue = 0;
                    Debug.Log("õ�夺��");
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
            Debug.Log(gachaPool[i] + "��(��) �� " + chrGachaGet[i] + "�� ȹ���߽��ϴ�");
        }
    }
}
