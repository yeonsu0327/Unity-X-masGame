using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;           // 추적할 플레이어
    public float speed = 2f;           // 적의 이동 속도
    public float followDistance = 0.5f; // 플레이어와의 최소 거리
    public float minX = -5f;           // X축 최소 범위
    public float maxX = 5f;            // X축 최대 범위
    private float fixedYPosition;      // Y축 고정 위치
   

    void Start()
    {
        fixedYPosition = transform.position.y; // 초기 Y 위치를 고정
    }

    void FixedUpdate()
    {
        float xDifference = player.position.x - transform.position.x;

        if (Mathf.Abs(xDifference) > followDistance)
        {
            // Y축 고정, X축만 따라가도록 설정
            Vector3 targetPosition = new Vector3(player.position.x, fixedYPosition, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX); // X축 범위 제한
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
        }
    }
}
