using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //씬 관리 기능들을 사용하기 위해 필요함

public class UIManager : MonoBehaviour
{
    public void GoMainScene()
    {
        SceneManager.LoadScene("Mainscene");
    }
    public void GoStageScene()
    {
        SceneManager.LoadScene("StageScene");
        //SceneManager.LoadScene(); 괄호 안의 내용과 같은 명칭의 씬을 불러오겠다는 의미
    }

    public void Battle1_1()
    {
        DataManager.Instance.stageNum = 1.1f;
        SceneManager.LoadScene("BattleScene");
    }

    public void Battle1_2()
    {
        DataManager.Instance.stageNum = 1.2f;
        SceneManager.LoadScene("BattleScene");
    }
}
