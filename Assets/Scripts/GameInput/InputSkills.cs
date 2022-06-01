using System.Linq;
using UnityEngine;
using UserInterface.Overlay;
using Utility;

namespace GameInput
{
    public class InputSkills : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Resources.FindObjectsOfTypeAll<MathQuestionOverlay>().FirstOrDefault()?.gameObject.ToggleActive();
            }
        }
    }
}