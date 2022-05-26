using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class TextMeshSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Text textMeshPro;
        
        internal void Set(float ratio, string text)
        {
            slider.value = ratio;
            textMeshPro.text = text;
        }
    }
}