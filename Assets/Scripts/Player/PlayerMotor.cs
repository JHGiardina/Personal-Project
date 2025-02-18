using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed;
    private bool isGrounded;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    [Header("Footstep Manager")]
    private FootstepManager footstepManager;
    public float footstepInterval;
    float curSpeed;
    private Vector3 lastPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        footstepManager = GetComponent<FootstepManager>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        PlayFootstep();
        curSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform.position;
    }

    public void processMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y <0)
        {
            playerVelocity.y = -2f; 
        }
        controller.Move(playerVelocity* Time.deltaTime);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }

    public void PlayFootstep()
    {
        footstepInterval -= Time.deltaTime;
        if (footstepInterval < 0 && curSpeed > 0.1f && isGrounded) 
        {
            footstepInterval = Random.Range(0.2f, .7f);
            footstepManager.PlayStep();
        }

    }
}
