using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;

    [Header("카메라 높이 조절")]
    public float yOffset = 5f;

    [Header("부드럽게 따라가기")]
    public float smoothSpeed = 20f;

    private float fixedX;
    private float fixedZ;

    void Start()
    {
        Application.targetFrameRate = 60;
        fixedX = transform.position.x;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(
            fixedX,
            player.position.y + yOffset,
            fixedZ
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
