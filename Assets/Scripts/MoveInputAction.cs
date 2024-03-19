using UnityEngine.InputSystem;

public class MoveInputAction : IInitAction
{
    public void Init(ref InputAction action)
    {
        action = new InputAction();
        action.AddCompositeBinding("2DVector")
        .With("Up", "<Keyboard>/w")
        .With("Down", "<Keyboard>/s")
        .With("Left", "<Keyboard>/a")
        .With("Right", "<Keyboard>/d");
    }
}
