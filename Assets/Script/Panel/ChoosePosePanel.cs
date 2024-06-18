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

    public GameObject pose2image;
    public GameObject pose3image;

    private string lastClickedButton = "";

    void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ�� �޼��� ���
        poseOneButton.onClick.AddListener(ActivatePoseOne);
        poseTwoButton.onClick.AddListener(ActivatePoseTwo);
        poseThreeButton.onClick.AddListener(ActivatePoseThree);

        // ó������ ��� ���� ������Ʈ�� ��Ȱ��ȭ
        poseOne.SetActive(false);
        poseTwo.SetActive(false);
        poseThree.SetActive(false);
        pose2image.SetActive(false);
        pose3image.SetActive(false);
    }

    void ActivatePoseOne()
    {
        if (lastClickedButton == "A")
        {
            // ��� ���� ������Ʈ�� ��Ȱ��ȭ
            poseOne.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // poseOne Ȱ��ȭ
            poseOne.SetActive(true);
            pose2image.SetActive(false);
            pose3image.SetActive(false);
            poseTwo.SetActive(false);
            poseThree.SetActive(false);
            lastClickedButton = "A";
        }
    }

    void ActivatePoseTwo()
    {
        if (lastClickedButton == "B")
        {
            // ��� ���� ������Ʈ�� ��Ȱ��ȭ
            poseTwo.SetActive(false);
            pose2image.SetActive(false);
            pose3image.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // poseTwo Ȱ��ȭ
            poseOne.SetActive(false);
            poseTwo.SetActive(true);
            pose2image.SetActive(true);
            pose3image.SetActive(false);
            poseThree.SetActive(false);
            lastClickedButton = "B";
        }
    }

    void ActivatePoseThree()
    {
        if (lastClickedButton == "C")
        {
            // ��� ���� ������Ʈ�� ��Ȱ��ȭ
            poseThree.SetActive(false);
            pose2image.SetActive(false);
            pose3image.SetActive(false);
            lastClickedButton = "";
        }
        else
        {
            // poseThree Ȱ��ȭ
            poseOne.SetActive(false);
            poseTwo.SetActive(false);
            poseThree.SetActive(true);
            pose2image.SetActive(false);
            pose3image.SetActive(true);
            lastClickedButton = "C";
        }
    }
}
