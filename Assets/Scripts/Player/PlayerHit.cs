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
    //모든 플레이어 체력 상태 알기위해
    [SerializeField]
    private PlayerHp playerHp;

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
    //플레이어 게이지 풀 이펙트
    public GameObject guageEft;
    //플레이어 게이지 이펙트 위치
    public Transform guageEftPos;
    //테스트중
    GameObject guageEftObj;

    //시험용 타이머 지워도됨
    float time = 0;

    //게이지 충전시 알파값 효과 주려고
    byte alpha = 255;
    bool alphaChange;

    //플레이어 히트 데미지 text하고 위치
    public GameObject hudDamageText;
    public Transform hudPos;

    void Update()
    {
        hpSlider.value = hp / maxHp;
        guageSlider.value = guage / maxGuage;
        hpText.text = hp + " / " + maxHp;

        //임시로 만든거 옮기던가 바꾸던가 해야댐
        //버튼 OnClick 이벤트 활성화 비활성화 할수있음 (0은 인덱스 리스너 순서인거같음 맨위에꺼, 맨뒤에껄로 Off or On 시킬수 있음)
        //playerBtn.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
        if(guage >= 100 && hp > 0)
        {
            time += Time.deltaTime;
            guage = 100;
            playerBtn.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.RuntimeOnly);

            //게이지 풀로찼으면 게이지 이펙트 표시
            StartCoroutine(GuageEffect());

            //int count = 0;
            //bool onOff = true;

            //if(onOff)
            //{
            //    guageEftObj = Instantiate(guageEft); // 생성할 게이지이펙트 오브젝트
            //    guageEftObj.transform.position = guageEftPos.position;  //생성할 위치
            //    count++;

            //    if(count >= 1)
            //    {
            //        onOff = false;
            //    }
            //}

            //if (guage == 0)
            //{
            //    Destroy(guageEftObj);
            //}

            Image effImg = AttEimg.GetComponent<Image>();
            AttEimg.SetActive(true);

            //현재 지정해둔 색상 가져오고 알파값만 조정하려고
            Color32 cor = effImg.color;
            effImg.color = new Color32(cor.r, cor.g, cor.b, alpha);

            //게이지 충전되면 알파값 효과주기
            if (!alphaChange)
            {
                alpha -= 10;
            }
            else
            {
                alpha += 10;
            }

            if (alpha < 10)
            {
                alphaChange = true;
            }
            else if (alpha >= 255)
            {
                alphaChange = false;
            }
        }
        else
        {
            AttEimg.SetActive(false);
            playerBtn.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
        }
    }

    //공격 당했을 때
    public void hitDamage(int power)
    {
        hp -= power;
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

    //플레이어 힐 스킬 사용할때
    public void healing()
    {
        //hp가 남아있는 상태에서만 회복
        if(hp > 0)
        {
            hp += 60;
        }
        //회복량이 최대 회복량을 넘어가게 되면 최대회복량으로 표시
        if (hp >= maxHp)
        {
            hp = maxHp;
        }

        //플레이어 히트 텍스트 보이게하려구..
        GameObject hudText = Instantiate(hudDamageText); // 생성할 텍스트 오브젝트
        hudText.transform.position = hudPos.position; // 표시될 위치
        hudText.GetComponent<DamageText>().damage = 60; // 회복량 데미지 전달
    }

    IEnumerator GuageEffect()
    {
        GameObject guageEftObj = Instantiate(guageEft); // 생성할 게이지이펙트 오브젝트
        guageEftObj.transform.position = guageEftPos.position;  //생성할 위치
        yield return new WaitForSeconds(0.5f);
        Destroy(guageEftObj);
    }

    IEnumerator HitEffect()
    {
        GameObject hitEft = Instantiate(hitEffect, hitEffectPos.position, Quaternion.identity);
        hitEft.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Destroy(hitEft);
        hitEft.SetActive(false);
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
        
        //모든플레이어가 사망했을때는 failUI 띄워주려고
        playerHp.PlayerAllHp();

        yield return null;
    }
}
