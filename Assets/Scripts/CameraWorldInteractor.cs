using System;
using UniRx;
using UnityEngine;

public class CameraWorldInteractor : MonoBehaviour
{
    [SerializeField] private uint maxInteractDistance = 20;
    [SerializeField] private SkillSystem skillSystem;
    
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;

        Observable.Interval(TimeSpan.FromSeconds(10f))
            .TakeUntilDestroy(this)
            .Subscribe(_ => skillSystem.Gain(SkillType.Patience, 5));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit, maxInteractDistance))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                skillSystem.Gain(SkillType.Destruction, 1);
                Destroy(hit.transform.gameObject);
            }
        }
        else
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit, maxInteractDistance))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = hit.point.Round();
                
                skillSystem.Gain(SkillType.Construction, 1);
            }
        }
    }
}