using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public float hp = 0;
    private float maxHp = 500.0f;
    private GameObject fhpBar;
    private GameObject fhpText;

    [SerializeField]
    private Text hpText;
    public Slider hpSlider; 

    void Start()
    {
        hpSlider.value = hp / maxHp;
        hpText.text = hp + " / " + maxHp;

        //해당 오브젝트 이름 찾아준다.
        fhpBar = GameObject.Find("UICanvas/EnemyUI/HpBar");
        fhpText = GameObject.Find("UICanvas/EnemyUI/HpText");
    }

    void Update()
    {
        //오브젝트에 따른 위치 이동 (월드좌표를 화면좌표로 변환시켜준다)
        fhpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -0.2f, 0));
        fhpText.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -0.2f, 0));
    }
}
