using UnityEngine;

namespace GameInput
{
    public class InputMovable : MonoBehaviour
    {
        [SerializeField] private ScriptableVector3 value;
        [SerializeField] private CharacterController characterController;

        private Vector3 _playerVelocity;
        private bool _groundedPlayer;
        private Camera _camera;
        private const float PlayerSpeed = 8.0f;
        private const float JumpHeight = 2.0f;
        private const float GravityValue = -28f;

        private void Start()
        {
            _camera = Camera.main;
            value.value = transform.position;
        }

        private void Update()
        {
            GameInput.Set(InputType.Horizontal, Input.GetAxis("Horizontal"));
            GameInput.Set(InputType.Vertical, Input.GetAxis("Vertical"));

            var horizontalInput = GameInput.Get(InputType.Horizontal);
            var verticalInput = GameInput.Get(InputType.Vertical);

            if (Input.GetButtonDown("Jump") && _groundedPlayer)
            {
                Jump();
            }

            Move(horizontalInput, verticalInput);
        }

        public void Jump()
        {
            if (!_groundedPlayer) return;
            _playerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * GravityValue);
        }

        public void Move(float horizontalInput, float verticalInput)
        {
            var cameraTransform = _camera.transform;
            var cameraForward = cameraTransform.forward;
            var forwardCamOnPlane = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

            var moveDir = horizontalInput * cameraTransform.right
                          + verticalInput * forwardCamOnPlane;
            moveDir.y = 0;

            _groundedPlayer = characterController.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            characterController.Move(moveDir * (Time.deltaTime * PlayerSpeed));

            if (moveDir != Vector3.zero)
            {
                gameObject.transform.forward = moveDir;
            }

            _playerVelocity.y += GravityValue * Time.deltaTime;
            characterController.Move(_playerVelocity * Time.deltaTime);
            value.value = transform.position;
        }
    }
}