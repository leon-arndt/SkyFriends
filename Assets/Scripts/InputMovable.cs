using UnityEngine;

public class InputMovable : MonoBehaviour
{
    [SerializeField] private ScriptableVector3 value;
    [SerializeField] private CharacterController characterController;
    
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private const float PlayerSpeed = 8.0f;
    private const float JumpHeight = 2.0f;
    private const float GravityValue = -16f;

    private void Start()
    {
        value.value = transform.position;
    }

    private void Update()
    {
        var mainCamera = Camera.main.transform;
        var moveDir = Input.GetAxis("Horizontal") * mainCamera.transform.right +
                      Input.GetAxis("Vertical") * mainCamera.forward;
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

        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * GravityValue);
        }

        _playerVelocity.y += GravityValue * Time.deltaTime;
        characterController.Move(_playerVelocity * Time.deltaTime);
        value.value = transform.position;
    }
}   