using System.Collections.Generic;
using System.Linq;
using Networking;
using Networking.Requests;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

namespace ScriptableObjectSystems
{
	[CreateAssetMenu(menuName = "MathQuestionSystem")]
	public class MathQuestionSystem : ScriptableObject, IResettable
	{
		[SerializeField] private SkillSystem skillSystem;
		[SerializeField] private MathQuestion currentQuestion;
		[SerializeField] private MathQuestion[] possibleQuestions;
		[SerializeField] private uint avoidDuplicatesLength;
		[SerializeField] private List<MathQuestion> onlineQuestions;

		private SizedQueue<MathQuestion> _recentQuestions;

		public void Reset()
		{
			onlineQuestions = new List<MathQuestion>();
			NetworkRequest.Create(new NetworkObject
				{ doneCallback = ApplyQuestions, request = new GetMathQuestions() });

			var questions = GetAllQuestions();
			var safeMaxDuplicates = avoidDuplicatesLength <= (uint)questions.Count
				? avoidDuplicatesLength
				: (uint)questions.Count;
			_recentQuestions = new SizedQueue<MathQuestion>(safeMaxDuplicates);

			GetNewQuestion();
		}

		private void OnEnable()
		{
			Reset();
		}

		private void ApplyQuestions(string response)
		{
			onlineQuestions = new List<MathQuestion>();
			Debug.Log($"Apply Questions: {response}");
		}

		public void SubmitAnswer(bool[] playerAnswers)
		{
			uint gainedExperience = 0;
			uint experienceForAnswer = 10;

			for (var index = 0; index < currentQuestion.answers.Length; index++)
			{
				var question = currentQuestion.answers[index];
				if (question.isCorrect == playerAnswers[index])
				{
					gainedExperience += experienceForAnswer;
				}
			}

			skillSystem.Gain(SkillType.Math, gainedExperience);
			GetNewQuestion();
		}

		private void GetNewQuestion()
		{
			if (GetAllQuestions().Count == 0)
			{
				Debug.LogError("No questions in the list");
				return;
			}

			var newQuestions = new HashSet<MathQuestion>(GetAllQuestions());
			foreach (var recentQuestion in _recentQuestions)
			{
				newQuestions.Remove(recentQuestion);
			}

			var randomIndex = Random.Range(0, newQuestions.Count);
			currentQuestion = newQuestions.ToArray()[randomIndex];
			_recentQuestions.Enqueue(currentQuestion);
		}

		public string GetCurrentQuestion()
		{
			return currentQuestion.question;
		}

		public PossibleAnswer[] GetPossibleAnswer()
		{
			return currentQuestion.answers;
		}

		private IReadOnlyList<MathQuestion> GetAllQuestions()
		{
			var questions = onlineQuestions;
			questions.AddRange(possibleQuestions);
			return questions;
		}
	}
}
