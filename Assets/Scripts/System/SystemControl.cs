using OpenWorld.System.InputSystem;
using UnityEngine.InputSystem;

namespace OpenWorld
{
    public class SystemControl
    {
        private BaseInputAction actions;

        public void InitMoveAction(ref InputAction moveAction)
        {
            actions = new MoveInputAction();
            actions.IinitAction().Init(ref moveAction);
        }

        public void InitAttackAction(ref InputAction attackAction)
        {
            actions = new AttackInputAction();
            actions.IinitAction().Init(ref attackAction);
        }

        public void InitCameraMoveInputAction(ref InputAction cameramoveInputAction) 
        {
            actions = new CameraMoveInputAction();
            actions.IinitAction().Init(ref cameramoveInputAction);
        }

        public void InitCursorCtrlInputAction(ref InputAction cursorCtrlInputAction) 
        {
            actions = new CursorCtrlInputAction();
            actions.IinitAction().Init(ref cursorCtrlInputAction);
        }

    }
}