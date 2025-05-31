using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;        // ����ƶ��ٶ�
    public float rotationSpeed = 50f;   // ���ת���ٶ�
    public float zoomSpeed = 10f;       // ��������ٶ�
    public float minZoomDistance = 5f;  // �����С���ž���
    public float maxZoomDistance = 50f; // ���������ž���

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleScroll();
    }

    // ���ƾ�ͷƽ���߼�
    private void HandleMovement()
    {
        Vector3 move = Vector3.zero;
        Vector3 inputMoveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            move += new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        }

        if (Input.GetKey(KeyCode.S))
        {
            move -= new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move -= new Vector3(transform.right.x, 0, transform.right.z).normalized;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move += new Vector3(transform.right.x, 0, transform.right.z).normalized;
        }

        transform.position += move * moveSpeed * Time.deltaTime;
    }

    // ���ƾ�ͷ��ת�߼�
    private void HandleRotation()
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = +1f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1f;
        }

        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }

    // ���ƾ�ͷ�����߼�
    private void HandleScroll()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Vector3 zoomDir = transform.forward * scroll * zoomSpeed;
            Vector3 newPos = transform.position + zoomDir;

            float distanceFromOrigin = Vector3.Distance(newPos, Vector3.zero); // ���滻ΪĿ���
            if (distanceFromOrigin >= minZoomDistance && distanceFromOrigin <= maxZoomDistance)
            {
                transform.position = newPos;
            }
        }
    }
}
