using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

namespace ScriptableObjectSystems
{
    [CreateAssetMenu(menuName = "MathQuestionSystem")]
    public class MathQuestionSystem : ScriptableObject
    {
        [SerializeField] private SkillSystem skillSystem;
        [SerializeField] private MathQuestion currentQuestion;
        [SerializeField] private MathQuestion[] possibleQuestions;
        [SerializeField] private uint avoidDuplicatesLength;

        private SizedQueue<MathQuestion> _recentQuestions;
        
        private void OnEnable()
        {
            var safeMaxDuplicates = avoidDuplicatesLength <= (uint) possibleQuestions.Length ? avoidDuplicatesLength : (uint) possibleQuestions.Length;
            _recentQuestions = new SizedQueue<MathQuestion>(safeMaxDuplicates);
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

            var newQuestions = new HashSet<MathQuestion>(possibleQuestions);
            foreach (var recentQuestion in _recentQuestions)
            {
                newQuestions.Remove(recentQuestion);
            }
            var randomIndex = Random.Range(0, newQuestions.Count);
            currentQuestion = newQuestions.ToArray()[randomIndex];
            _recentQuestions.Enqueue(currentQuestion);
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