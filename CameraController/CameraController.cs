using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;        // 相机移动速度
    public float rotationSpeed = 50f;   // 相机转动速度
    public float zoomSpeed = 10f;       // 相机缩放速度
    public float minZoomDistance = 5f;  // 相机最小缩放距离
    public float maxZoomDistance = 50f; // 相机最大缩放距离

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleScroll();
    }

    // 控制镜头平移逻辑
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

    // 控制镜头旋转逻辑
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

    // 控制镜头缩放逻辑
    private void HandleScroll()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Vector3 zoomDir = transform.forward * scroll * zoomSpeed;
            Vector3 newPos = transform.position + zoomDir;

            float distanceFromOrigin = Vector3.Distance(newPos, Vector3.zero); // 可替换为目标点
            if (distanceFromOrigin >= minZoomDistance && distanceFromOrigin <= maxZoomDistance)
            {
                transform.position = newPos;
            }
        }
    }
}
