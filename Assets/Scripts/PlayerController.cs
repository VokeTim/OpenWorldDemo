using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5;

    private InputActionMap playerInputActionMap;

    private InputAction moveAction;

    private InputAction attackAction;

    private void Awake()
    {
        playerInputActionMap = new InputActionMap("PlayerInputAction");
        moveAction = playerInputActionMap.AddAction("move");
        attackAction = playerInputActionMap.AddAction("attack");
    }

    private void OnEnable()
    {
        playerInputActionMap.Enable();
    }

    private void Start()
    {
        moveAction.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Left", "<Keyboard>/a")
            .With("Down", "<Keyboard>/s")
            .With("Right", "<Keyboard>/d");
        attackAction.AddBinding("<Mouse>/leftButton");
        attackAction.performed += OnAttackCallbackContext;
    }

    private void Update()
    {
        Vector2 getMoveInput = moveAction.ReadValue<Vector2>();
        if(getMoveInput != Vector2.zero) 
        {
            Vector3 moveDir = new Vector3(getMoveInput.x, 0, getMoveInput.y);
            transform.Translate(moveDir * MoveSpeed * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        playerInputActionMap.Disable();
    }

    private void OnAttackCallbackContext(InputAction.CallbackContext context)
    {
        Debug.Log("Attack");
    }
}
