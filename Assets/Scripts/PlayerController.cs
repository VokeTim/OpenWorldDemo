using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5;

    private InputAction moveAction;

    private InputAction attackAction;

    private void Awake()
    {
        SystemControl systemControl = new SystemControl();
        systemControl.InitMoveAction(ref moveAction);
        systemControl.InitAttackAction(ref attackAction);
    }

    private void OnEnable()
    {
        moveAction.Enable();
        attackAction.Enable();
    }

    private void Update()
    {
        Vector2 dir = moveAction.ReadValue<Vector2>();
        transform.Translate(new Vector3(dir.x, 0, dir.y) * MoveSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        moveAction.Disable();
        attackAction.Disable();
    }
}
