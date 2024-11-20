using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform target; // ���� ��� (�÷��̾�)
    public Vector3 offset = new Vector3(0,12,-15);   // ī�޶�� ��� ������ �Ÿ�
    public float fallowSpeed = 5.0f;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player �±׸� ���� ������Ʈ�� ã�� �� �����ϴ�!");
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * fallowSpeed);
        }
    }
}