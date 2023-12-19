using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameObject : MonoBehaviour
{
    public TextAsset monsterTbl;
    public GameObject monsterPrefab;
    public List<Monster> monsterList;
    List<Dictionary<string, object>> monsterData = new List<Dictionary<string, object>>();
    void Start()
    {
        monsterData = CSVReader.Read(monsterTbl);
        Debug.Log(monsterData.Count);
        for(int i = 0; i < monsterData.Count; i++)
        {
            GameObject _monster = Instantiate(monsterPrefab);
            Monster monster = _monster.GetComponent<Monster>();
            monster.id = (int)monsterData[i]["id"];
            monster.hp = (int)monsterData[i]["hp"];
            monster.atkPower = (int)monsterData[i]["atkPower"];
            monster.def = (int)monsterData[i]["def"];
            monster.cri = (int)monsterData[i]["cri"];
            monsterList.Add(monster);
        }
    }

    public void MonsterGen(int id)
    {
        if(id == -1)
        {
            return;
        }
        else
        {
            GameObject _monster = Instantiate(monsterPrefab);
            Monster monster = _monster.GetComponent<Monster>();
            for (int i = 0; i < monsterData.Count; i++)
            {
                if ((int)monsterData[i]["id"] == id)
                {
                    monster.id = (int)monsterData[i]["id"];
                    monster.hp = (int)monsterData[i]["hp"];
                    monster.atkPower = (int)monsterData[i]["atkPower"];
                    monster.def = (int)monsterData[i]["def"];
                    monster.cri = (int)monsterData[i]["cri"];
                }
            }
        }
    }



    void Update()
    {
        
    }
}
