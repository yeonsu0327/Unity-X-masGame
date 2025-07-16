using UnityEngine;

public class TreeStar : MonoBehaviour
{
    public int scoreValue = 1; // �� �����۴� ���� ��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddStarScore(scoreValue); // �� ���� �߰�
            Destroy(gameObject); // ������ ����
            
        }
    }
}
