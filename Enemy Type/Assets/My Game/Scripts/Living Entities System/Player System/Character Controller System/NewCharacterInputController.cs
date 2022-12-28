using UnityEngine;
using UnityEngine.InputSystem;
using StateAnimation;

namespace PlayerSystem.CharacterControllerSystem
{
    [RequireComponent(typeof(CharacterAnimation))]
    public class NewCharacterInputController : MonoBehaviour
    {
        private IControllable _controllable;
        private GameInput _gameInput;
        private CharacterAnimation _characterAnimation;

        private void Awake()
        {
            _gameInput = new GameInput();
            _gameInput.Enable();

            _controllable = GetComponent<IControllable>();
            _characterAnimation = GetComponent<CharacterAnimation>();

            if (_controllable == null)
                throw new System.Exception($"There is no IControllable component on the object: {gameObject.name}");
        }

        private void OnEnable()
        {
            _gameInput.Gameplay.Jump.performed += OnJumpPerformed;
            _gameInput.Gameplay.Jump.canceled += OnJumpCompleted;
        }
        private void OnDisable()
        {
            _gameInput.Gameplay.Jump.performed -= OnJumpPerformed;
            _gameInput.Gameplay.Jump.canceled -= OnJumpCompleted;
        }

        private void OnJumpPerformed(InputAction.CallbackContext obj)
        {
            _controllable.IsJumping = true;
        }
        private void OnJumpCompleted(InputAction.CallbackContext obj)
        {
            _controllable.IsJumping = false;
        }

        private void Update()
        {
            ReadMovemant();
        }

        private void ReadMovemant()
        {
            var inputDirection = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
            var direction = new Vector3(inputDirection.x, 0f, 0f);

            _controllable.MoveTo(direction.x);

            ReadStateAnim(direction.x);
        }

        // Methods Read Animtions
        private void ReadStateAnim(float direction)
        {
            if (direction == 0 && _controllable.IsGound == true){
                ReadAnimIdile();
                return;
            }

            if (_controllable.IsGound == false)
            {
                ReadAnimJump();
                return;
            }

            ReadAdimMove();
        }

        private void ReadAdimMove()
        {
            _characterAnimation.SetBehaviorMove();
        }
        private void ReadAnimIdile()
        {
            _characterAnimation.SetBehaviorIdile();
        }
        private void ReadAnimJump()
        {
            _characterAnimation.SetBehaviorJump();
        }
    }
}