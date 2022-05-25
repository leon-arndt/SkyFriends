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
        var moveSpeed = 0.1f;
        value.value += moveSpeed * new Vector3(Input.GetAxis("Horizontal"), 0,  Input.GetAxis("Vertical"));
        transform.position = value.value;
    }
}