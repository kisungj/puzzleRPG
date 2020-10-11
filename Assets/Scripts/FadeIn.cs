using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FadeIn : MonoBehaviour
{
    public GameManager gManager;
    public Image Panel;
    float time = 0f;        //지속시간
    float f_Time = 1f;      //페이드가 몇초간 지속될지

    public void FadeOn()
    {
        StartCoroutine(FadeInOut());
    }

    IEnumerator FadeInOut()
    {
        //현재 선택한? 게임오브젝트의 이름을 가져온다.
        GameObject btnName = EventSystem.current.currentSelectedGameObject;

        Time.timeScale = 1.0f;
        Panel.gameObject.SetActive(true);

        time = 0;
        Color alpha = Panel.color;

        while (alpha.a < 1.0f)
        {
            time += Time.deltaTime / f_Time;

            //부드럽게 변화시키기
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        if(btnName.name == "Retreat_Button")
        {
            gManager.PreviousScene();
        }
        else if(btnName.name == "Clear_Button")
        {
            gManager.StageClear();
        }
    }
}
