using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Overlay
{
    public class MathAnswerView : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private TextMeshProUGUI answerText;

        public bool State { get; private set; }

        private void Start()
        {
            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener(ToggleState);
        }

        public void SetText(string text)
        {
            answerText.text = text;
        }
        
        private void ToggleState(bool isOn)
        {
            State = isOn;
        }

        public void DisableToggle()
        {
            toggle.isOn = false;
        }
    }
}