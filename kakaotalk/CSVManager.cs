using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CSVManager : MonoBehaviour
{

    List<Dictionary<string, object>> monsterData = new List<Dictionary<string, object>>();
    List<Monster> monsterList;
    // Start is called before the first frame update
    void Start()
    {
        monsterData = CSVReader.Read(monsterTbl);

        Debug.Log(monsterData.Count);

        for (int i = 0; i < monsterData.Count; i++)
        {
            GameObject _monster = Instantiate(monsterPrefab);
            Monster monster = _monster.GetComponent<Monster>();
            monster.id = (int)monsterData[i]["id"];
            monster.hp = (int)monsterData[i]["hp"];
            monster.atk = (int)monsterData[i]["atk"];
            monster.def = (int)monsterData[i]["def"];
            monsterList.Add(monster);
        }


    }

    // Update is called once per frame
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
                    monster.atk = (int)monsterData[i]["atk"];
                    monster.def = (int)monsterData[i]["def"];
                }
            }
        }
    }
}
