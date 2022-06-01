using UnityEngine;
using Random = UnityEngine.Random;

namespace ScriptableObjectSystems
{
    [CreateAssetMenu(menuName = "MathQuestionSystem")]
    public class MathQuestionSystem : ScriptableObject
    {
        [SerializeField] private SkillSystem skillSystem;
        [SerializeField] private MathQuestion currentQuestion;
        [SerializeField] private MathQuestion[] possibleQuestions;

        private void OnEnable()
        {
            GetNewQuestion();
        }

        public void Answer(bool[] playerAnswer)
        {
            uint gainedExperience = 0;
            uint experienceForAnswer = 10;

            for (var index = 0; index < currentQuestion.answers.Length; index++)
            {
                var question = currentQuestion.answers[index];
                if (question.isCorrect == playerAnswer[index])
                {
                    gainedExperience += experienceForAnswer;
                }
            }

            skillSystem.Gain(SkillType.Math, gainedExperience);
            GetNewQuestion();
        }

        private void GetNewQuestion()
        {
            if (possibleQuestions.Length == 0)
            {
                Debug.LogError("No questions in the list");
                return;
            }
            var randomIndex = Random.Range(0, possibleQuestions.Length);
            currentQuestion = possibleQuestions[randomIndex];
        }

        public string GetQuestion()
        {
            return currentQuestion.question;
        }

        public PossibleAnswer[] GetPossibleAnswer()
        {
            return currentQuestion.answers;
        }
    }
}