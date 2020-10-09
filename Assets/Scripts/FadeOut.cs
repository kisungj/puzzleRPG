using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image Panel;
    float time = 0f; //지속시간
    float f_Time = 1f;//페이드가 몇초간 지속될지

    void Awake()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        //다시 시작할때 한번더 초기화해야 정상적으로 실행됨
        time = 0;
        Color alpha = Panel.color;
        
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
