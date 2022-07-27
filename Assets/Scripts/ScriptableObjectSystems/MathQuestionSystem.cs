using System.Collections.Generic;
using System.Linq;
using Networking;
using Networking.Requests;
using Newtonsoft.Json;
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
			NetworkRequest.Create(new GetMathQuestions(), ApplyQuestions);

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

		private void ApplyQuestions(NetworkResponse networkResponse)
		{
			if (networkResponse.status == ResponseStatus.Error) return;

			Debug.Log($"Apply Questions: {networkResponse.message}");
			onlineQuestions = new List<MathQuestion>();
			var questionsResponse = new QuestionsResponse();
			JsonConvert.PopulateObject(networkResponse.message, questionsResponse);
			Debug.Log($"Deserialized Questions Count: {questionsResponse.questions.Count}");
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

		[System.Serializable]
		public struct QuestionsResponse
		{
			public List<JsonQuestion> questions;
		}

		[System.Serializable]
		public struct JsonQuestion
		{
			public string id;
			public QuestionData question_data;
		}

		[System.Serializable]
		public struct QuestionData
		{
			public string question;
			public string answerText1;
			public string answerText2;
			public string answerText3;
			public string answerText4;
			public bool correct1;
			public bool correct2;
			public bool correct3;
			public bool correct4;
		}
	}
}
