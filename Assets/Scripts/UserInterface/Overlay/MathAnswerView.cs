using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Overlay
{
    public class MathAnswerView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI answerText;

        public bool State { get; private set; }

        private void Start()
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(ToggleState);
        }

        public void SetText(string text)
        {
            answerText.text = text;
        }
        
        private void ToggleState()
        {
            State = !State;
        }
    }
}