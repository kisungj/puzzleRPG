﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public int playerPower = 35;

    [SerializeField]
    private GameObject[] skill;
    private GameObject[] enemy;

    public GameObject position;

    void Start()
    {
        //태그가 ENEMY인 오브젝트를 찾음
        enemy = GameObject.FindGameObjectsWithTag("ENEMY");
    }

    //플레이어 공격
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.3f);
        PlayerSkill();
    }

    //플레이어1 스킬 생성
    public void PlayerSkill()
    {
        //현재 선택한? 게임오브젝트의 이름을 가져온다.
        GameObject btnName = EventSystem.current.currentSelectedGameObject;

        //일치하는 플레이어의 스킬을 지정하고 생성.
        if (btnName.name == "Player1")
        {
            Instantiate(skill[0], transform.position + new Vector3(-3.1f, -3.5f, 0), Quaternion.identity);
            enemy[0].GetComponent<EnemyAI>().HitEnemy(playerPower);
        }
        else if(btnName.name == "Player2")
        {
            Instantiate(skill[1], transform.position + new Vector3(-1.5f, -3.5f, 0), Quaternion.identity);
            enemy[0].GetComponent<EnemyAI>().HitEnemy(playerPower);
        }
        else if(btnName.name == "Player3")
        {
            Instantiate(skill[2], transform.position + new Vector3(0, -3.5f, 0), Quaternion.identity);
            enemy[0].GetComponent<EnemyAI>().HitEnemy(playerPower);
        }
        else if(btnName.name == "Player4")
        {
            Instantiate(skill[3], transform.position + new Vector3(1.5f, -3.5f, 0), Quaternion.identity);
            enemy[0].GetComponent<EnemyAI>().HitEnemy(playerPower);
        }
        else
        {
            Instantiate(skill[4], transform.position + new Vector3(3.1f, -3.5f, 0), Quaternion.identity);
            enemy[0].GetComponent<EnemyAI>().HitEnemy(playerPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("충돌했음");

        if(coll.collider.tag == "EFFECT")
        {
            Destroy(coll.gameObject);
        }
    }
}
