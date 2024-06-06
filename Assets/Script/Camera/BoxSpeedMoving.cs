using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxSpeedMoving : MonoBehaviour
{
    public Button buttonToClick; // 클릭하는 버튼
    public Image lightImage; // 흰색<->빨간색 이미지 (버튼이 잘 클릭되었는지 확인하는 용도)
    public GameObject upperGameObject; // 위 게임오브젝트 (카메라)
    public GameObject lowerGameObject; // 아래 게임오브젝트 (침대)
    public float speed = 0.1f; // lowerGameObject의 이동 속도
    public float distance = -0.3f; // upperGameObject와 lowerGameObject 사이의 거리
    public TextMeshProUGUI statusText;

    private bool isGreen = false; // lightImage 색 변화 변수
    private Vector3 initialLowerGameObjectPosition; // 초기 아래 게임오브젝트 위치
    private bool isLowerGameObjectMoved = false; // 아래 게임오브젝트 움직임 변수

    private static readonly Color RED_COLOR = Color.red;
    private static readonly Color GREEN_COLOR = Color.green;

    void Start()
    {
        buttonToClick.onClick.AddListener(HandleButtonClick);
        initialLowerGameObjectPosition = lowerGameObject.transform.position;

        // 초기 색상을 빨간색으로 설정
        lightImage.color = RED_COLOR;
        statusText.text = "OFF";
    }

    void Update()
    {
        if (isLowerGameObjectMoved)
        {
            MoveLowerGameObjectTowardsTarget();
        }
    }

    private void MoveLowerGameObjectTowardsTarget()
    {
        Vector3 targetPosition = GetTargetPosition();
        lowerGameObject.transform.position = Vector3.MoveTowards(lowerGameObject.transform.position, targetPosition, speed * Time.deltaTime);
    }

    private Vector3 GetTargetPosition()
    {
        return new Vector3(lowerGameObject.transform.position.x, upperGameObject.transform.position.y + distance, lowerGameObject.transform.position.z);
    }

    private void HandleButtonClick()
    {
        ToggleLightColor();
        ToggleLowerGameObjectMovement();
    }

    private void ToggleLightColor()
    {
        if (lightImage.color == RED_COLOR)
        {
            lightImage.color = GREEN_COLOR;
            statusText.text = "ON";
        }
        else
        {
            lightImage.color = RED_COLOR;
            statusText.text = "OFF";
        }
    }

    private void ToggleLowerGameObjectMovement()
    {
        isLowerGameObjectMoved = !isLowerGameObjectMoved;
    }
}
