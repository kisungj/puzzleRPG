using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public float hp = 300.0f;
    private float maxHp = 300.0f;
    private float guage = 0;
    public float maxGuage = 100.0f;

    [SerializeField]
    private Text hpText;

    public Slider hpSlider;
    public Slider guageSlider;

    void Update()
    {
        hpSlider.value = hp / maxHp;
        guageSlider.value = guage / maxGuage;
        hpText.text = hp + " / " + maxHp;

        hitDamage();
    }

    //공격 당했을 때
    public void hitDamage()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hp -= 10;
        }
    }
}
