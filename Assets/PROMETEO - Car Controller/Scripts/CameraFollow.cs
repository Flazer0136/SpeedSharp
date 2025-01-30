using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform carTransform; // Reference to the car's Transform
    public Vector3 offset; // Offset from the car
    public float followSpeed = 5f; // Speed at which the camera follows the car
    public float rotationSpeed = 5f; // Speed at which the camera aligns with the car's rotation

    private void LateUpdate()
    {
        if (carTransform == null) return;

        // Smoothly follow the car's position
        Vector3 targetPosition = carTransform.position + carTransform.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Smoothly rotate to align with the car's direction
        Quaternion targetRotation = Quaternion.LookRotation(carTransform.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
