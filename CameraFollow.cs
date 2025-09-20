using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget; // Ship to follow
    public Vector3 offset = new Vector3(2.14748f, 4.93915f, -7.951265f); // Default offset behind the ship
    public bool enableFreeLook = true;

    [Header("Mouse Look")]
    float xRotation = 0f;
    float yRotation = 0f;

    float maxPitch = 85f;
    float minPitch = -30f;

    public float smoothCameraSpeed = 10f;

    void LateUpdate()
    {
        if(cameraTarget == null) return;

        // Smooth follow using offset
        Vector3 desiredPosition = cameraTarget.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothCameraSpeed * Time.deltaTime);
    }

    public void AdjustRotation(float speedY, float speedX)
    {
        if(!enableFreeLook) return;

        speedX *= Time.deltaTime;
        speedY *= Time.deltaTime;

        xRotation += speedX;
        yRotation += speedY;

        xRotation = Mathf.Clamp(xRotation, minPitch, maxPitch);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}