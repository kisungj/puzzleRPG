using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    public float hp = 300.0f;
    private float maxHp = 300.0f;
    private float guage = 0;
    public float maxGuage = 100.0f;

    [SerializeField]
    private Text hpText;

    public Slider hpSlider;
    public Slider guageSlider;

    //플레이어 피격용 이펙트
    public GameObject hitEffect;

    void Update()
    {
        hpSlider.value = hp / maxHp;
        guageSlider.value = guage / maxGuage;
        hpText.text = hp + " / " + maxHp;
    }

    //공격 당했을 때
    public void hitDamage(int power)
    {
        hp -= power;

        //플레이어가 HP가 남아있는 상태에서 맞으면
        if(hp > 0)
        {
            StartCoroutine(PlayerHitEffect());
        }
    }

    IEnumerator PlayerHitEffect()
    {
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        hitEffect.SetActive(false);
    }
}
