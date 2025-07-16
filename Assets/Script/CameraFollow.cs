using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                  // ī�޶� ���� ��� (Player)
    public Vector3 offset = new Vector3(0, 0, -10); // ī�޶���� �Ÿ� ����

    private float fixedYPosition;
    private float fixedZPosition;

    void Start()
    {
        // Y�� Z ��ġ ����
        fixedYPosition = transform.position.y;
        fixedZPosition = transform.position.z;
    }

    void LateUpdate()
    {
        // ī�޶��� ��ǥ ��ġ ���� (X���� �÷��̾ ���󰡰�, Y�� Z ���� ����)
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, fixedYPosition, fixedZPosition);

        // ī�޶� ��ġ�� ��ǥ ��ġ�� ��Ȯ�ϰ� ����
        transform.position = targetPosition;
    }
}
