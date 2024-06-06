using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePosePanel : MonoBehaviour
{
    public Button poseOneButton;
    public Button poseTwoButton;
    public Button poseThreeButton;
    public GameObject poseOne;
    public GameObject poseTwo;
    public GameObject poseThree;

    private string lastClickedButton = "";

    void Start()
    {
        // 버튼 클릭 이벤트에 메서드 등록
        poseOneButton.onClick.AddListener(ActivatePoseOne);
        poseTwoButton.onClick.AddListener(ActivatePoseTwo);
        poseThreeButton.onClick.AddListener(ActivatePoseThree);

        // 처음에는 모든 게임 오브젝트를 비활성화
        poseOne.SetActive(false);
        poseTwo.SetActive(false);
        poseThree.SetActive(false);
    }

    void ActivatePoseOne()
    {
        if (lastClickedButton == "A")
        {
            // 모든 게임 오브젝트를 비활성화
            poseOne.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // poseOne 활성화
            poseOne.SetActive(true);
            poseTwo.SetActive(false);
            poseThree.SetActive(false);
            lastClickedButton = "A";
        }
    }

    void ActivatePoseTwo()
    {
        if (lastClickedButton == "B")
        {
            // 모든 게임 오브젝트를 비활성화
            poseTwo.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // poseTwo 활성화
            poseOne.SetActive(false);
            poseTwo.SetActive(true);
            poseThree.SetActive(false);
            lastClickedButton = "B";
        }
    }

    void ActivatePoseThree()
    {
        if (lastClickedButton == "C")
        {
            // 모든 게임 오브젝트를 비활성화
            poseThree.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // poseThree 활성화
            poseOne.SetActive(false);
            poseTwo.SetActive(false);
            poseThree.SetActive(true);
            lastClickedButton = "C";
        }
    }
}
