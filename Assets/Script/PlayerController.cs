using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;           // �̵� �ӵ�
    public float jumpForce = 7f;           // ���� ��
    public LifeManager lifeManager;        // LifeManager ��ũ��Ʈ ����
    public GameObject gameOverPanel;       // ���� ���� �г�

    private Rigidbody rb;                  // Rigidbody ������Ʈ
    private int jumpCount = 0;             // �̴� ������ ���� ���� Ƚ��
    private bool canTakeDamage = true;     // ���� ���� ���� ����
    public float damageCooldown = 2f;      // ���� ���� ��Ÿ��
    private Coroutine damageCoroutine;     // ���� ���ҿ� �ڷ�ƾ ����

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ ��������
        Time.timeScale = 1;             // ���� ���� �� �ð��� �������� ����
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // ���� ���� �г� �����
    }

    void Update()
    {
        Move();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && jumpCount < 2)
        {
            Jump();
        }

        if (transform.position.y < -10f)
        {
            GameOver();
            Debug.Log("Game Over: �÷��̾ �߶��߽��ϴ�."); // �߶����� ���� ���� ���� �α�
        }
    }

    void Move()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveDirection, 0, 0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpCount++;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            // ground�� ����� ���� jumpCount �ʱ�ȭ
            jumpCount = 0;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            // ��ֹ��� ����� �� ���� ���� �� jumpCount �ʱ�ȭ
            TakeDamage(2);
            Debug.Log("��ֹ� �浹: �÷��̾ ��ֹ��� ��� ���� 2 ����"); // ��ֹ� �浹 �α�
            jumpCount = 0; // ��ֹ� �������� ���� �����ϵ��� �ʱ�ȭ
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Vector3 collisionPoint = other.contacts[0].point;

            if (collisionPoint.y < transform.position.y - 0.2f && rb.velocity.y < 0)
            {
                // ���� ����� ���� �� ����
                Destroy(other.gameObject);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                Debug.Log("�� ����: �÷��̾ ���� ��ҽ��ϴ�."); // �� ��� �α�
            }
            else if (canTakeDamage)
            {
                // ���� �浹���� �� ���� ����
                damageCoroutine = StartCoroutine(DamageOverTime());
            }
        }
    }


    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    IEnumerator DamageOverTime()
    {
        while (true)
        {
            TakeDamage(1);
            yield return new WaitForSeconds(damageCooldown);
        }
    }

    void TakeDamage(int amount)
    {
        if (lifeManager != null)
        {
            lifeManager.TakeDamage(amount); // LifeManager���� ���� ���� ó��
            Debug.Log("�÷��̾ ���� �浹�Ͽ� ���� ����"); // ���� ���� �α�
            if (lifeManager.lives <= 0)
            {
                GameOver();
            }
        }
    }


    void GameOver()
    {
        Debug.Log("Game Over: �÷��̾��� ������ ��� �����Ǿ����ϴ�."); // ���� ���� �α�
        Time.timeScale = 0;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
