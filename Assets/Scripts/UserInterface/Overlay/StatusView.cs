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

        private enum AtmosphereLayer
        {
	        Troposphere,
	        Stratosphere,
	        Mesosphere,
	        Thermosphere,
	        Exosphere,
	        Unknown
        }

        private void Start()
        {
            Refresh();
            Observable.Interval(TimeSpan.FromSeconds(0.1f))
                .TakeUntilDestroy(this)
                .Subscribe(_ =>Refresh());
        }

        private void Refresh()
        {
            var roundedAltitude = Mathf.Round(playerPosition.value.y);
            var currentAtmosphereLayer = (AtmosphereLayer)(roundedAltitude / 10);
            playerPositionText.text = $"Altitude: {roundedAltitude} ({currentAtmosphereLayer.ToString()})";
        }
    }
}
