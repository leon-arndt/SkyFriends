using UnityEngine;

public class InputMovable : MonoBehaviour
{
    public ScriptableVector3 value;

    private void Start()
    {
        value.value = transform.position;
    }

    private void Update()
    {
        const float moveSpeed = 0.1f;
        var mainCamera = Camera.main.transform;
        var moveDir = Input.GetAxis("Horizontal") * mainCamera.transform.right +
                      Input.GetAxis("Vertical") * mainCamera.forward;
        moveDir.y = 0;
        value.value += moveSpeed * moveDir;
        transform.position = value.value;
    }
}