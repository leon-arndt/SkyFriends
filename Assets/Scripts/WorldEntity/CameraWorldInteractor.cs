using System;
using UniRx;
using UnityEngine;

public class CameraWorldInteractor : MonoBehaviour
{
    [SerializeField] private SkillSystem skillSystem;
    
    private void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(10f))
            .TakeUntilDestroy(this)
            .Subscribe(_ => skillSystem.Gain(SkillType.Patience, 5));
    }
}