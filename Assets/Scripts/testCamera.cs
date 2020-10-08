using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCamera : MonoBehaviour
{
    //이동 효과를 줄 카메라의 Transform을 저장할 변수
    public Transform moveCamera;

    //초기 좌표의 회전값을 저장할 변수
    private Vector3 originPos;

    void Start()
    {
        //카메라의 초깃값을 저장
        originPos = moveCamera.localPosition;
    }

    public IEnumerator MoveCamera(float duration = 2.0f)
    {
        //지나간 시간을 누적할 변수
        float passTime = 0.0f;

        while(passTime < duration)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 3.5f, Space.World);

            //진동 시간을 누적
            passTime += Time.deltaTime;

            yield return null;
        }

        moveCamera.localPosition = originPos;
    }
}
