using UnityEngine;
public class MouseLook : MonoBehaviour {
    [SerializeField] private float mouseSensitivity = 0.002f;
    [SerializeField] private Transform playerBody;

    private float verticalRotation;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;

        verticalRotation = 0.0f;
    }

    private void Update() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation += mouseY;

        if (verticalRotation > 90.0f) {
            verticalRotation = 90.0f;
            mouseY = 0.0f;
            resetVerticalRotation(270.0f);
        } else if (verticalRotation < -90.0f) {
            verticalRotation = -90.0f;
            mouseY = 0.0f;
            resetVerticalRotation(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void resetVerticalRotation(float value) {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
