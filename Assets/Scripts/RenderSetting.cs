using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSetting : MonoBehaviour
{
    ////public 이 아닌 비공개 멤버를 인스펙터창에 노출시키는 용도로 사용
    //[SerializeField]
    //private Transform target;

    //private RectTransform myRect;
    //private Vector3 offset = new Vector3(0, 7.0f, 0);

    //void Start()
    //{
    //    myRect = GetComponent<RectTransform>();
    //}

    void Update()
    {
        //myRect.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position + offset);
        CLick();
    }

    void CLick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("나 눌렀음");
        }

        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("뗏음");
        }
    }

    
}
