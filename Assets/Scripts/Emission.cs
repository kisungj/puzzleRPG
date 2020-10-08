using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission : MonoBehaviour
{
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("Emission");
        //rend.material.SetColor("_EmissionColor", new Color32(23, 135, 23, 255));
        // 오브젝트에 세이더를 정해주고
        rend.material.shader = Shader.Find("Transparent/VertexLit");
        // 칼라 입력
        rend.material.SetColor("_Emission", new Color(77, 202, 137));
    }
}
