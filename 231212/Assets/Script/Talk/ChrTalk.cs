//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UIElements;

//public class ChrTalk : MonoBehaviour
//{
//    int order;
//    [SerializeField]
//    public Image chrL;
//    [SerializeField]
//    public Image chrR;
//    [SerializeField]
//    public Image bg;
//    [SerializeField]
//    public TextMeshProUGUI chrText;
//    //[변수명].gameObject.SetActive(false);
//    chrL.gameObject.SetActive(true);
//    // Start is called before the first frame update
//    public void Talk()
//    {
//        if (order == 0)
//        {

//            chrText.text = "안녕";
//        }
//        else if(order == 1)
//        {
//            chrText.text = "안녕";
//        }
        
//    }
//    // 배열
//    // 같은 데이터 타입을 가지는 여러 값을 저장해 줌
//    // 근데 배열은 크기가 정해져 있음
//    // 배열 선언 방법
//    // dataType[] 배열 이름 = new dataType[size];
//    // dataType[] 배열 이름 = {value1, value2, value3, ...};
//    // 배열은 0번째부터 시작
//    // chrText.text = chrTextList[order];
//    // chrTextList라는 배열의 order번째에 해당하는 값을 chrText.text에 넣겠다
//    // 배열은 중간이 빠지면 그냥 비지만, 리스트는 빈 곳을 앞쪽부터 채워 넣으면서 땡겨짐
//    int[] testarray = new int[5];
//    // 값 배정을 안하면 null이라서 0이나 -1로 채워줌
//}
