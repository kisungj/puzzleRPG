using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject[] skill;

    public GameObject position;

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
        if(btnName.name == "Player1")
        {
            Instantiate(skill[0], transform.position + new Vector3(-3.1f, -3.5f, 0), Quaternion.identity);
        }
        else if(btnName.name == "Player2")
        {
            Instantiate(skill[1], transform.position + new Vector3(-1.5f, -3.5f, 0), Quaternion.identity);
        }
        else if(btnName.name == "Player3")
        {
            Instantiate(skill[2], transform.position + new Vector3(0, -3.5f, 0), Quaternion.identity);
        }
        else if(btnName.name == "Player4")
        {
            Instantiate(skill[3], transform.position + new Vector3(1.5f, -3.5f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(skill[4], transform.position + new Vector3(3.1f, -3.5f, 0), Quaternion.identity);
        }
    }
}
