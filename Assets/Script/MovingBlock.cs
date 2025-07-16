using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Vector3 startPos; // ���� ��ġ
    public Vector3 endPos;   // �� ��ġ
    public float speed = 2f; // �̵� �ӵ�

    private bool movingToEnd = true;

    void Start()
    {
        // ���� ���� ��ġ�� �����մϴ�.
        startPos = transform.position;
    }

    void Update()
    {
        // ���� ��ġ�� ��ǥ ��ġ ���� �Ÿ��� ����մϴ�.
        Vector3 targetPos = movingToEnd ? endPos : startPos;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ϸ� ������ �ݴ�� �����մϴ�.
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            movingToEnd = !movingToEnd;
        }
    }
}
