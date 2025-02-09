using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Player_Input playerInput;
    private Player_Input.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new Player_Input();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.processMove(onFoot.Newaction.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
