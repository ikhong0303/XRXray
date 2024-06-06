using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToggler : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch; // 왼쪽 손 = 왼쪽 컨트롤러
    public GameObject menuPanel; // 패널(패드)
    public GameObject xrRig; // 플레이어 좌표 (메인 카메라를 보통 xrRig 좌표로 사용함)
    public float canvasDistanceForward = 0.6f; // 플레이어로부터 전방 0.6f(현실에서는 약 60cm 정도)에 패널 활성화
    public float height = 1.3f; // 패널 높이 = 1.3m

    private bool isCanvasVisible = false; // 처음에는 패널 비활성화
    private float lastXButtonTime = 0f; // 패널 활성화 방법을 더블 클릭으로 함 -> 더블클릭을 위한 변수
    public float doubleClickThreshold = 0.3f;

    void Start()
    {
        menuPanel.SetActive(false);
    }

    void Update()
    {
        // 손의 경우 왼손의 엄지와 검지를 두번 부딫히는 것 = 컨트롤러의 경우 왼쪽 컨트롤러의 첫번째 버튼(OVRInput.Button.One)을 더블 클릭하는 것
        if (OVRInput.GetDown(OVRInput.Button.One, leftController))
        {
            float currentTime = Time.time;
            if (currentTime - lastXButtonTime <= doubleClickThreshold)
            {
                ToggleMainCanvas();
            }
            lastXButtonTime = currentTime;
        }
    }

    private void ToggleMainCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        menuPanel.SetActive(isCanvasVisible);

        // 패널 활성화 좌표
        if (isCanvasVisible && xrRig != null)
        {
            // 어떤 방향으로든 전방 60cm 앞에 패널이 나타나게 함 -> Quarternion 사용해 방향 계산
            Quaternion rotation = Quaternion.Euler(0, xrRig.transform.eulerAngles.y, 0);
            Vector3 forwardDirection = rotation * Vector3.forward;

            // 패널 활성화 좌표 계산
            Vector3 canvasPosition = xrRig.transform.position + forwardDirection * canvasDistanceForward;
            canvasPosition.y = height;

            menuPanel.transform.position = canvasPosition;

            // 패널이 플레이어가 어딜 보든(고개 각도가 달라도) 항상 플레이어 시야 정면에 나타나게 캔버스 각도 조절
            menuPanel.transform.rotation = rotation;

            // 패널을 40도로 회전시킴 (x축 기준 회전)
            menuPanel.transform.Rotate(40, 0, 0);
        }
    }
}
