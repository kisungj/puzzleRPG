using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    public float hp = 300.0f;
    private float maxHp = 300.0f;
    public float guage = 100.0f;
    public float maxGuage = 100.0f;

    [SerializeField]
    private Text hpText;
    public Slider hpSlider;
    public Slider guageSlider;
    public Button playerBtn;

    //플레이어 피격용 이펙트
    public GameObject hitEffect;
    //플레이어 공격 이펙트
    public GameObject AttEffect;
    //플레이어 죽은상태 이미지
    public GameObject DieImage;

    void Update()
    {
        hpSlider.value = hp / maxHp;
        guageSlider.value = guage / maxGuage;
        hpText.text = hp + " / " + maxHp;

        //버튼 OnClick 이벤트 활성화 비활성화 할수있음 (0은 인덱스 리스너 순서인거같음 맨위에꺼, 맨뒤에껄로 Off or On 시킬수 있음)
        //playerBtn.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
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
        //플레이어 체력이 다 떨어지면
        else
        {
            hp = 0;
            StartCoroutine(PlayerDie());
        }
    }

    IEnumerator PlayerHitEffect()
    {
        hitEffect.SetActive(true);

        //피격 상태 맞추려고
        yield return new WaitForSeconds(0.5f);

        hitEffect.SetActive(false);
    }

    IEnumerator PlayerDie()
    {
        DieImage.SetActive(true);
        //버튼 비활성화
        playerBtn.interactable = false;

        yield return null;
    }

    //게이지가 풀로차면
    public void guageFull()
    {
        
    }
}
