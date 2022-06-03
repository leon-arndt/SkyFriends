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
                FindObjectOfType<InputCamera>().enabled = !FindObjectOfType<InputCamera>().enabled;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
                Resources.FindObjectsOfTypeAll<MathQuestionOverlay>().FirstOrDefault()?.gameObject.ToggleActive();
            }
        }
    }
}