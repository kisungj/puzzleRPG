using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    enum EnemyState
    {
        IDLE,
        ATTACK,
        HIT,
        DIE
    }

    EnemyState enemyState;

    public float hp = 0;
    private float maxHp = 500.0f;
    private GameObject fhpBar;
    private GameObject fhpText;

    //공격 상태 딜레이
    float currentTime = 0;
    float attackDelay = 3.0f;
    public int Power = 30;

    [SerializeField]
    private Text hpText;
    public Slider hpSlider;
    public Image floorImage;

    Animator enemyAni;
    //플레이어는 5명이라 배열로
    private GameObject[] player;

    void Start()
    {
        enemyState = EnemyState.ATTACK;

        hpSlider.value = hp / maxHp;
        hpText.text = hp + " / " + maxHp;

        //해당 오브젝트 이름 찾아준다.
        fhpBar = GameObject.Find("UICanvas/EnemyUI/HpBar");
        fhpText = GameObject.Find("UICanvas/EnemyUI/HpText");
        //태그로 이름찾는건데 objects라 배열임
        player = GameObject.FindGameObjectsWithTag("PLAYER");

        enemyAni = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //오브젝트에 따른 위치 이동 (월드좌표를 화면좌표로 변환시켜준다)
        fhpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -0.2f, 0));
        fhpText.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -0.2f, 0));
        floorImage.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -0.1f, 0));

        switch (enemyState)
        {
            case EnemyState.IDLE:
                Idle();
                break;
            case EnemyState.ATTACK:
                Attack();
                break;
            case EnemyState.HIT:
                Hit();
                break;
            case EnemyState.DIE:
                Die();
                break;
        }
    }

    //아이들 상태
    void Idle()
    {
        //
    }

    //공격 상태
    void Attack()
    {
        currentTime += Time.deltaTime;
        if(currentTime > attackDelay)
        {
            Debug.Log("보스 공격");
            currentTime = 0;
            enemyAni.SetTrigger("ScreamToAttack");

            //랜덤값으로 플레이어 찾기
            int RanNum = Random.Range(0, 5);
            player[RanNum].GetComponent<PlayerHit>().hitDamage(Power);
        }
    }

    //enemy 공격받고 있는 상태
    public void HitEnemy(int damage)
    {
        //만약에 enemy가 맞고 있거나 죽은 상태면 함수를 실행하지 않는다.
        if (enemyState == EnemyState.HIT || enemyState == EnemyState.DIE)
        {
            return;
        }

        hp -= damage;

        //HP가 남아있으면
        if (hp > 0)
        {
            enemyState = EnemyState.HIT;

            enemyAni.SetTrigger("");
            Damage();
        }
        //죽은 상태로 넘기기
        else
        {
            enemyState = EnemyState.DIE;

            enemyAni.SetTrigger("Die");
            Die();

        }
    }

    void Damage()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        //피격 모션 기다리게 해준다.
        yield return new WaitForSeconds(1.0f);

        enemyState = EnemyState.IDLE;
    }

    //히트 상태
    void Hit()
    {

    }

    //죽음 상태
    void Die()
    {
        //진행 중일 수 있는 피격 모션 코루틴을 중지시킴
        StopAllCoroutines();
    }
}
