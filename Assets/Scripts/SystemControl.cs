using UnityEngine;
using UnityEngine.InputSystem;

public class SystemControl
{
    public void InitMoveAction(ref InputAction moveAction) 
    {
        moveAction = new InputAction();
        moveAction.AddCompositeBinding("2DVector")
        .With("Up", "<Keyboard>/w")
        .With("Down", "<Keyboard>/s")
        .With("Left", "<Keyboard>/a")
        .With("Right", "<Keyboard>/d");
    }

    public void InitAttackAction(ref InputAction attackAction) 
    {
        attackAction = new InputAction();
        attackAction.AddBinding("<Mouse>/leftButton");
        attackAction.performed += OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("attack!");
    }
}
