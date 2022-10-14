using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 _move;
        public Vector2 _look;
        public bool _jump;
        public bool _sprint;

        [Header("Movement Settings")]
        public bool _analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool _cursorLocked = true;
        public bool _cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (_cursorInputForLook)
            {
                if (Time.timeScale > 0)
                {
                    LookInput(value.Get<Vector2>());
                }
                else
                {
                    LookInput(Vector2.zero);
                }
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

        public void OnMenu()
        {
            _cursorLocked = false;
            SetCursorState();
        }
#endif

        private void OnEnable()
        {
            _cursorLocked = true;
            SetCursorState();
        }

        public void MoveInput(Vector2 newMoveDirection)
        {
            _move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            _look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            _jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            _sprint = newSprintState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            _cursorLocked = true;
            SetCursorState();
        }

        private void SetCursorState()
        {
            Cursor.lockState = _cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}