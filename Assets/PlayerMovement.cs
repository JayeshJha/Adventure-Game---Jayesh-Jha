using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public Animator Anim;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Horizontal input
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1f); // Optional: prevents faster diagonal movement
        move = transform.TransformDirection(move);
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            Anim.SetTrigger("jump");
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
        Anim.SetFloat("speed",finalMove.magnitude);    }
}
