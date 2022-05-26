using System;
using UniRx;
using UnityEngine;

public class CameraWorldInteractor : MonoBehaviour
{
    [SerializeField] private SkillSystem skillSystem;
    
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;

        Observable.Interval(TimeSpan.FromSeconds(10f))
            .TakeUntilDestroy(this)
            .Subscribe(_ => skillSystem.Gain(SkillType.Patience, 5));
    }
}