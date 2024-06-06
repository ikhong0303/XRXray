using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtonToggler : MonoBehaviour
{
    public Button aButton; // 버튼을 연결할 변수
    public Image[] images; // 이미지들을 연결할 배열
    private int currentIndex = 0; // 현재 표시할 이미지 인덱스

    void Start()
    {
        // 버튼 클릭 시 OnButtonClick 함수 호출 설정
        aButton.onClick.AddListener(OnButtonClick);

        // 모든 이미지를 비활성화하고 첫 번째 이미지를 활성화
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(i == 0);
        }
    }

    void OnButtonClick()
    {
        // 마지막 이미지가 활성화된 상태면 그 상태로 중단
        if (currentIndex >= images.Length - 1)
        {
            return;
        }

        // 현재 이미지를 비활성화하고 다음 이미지를 활성화
        images[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        images[currentIndex].gameObject.SetActive(true);
    }
}
