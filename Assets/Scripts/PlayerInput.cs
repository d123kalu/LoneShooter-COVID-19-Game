using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerInput : MonoBehaviour {
    private CharacterController controller;

    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private AnimationCurve jumpCurve; // used to control upward force
    [SerializeField] private float jumpFactor = 5.0f;

    private bool isJumping;

    private void Awake() {
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        // movement
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertical;
        Vector3 rightMovement = transform.right * horizontal;

        controller.SimpleMove(forwardMovement + rightMovement);

        // jumping
        if (Input.GetButtonDown("Jump") && !isJumping) {
            isJumping = true;
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump() {
        // avoid crawling up slopes during the jump
        controller.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        // if we are grounded and our head is not colliding with the ceiling, move upward
        do {
            // at some point, the jump amount will be less than the effects of gravity
            float jumpAmount = jumpCurve.Evaluate(timeInAir) * jumpFactor * Time.deltaTime;
            controller.Move(Vector3.up * jumpAmount);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!controller.isGrounded && controller.collisionFlags != CollisionFlags.Above);

        // reset slope limit so we can go up slopes when not jumping
        controller.slopeLimit = 45.0f;
        isJumping = false;
    }
}
