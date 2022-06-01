using System;
using UnityEngine;

namespace ScriptableObjectSystems
{
    [CreateAssetMenu(menuName = "MathQuestion")]
    public class MathQuestion : ScriptableObject
    {
        public string question;
        public PossibleAnswer[] answers = new PossibleAnswer[4];
    }
    
    [Serializable]
    public struct PossibleAnswer
    {
        public string answer;
        public bool isCorrect;
    }
}