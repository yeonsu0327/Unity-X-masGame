using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;           // ������ �÷��̾�
    public float speed = 2f;           // ���� �̵� �ӵ�
    public float followDistance = 0.5f; // �÷��̾���� �ּ� �Ÿ�
    public float minX = -5f;           // X�� �ּ� ����
    public float maxX = 5f;            // X�� �ִ� ����
    private float fixedYPosition;      // Y�� ���� ��ġ
   

    void Start()
    {
        fixedYPosition = transform.position.y; // �ʱ� Y ��ġ�� ����
    }

    void FixedUpdate()
    {
        float xDifference = player.position.x - transform.position.x;

        if (Mathf.Abs(xDifference) > followDistance)
        {
            // Y�� ����, X�ุ ���󰡵��� ����
            Vector3 targetPosition = new Vector3(player.position.x, fixedYPosition, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX); // X�� ���� ����
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
        }
    }
}
