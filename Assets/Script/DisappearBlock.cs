using UnityEngine;
using System.Collections;

public class DisappearBlock : MonoBehaviour
{
    public float disappearDelay = 1f; // ������� ��� �ð�

    private bool isSteppedOn = false;

    void OnCollisionEnter(Collision collision)
    {
        // �÷��̾ ������ ��Ҵ��� Ȯ�� (y�� ��ġ�� Ȯ�� ����)
        if (collision.gameObject.CompareTag("Player") && !isSteppedOn)
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            if (collisionPoint.y > transform.position.y)
            {
                isSteppedOn = true;
                StartCoroutine(DisappearAfterDelay());
            }
        }
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(disappearDelay); // ��� �ð� ��
        gameObject.SetActive(false); // �� ��Ȱ��ȭ
    }
}
