using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Vector3 startPos; // 시작 위치
    public Vector3 endPos;   // 끝 위치
    public float speed = 2f; // 이동 속도

    private bool movingToEnd = true;

    void Start()
    {
        // 블럭의 시작 위치를 설정합니다.
        startPos = transform.position;
    }

    void Update()
    {
        // 현재 위치와 목표 위치 간의 거리를 계산합니다.
        Vector3 targetPos = movingToEnd ? endPos : startPos;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // 목표 위치에 도달하면 방향을 반대로 설정합니다.
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            movingToEnd = !movingToEnd;
        }
    }
}
