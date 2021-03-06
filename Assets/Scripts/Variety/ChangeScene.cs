﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public GameObject canavs;
    public GameObject[] stageUI;

    public Image Panel;
    float time = 0f; //지속시간
    float f_Time = 1f;//페이드가 몇초간 지속될지

    public void StageScene()
    {
        StartCoroutine(StageMove());
    }

    IEnumerator StageMove()
    {
        //현재 선택한? 게임오브젝트의 이름을 가져온다.
        GameObject btnName = EventSystem.current.currentSelectedGameObject;

        Panel.gameObject.SetActive(true);
        canavs.SetActive(false);

        //다시 시작할때 한번더 초기화해야 정상적으로 실행됨
        time = 0;
        Color alpha = Panel.color;

        while (alpha.a < 1.0f)
        {
            time += Time.deltaTime / f_Time;

            //부드럽게 변화시키기
            alpha.a = Mathf.Lerp(0, 1, time);
            //매프레임 값 변화시키려고
            Panel.color = alpha;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        //버튼이름에 맞춰서 씬이동
        if (btnName.name == "Entrance1_Button")
        {
            SceneManager.LoadScene(2);
        }
        else if (btnName.name == "Entrance2_Button")
        {
            SceneManager.LoadScene(3);
        }
        else if (btnName.name == "Entrance3_Button")
        {
            SceneManager.LoadScene(4);
        }
        
        yield return null;
    }

    public void StageInfo()
    {
        GameObject StageName = EventSystem.current.currentSelectedGameObject;

        if(StageName.name == "Stage1_Button")
        {
            stageUI[0].SetActive(true);
        }
        else if(StageName.name == "Stage2_Button")
        {
            stageUI[1].SetActive(true);
        }
        else if(StageName.name == "Stage3_Button")
        {
            stageUI[2].SetActive(true);
        }
    }
}
