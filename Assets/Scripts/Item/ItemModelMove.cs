using UnityEngine;

public class ItemModelMove : MonoBehaviour
{
    public float moveSpeed = 3f; // ���Ʒ� �̵� �ӵ�
    public float moveDistance = 0.2f; // ���Ʒ��� �̵��� �Ÿ�
    public float rotationSpeed = 45f; // ȸ�� �ӵ�

    private Vector3 startPosition;

    void Start()
    {
        // ���� ��ġ�� ����
        startPosition = transform.position;
    }

    void Update()
    {
        // ���Ʒ��� �ݺ������� �̵�
        float newY = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);

        // ���������� ȸ��
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Y���� �߽����� ȸ��
    }
}
