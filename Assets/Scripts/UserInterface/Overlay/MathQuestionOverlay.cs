using System.Collections.Generic;
using ScriptableObjectSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Overlay
{
    public class MathQuestionOverlay : MonoBehaviour
    {
        [SerializeField] private MathQuestionSystem mathQuestionSystem;
        [SerializeField] private MathAnswerView[] questions;
        [SerializeField] private TextMeshProUGUI questionText;
        [SerializeField] private Button confirmButton;

        private void Start()
        {
            ShowCurrentQuestion();
        }

        private void ShowCurrentQuestion()
        {
            for (var index = 0; index < questions.Length; index++)
            {
                var questionView = questions[index];
                var answer = mathQuestionSystem.GetPossibleAnswer();
                if (index >= 0 && index < answer.Length)
                {
                    questionView.DisableToggle();
                    questionView.SetText(answer[index].answer);
                }
            }

            questionText.text = mathQuestionSystem.GetQuestion();
            confirmButton.onClick.RemoveAllListeners();
            confirmButton.onClick.AddListener(SubmitAnswer);
        }

        private void SubmitAnswer()
        {
            var answers = new List<bool>();
            foreach (var questionView in questions)
            {
                answers.Add(questionView.State);
            }

            mathQuestionSystem.Answer(answers.ToArray());
            ShowCurrentQuestion();
        }
    }
}