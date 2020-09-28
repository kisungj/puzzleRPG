using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMove : MonoBehaviour
{
    private Rigidbody2D rigibody;

    [SerializeField]
    private float speed;
    private Transform target;

    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        //목표물 찾기
        target = GameObject.Find("EnemyManager/Dragon").transform;
    }

    private void FixedUpdate()
    {
        // 타겟의 방향 계산(타겟의 위치 - 미사일(나)의 위치)
        Vector2 direction = target.position - transform.position;
        rigibody.velocity = direction.normalized * speed;

        //Mathf.Atan2(높이, 밑변) -> 각도 산출
        //Mathf.Rad2Deg -> 라디안을 각도로 변환
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Quaternion.AngleAxis(회전할 각도, 기준이 되는 각도)
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
