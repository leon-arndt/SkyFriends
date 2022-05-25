using UnityEngine;

public class CameraWorldInteractor : MonoBehaviour
{
    [SerializeField] private SkillSystem skillSystem;
    
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                skillSystem.Gain(SkillType.Destruction, 1);
                Destroy(hit.transform.gameObject);
            }
        }
        else
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = hit.point.Round();
                
                skillSystem.Gain(SkillType.Construction, 1);
            }
        }
    }
}