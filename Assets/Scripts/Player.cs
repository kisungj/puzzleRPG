using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill4;
    public GameObject skill5;

    public Transform position;

    //플레이어 공격
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(3.0f);
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
            Instantiate(skill1, transform.position, transform.rotation);
        }
        else if(btnName.name == "Player2")
        {
            Instantiate(skill2, transform.position/* + new Vector3(0, 0, 0)*/, transform.rotation);
        }
        else if(btnName.name == "Player3")
        {
            Instantiate(skill3, transform.position, transform.rotation);
        }
        else if(btnName.name == "Player4")
        {
            Instantiate(skill4, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(skill5, transform.position, transform.rotation);
        }

    }
}
