using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission : MonoBehaviour
{
    public IEnumerator ObjEmission(float duration = 0.5f)
    {
        float passTime = 0;

        //시간이 지속시간보다 짧을때만 작동
        while(passTime < duration)
        {
            Renderer rend = GetComponent<Renderer>();
            Material mat = rend.material;
            //mathf.PingPong(증가값, 최대거리)
            float emission = Mathf.PingPong(Time.time, 0.33f);
            //기본 색상
            Color baseColor = new Color32(102, 32, 23, 255);
            //선형에서 감마 색상 공간으로 값을 변형합니다.
            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
            // 칼라 입력                               //칼라 세기 조절
            mat.SetColor("_EmissionColor", finalColor * 3f);

            passTime += Time.deltaTime;

            yield return null;
        }

        //emission 초기값으로 돌려줘야함
        Renderer oriRend = GetComponent<Renderer>();
        Material oriMat = oriRend.material;
        oriMat.SetColor("_EmissionColor", Color.black);
    }
}
