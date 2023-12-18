using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    public GameObject[] stagePre;
    public GameObject clearUI;
    int goalKillCount;

    // Start is called before the first frame update
    void Start()
    {
        switch (DataManager.Instance.stageNum)
        {
            case 1.1f :
                goalKillCount = 2;
                DataManager.Instance.killCount = 0;
                Instantiate(stagePre[0], transform.position, transform.rotation);
                break;
            case 1.2f:
                goalKillCount = 3;
                DataManager.Instance.killCount = 0;
                Instantiate(stagePre[1], transform.position, transform.rotation);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.Instance.killCount >= goalKillCount)
        {
            Time.timeScale = 0f;
            clearUI.SetActive(true);
        }
    }
}