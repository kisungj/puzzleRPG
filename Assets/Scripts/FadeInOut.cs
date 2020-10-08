using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image Panel;
    float time = 0f; //지속시간
    float f_Time = 1f;//페이드가 몇초간 지속될지

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        //다시 시작할때 한번더 초기화해야 정상적으로 실행됨
        time = 0;
        Color alpha = Panel.color;
        while(alpha.a < 1.0f)
        {
            time += Time.deltaTime / f_Time;
            //부드럽게 변화시키기
            alpha.a = Mathf.Lerp(0, 1, time);
            //매프레임 값 변화시키려고
            Panel.color = alpha;
            yield return null;
        }
        time = 0;
        
        yield return new WaitForSeconds(0.1f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / f_Time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
}
