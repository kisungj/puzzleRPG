using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatAI : MonoBehaviour
{
    enum EnemyState
    {
        IDLE,
        IDLEBATTLE,
        ATTACK,
        FULLATTACK,
        HIT,
        DIE
    }

    EnemyState enemyState;

    public float hp = 0;
    public float maxHp = 700.0f;
    private float guage = 0;
    public float maxGuage = 100.0f;
    private GameObject fHpBar;
    private GameObject fHpText;
    private GameObject fGuageBar;
    public GameObject[] skill;
    public GameObject stageClear;

    //공격 상태 딜레이
    float currentTime = 0;
    float attackDelay = 3.0f;

    [SerializeField]
    private Text hpText;
    public Slider hpSlider;
    public Slider guageSlider;
    public Image floorImage;

    Animator enemyAni;
    //플레이어는 5명이라 배열로
    private GameObject[] player;

    //카메라 클래스를 저장할 변수
    private CameraShake shake;
    private testCamera tecamera;

    //emission 클래스를 저장할 변수
    private Emission emission;

    //에너미 히트 데미지 text하고 위치
    public GameObject hudDamageText;
    public Transform hudPos;

    //사운드
    [SerializeField]
    private BgmOn bgmOn;

    void Start()
    {
        enemyState = EnemyState.IDLE;

        //해당 오브젝트 이름 찾아준다.
        fHpBar = GameObject.Find("UICanvas/EnemyUI/HpBar");
        fHpText = GameObject.Find("UICanvas/EnemyUI/HpText");
        fGuageBar = GameObject.Find("UICanvas/EnemyUI/GuageBar");

        //태그로 이름찾는건데 objects라 배열임
        player = GameObject.FindGameObjectsWithTag("PLAYER");

        enemyAni = gameObject.GetComponent<Animator>();

        //emission 스크립트 호출
        emission = GameObject.Find("EnemyManager/Bat/Bat").GetComponent<Emission>();
    }

    void Update()
    {
        hpSlider.value = hp / maxHp;
        hpText.text = hp + " / " + maxHp;
        guageSlider.value = guage / maxGuage;

        //오브젝트에 따른 위치 이동 (월드좌표를 화면좌표로 변환시켜준다)
        fHpBar.transform.position = Camera.main.ScreenToViewportPoint(hudPos.transform.position + new Vector3(0, 2630.2f, 0));
        fHpText.transform.position = Camera.main.ScreenToViewportPoint(hudPos.transform.position + new Vector3(0, 2630.2f, 0));
        fGuageBar.transform.position = Camera.main.ScreenToViewportPoint(hudPos.transform.position + new Vector3(0, 2470.0f, 0));

        switch (enemyState)
        {
            case EnemyState.IDLE:
                Idle();
                break;
            case EnemyState.IDLEBATTLE:
                IDLEBATTLE();
                break;
            case EnemyState.ATTACK:
                Attack();
                break;
            case EnemyState.HIT:
                //Hit();
                break;
            case EnemyState.DIE:
                Die();
                break;
        }
    }

    //아이들 상태
    void Idle()
    {
        enemyState = EnemyState.IDLEBATTLE;
    }

    //아이들 전투 상태
    void IDLEBATTLE()
    {
        enemyState = EnemyState.ATTACK;
    }

    //공격 상태
    void Attack()
    {
        currentTime += Time.deltaTime;
        if (currentTime > attackDelay)
        {
            currentTime = 0;
            enemyAni.SetTrigger("IdleToAttack");
            //공격 할때마다 게이지 채우기
            guage += 20.0f;
            //랜덤값으로 플레이어 찾기
            int RanNum = Random.Range(0, 5);
            //에너미 공격력 랜덤
            int enemyAttack = Random.Range(20, 40);
            player[RanNum].GetComponent<PlayerHit>().hitDamage(enemyAttack);
        }
    }

    //enemy 공격받고 있는 상태
    public void HitEnemy(int damage)
    {
        //만약에 enemy가 맞고 있거나 죽은 상태면 함수를 실행하지 않는다.
        if (/*enemyState == EnemyState.HIT || */enemyState == EnemyState.DIE)
        {
            return;
        }

        hp -= damage;

        //에너미 히트 텍스트 보이게하려구..
        GameObject hudText = Instantiate(hudDamageText); // 생성할 텍스트 오브젝트
        hudText.transform.position = hudPos.position; // 표시될 위치
        hudText.GetComponent<DamageText>().damage = -damage; // 데미지 전달

        //에너미 shader emission 조절
        StartCoroutine(emission.ObjEmission());

        //HP가 남아있으면
        if (hp > 0)
        {
            enemyState = EnemyState.HIT;

            enemyAni.SetTrigger("Hit");
            Hit();
        }
        //죽은 상태로 넘기기
        else
        {
            hp = 0;

            enemyState = EnemyState.DIE;

            enemyAni.SetTrigger("Die");
            Die();
        }
    }

    //히트 상태
    void Hit()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        //피격 모션 기다리게 해준다.
        yield return new WaitForSeconds(1.0f);

        enemyState = EnemyState.IDLEBATTLE;
    }

    //죽음 상태
    void Die()
    {
        StartCoroutine(DieProcess());
        //진행 중일 수 있는 피격 모션 코루틴을 중지시킴
        //StopAllCoroutines();
    }

    IEnumerator DieProcess()
    {
        //bgmOn.Audio();

        yield return new WaitForSeconds(3.5f);

        stageClear.SetActive(true);
    }
}
