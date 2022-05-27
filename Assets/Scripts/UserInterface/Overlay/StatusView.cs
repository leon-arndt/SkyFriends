using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace UserInterface.Overlay
{
    public class StatusView : MonoBehaviour
    {
        [SerializeField] private ScriptableVector3 playerPosition;
        [SerializeField] private TextMeshProUGUI playerPositionText;

        private void Start()
        {
            Refresh();
            Observable.Interval(TimeSpan.FromSeconds(1f))
                .TakeUntilDestroy(this)
                .Subscribe(_ =>Refresh());
        }

        private void Refresh()
        {
            var roundedAltitude = Mathf.Round(playerPosition.value.y);
            playerPositionText.text = $"Altitude: {roundedAltitude}";
        }
    }
}