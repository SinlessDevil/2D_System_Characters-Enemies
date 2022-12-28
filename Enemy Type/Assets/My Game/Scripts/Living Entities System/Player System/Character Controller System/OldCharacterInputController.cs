using UnityEngine;

namespace PlayerSystem.CharacterControllerSystem
{
    public class OldCharacterInputController : MonoBehaviour
    {
        private IControllable _contollable;

        private void Awake()
        {
            _contollable = GetComponent<IControllable>();

            if (_contollable == null)
                throw new System.Exception($"There is no IControllable component on the object: {gameObject.name}");
        }
        private void Update()
        {
            ReadMove();

            ReadJump();
        }

        private void ReadMove()
        {
            var direction = Input.GetAxis("Horizontal");

            _contollable.MoveTo(direction);
        }
        private void ReadJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _contollable.IsJumping = true;
            if (Input.GetKeyUp(KeyCode.Space))
                _contollable.IsJumping = false;
        }
    }
}