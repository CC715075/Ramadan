using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI에 접근하기 위해서 필요
using TMPro; // 텍스트메쉬프로 쓰려면 따로 불러와야 함

public class UIManager : MonoBehaviour
{
    // 루아는 변수를 따로 저의 안하면 global로 사용, 지역은 앞에 local 입력해줌
    // 유니티는 public을 붙여줘야 전역에서 사용 가능
    [HideInInspector] // 퍼블릭도 컴포넌트에서 숨기기 가능, 세미콜론마다 앞에 붙여줘야 함
    public int testValue = 1;
    // [HideInInspector] public int testValue = 1; //줄 안바꿔도 가능
    public Image bg1;

    [SerializeField] // 컴포넌트에서 표시됨
    Color _color;
    bool isChanged;

    [SerializeField]
    Sprite uiBg0; // 기본 이미지
    [SerializeField]
    Sprite uiBg1; // 바꿀 이미지

    public TextMeshProUGUI _uitext0;

    private void Start()
    {
        Debug.Log(testValue);
        _color = bg1.color;
        uiBg0 = bg1.sprite;
    }
    
    public void ChangeColor()
    {
        if (!isChanged)
        {
            // bg1.color = Color.cyan;
            // new Color(0.5, 0.5, 0.5, 0.5); //255를 0-1 사이의 수로 환산해서 넣어줘야 함
            bg1.sprite = uiBg1;
            _uitext0.text = "isChanged";
            isChanged = !isChanged;
        }
        else
        {
            //bg1.color = _color;
            bg1.sprite = uiBg0;
            _uitext0.text = "!isChanged";
            isChanged = !isChanged;
        }
    }

}
