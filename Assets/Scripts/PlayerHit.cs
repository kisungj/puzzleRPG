using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    public float hp = 300.0f;
    private float maxHp = 300.0f;
    public float guage = 0;
    public float maxGuage = 100.0f;

    [SerializeField]
    private Text hpText;
    public Slider hpSlider;
    public Slider guageSlider;
    public Button playerBtn;

    //플레이어 피격용 이미지
    public GameObject hitimg;
    //플레이어 피격용 이펙트
    public GameObject hitEffect;
    //플레이어 피격용 이펙트 위치
    public Transform hitEffectPos;
    //플레이어 공격용 이미지
    public GameObject AttEimg;
    //플레이어 죽은상태 이미지
    public GameObject DieImage;

    //시험용 타이머 지워도됨
    float time = 0;

    //플레이어 히트 데미지 text하고 위치
    public GameObject hudDamageText;
    public Transform hudPos;

    void Update()
    {
        hpSlider.value = hp / maxHp;
        guageSlider.value = guage / maxGuage;
        hpText.text = hp + " / " + maxHp;

        //임시로 만든거 옮기던가 바꾸던가 해야댐
        //버튼 OnClick 이벤트 활성화 비활성화 할수있음 (0은 인덱스 리스너 순서인거같음 맨위에꺼, 맨뒤에껄로 O1ff or On 시킬수 있음)
        //playerBtn.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
        if(guage >= 100 && hp > 0)
        {
            time += Time.deltaTime;
            guage = 100;
            playerBtn.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.RuntimeOnly);

            //깜빡이는 효과주기
            if (time < 0.15f)
            {
                AttEimg.SetActive(true);
            }
            else 
            {
                if(time > 0.3f)
                {
                    AttEimg.SetActive(false);
                    time = 0;
                }
            }
        }
        else
        {
            playerBtn.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
        }
    }

    //공격 당했을 때
    public void hitDamage(int power)
    {
        hp -= power;
        guage += 34;
        //플레이어가 HP가 남아있는 상태에서 맞으면
        if(hp > 0)
        {
            StartCoroutine(PlayerHitImg());

            //플레이어 히트 텍스트 보이게하려구..
            GameObject hudText = Instantiate(hudDamageText); // 생성할 텍스트 오브젝트
            hudText.transform.position = hudPos.position; // 표시될 위치
            hudText.GetComponent<DamageText>().damage = -power; // 데미지 전달

            //플레이어 히트 이펙트 생성 후 1초뒤 삭제
            StartCoroutine(HitEffect());
        }
        //플레이어 체력이 다 떨어지면
        else
        {
            hp = 0;
            StartCoroutine(PlayerDie());
        }
    }

    IEnumerator HitEffect()
    {
        GameObject hitEft = Instantiate(hitEffect, hitEffectPos.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f);
        Destroy(hitEft);
    }

    IEnumerator PlayerHitImg()
    {
        hitimg.SetActive(true);

        //피격 상태 맞추려고
        yield return new WaitForSeconds(0.5f);

        hitimg.SetActive(false);
    }

    IEnumerator PlayerDie()
    {
        //모든 이펙트 및 버튼 비활성화
        DieImage.SetActive(true);
        hitimg.SetActive(false);
        AttEimg.SetActive(false);
        playerBtn.interactable = false;

        yield return null;
    }

    IEnumerator test()
    {
        guage = 0;

        yield return null;
    }

    //게이지 초기화
    public void guageZero()
    {
        Debug.Log("왜 안들어옴");
        guage = 0;
    }
}
