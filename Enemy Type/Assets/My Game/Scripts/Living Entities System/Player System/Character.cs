using UnityEngine;
using PlayerSystem.CharacterControllerSystem;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour, IControllable
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _jumpForce = 3f;
        [Space(10)]
        [SerializeField] private Transform _bodyChaaracter;
        [Space(10)]
        [SerializeField] private Transform _chekerGroundPos;
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private float _chekerRadius;

        private Rigidbody2D _rb;
        private float _moveInput;
        private Vector2 _lookRight;
        private Vector2 _lookLeft;
        private bool _isJump;
        private bool _isGround;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();

            _lookRight = new Vector3(0, 0, 0);
            _lookLeft = new Vector3(0, 180, 0);
        }
        private void FixedUpdate()
        {
            _isGround = IsOnTheGround();
            _isJump = IsJumping;

            if (_isGround && _isJump)
            {
                Jump();
            }

            MoveToInternal();
        }

        public void MoveTo(float moveInput)
        {
            _moveInput = moveInput;
        }
        private void MoveToInternal()
        {
            _rb.velocity = new Vector2(_moveInput * _speed, _rb.velocity.y);

            FlipBody(_moveInput);
        }
        public void FlipBody(float moveInput)
        {
            if (moveInput > 0)
                _bodyChaaracter.eulerAngles = _lookRight;
            else if (moveInput < 0)
                _bodyChaaracter.eulerAngles = _lookLeft;
        }

        public bool IsJumping { get => _isJump; set => _isJump = value; }
        public bool IsGound { get => _isGround;}
        public void Jump()
        {
            _rb.velocity = Vector2.up * _jumpForce;
        }
        private bool IsOnTheGround()
        {
            bool result = Physics2D.OverlapCircle(_chekerGroundPos.position, _chekerRadius, _whatIsGround);
            return result;
        }
    }
}