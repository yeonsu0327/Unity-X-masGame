using UnityEngine;

public class TreeOrnament : MonoBehaviour
{
    public int scoreValue = 1; // �����۴� ���� ��

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(scoreValue); // GameManager�� ���� ��� ���� �߰�
            Destroy(gameObject); // ������ ����
        }
    }
}
