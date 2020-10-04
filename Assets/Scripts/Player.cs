using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject[] skill;
    private GameObject[] enemy;
    private GameObject[] playerHit;

    public GameObject position;

    void Start()
    {
        //태그가 ENEMY인 오브젝트를 찾음
        enemy = GameObject.FindGameObjectsWithTag("ENEMY");

        //태그로 이름찾는건데 objects라 배열임
        playerHit = GameObject.FindGameObjectsWithTag("PLAYER");
    }

    //플레이어1 스킬 생성
    public void PlayerSkill()
    {
        //현재 선택한? 게임오브젝트의 이름을 가져온다.
        GameObject btnName = EventSystem.current.currentSelectedGameObject;

        //일치하는 플레이어의 스킬을 지정하고 생성.
        //모두 코루틴으로 생성하고 삭제하기
        if (btnName.name == "Player1")
        {
            StartCoroutine(Player1Skill());
        }
        else if (btnName.name == "Player2")
        {
            StartCoroutine(Player2Skill());
        }
        else if (btnName.name == "Player3")
        {
            StartCoroutine(Player3Skill());
        }
        else if (btnName.name == "Player4")
        {
            StartCoroutine(Player4Skill());
        }
        else
        {
            StartCoroutine(Player5Skill());
        }
    }

    IEnumerator Player1Skill()
    {
        //플레이어 공격력 랜덤
        int playerAtt = Random.Range(30, 40);
        GameObject skill1 = Instantiate(skill[0], transform.position + new Vector3(-3.1f, -3.5f, 0), Quaternion.identity);
        enemy[0].GetComponent<EnemyAI>().HitEnemy(playerAtt);
        //플레이어 스킬 사용 후 게이지 초기화
        playerHit[0].GetComponent<PlayerHit>().guage = 0;

        yield return new WaitForSeconds(3.0f);
        Destroy(skill1);
    }

    IEnumerator Player2Skill()
    {
        //플레이어 공격력 랜덤
        int playerAtt = Random.Range(30, 40);
        GameObject skill2 = Instantiate(skill[1], transform.position + new Vector3(0, 3.5f, 0), Quaternion.identity);
        enemy[0].GetComponent<EnemyAI>().HitEnemy(playerAtt);
        playerHit[1].GetComponent<PlayerHit>().guage = 0;

        yield return new WaitForSeconds(2.0f);
        Destroy(skill2);
    }

    IEnumerator Player3Skill()
    {
        //플레이어 공격력 랜덤
        int playerAtt = Random.Range(30, 40);
        GameObject skill3 = Instantiate(skill[2], transform.position + new Vector3(0, -3.5f, 0), Quaternion.identity);
        enemy[0].GetComponent<EnemyAI>().HitEnemy(playerAtt);
        playerHit[2].GetComponent<PlayerHit>().guage = 0;

        yield return new WaitForSeconds(2.0f);
        Destroy(skill3);
    }

    IEnumerator Player4Skill()
    {
        //플레이어 공격력 랜덤
        int playerAtt = Random.Range(30, 40);
        GameObject skill4 = Instantiate(skill[3], transform.position + new Vector3(1.5f, -3.5f, 0), Quaternion.identity);
        enemy[0].GetComponent<EnemyAI>().HitEnemy(playerAtt);
        playerHit[3].GetComponent<PlayerHit>().guage = 0;

        yield return new WaitForSeconds(2.0f);
        Destroy(skill4);
    }

    IEnumerator Player5Skill()
    {
        //플레이어 공격력 랜덤
        int playerAtt = Random.Range(30, 40);
        GameObject skill5 = Instantiate(skill[4], transform.position + new Vector3(0, 3.5f, 0), Quaternion.identity);
        enemy[0].GetComponent<EnemyAI>().HitEnemy(playerAtt);
        playerHit[4].GetComponent<PlayerHit>().guage = 0;

        yield return new WaitForSeconds(3.0f);
        Destroy(skill5);
    }
}
