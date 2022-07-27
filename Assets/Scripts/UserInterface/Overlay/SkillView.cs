using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utility;

namespace UserInterface.Overlay
{
    public class SkillView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI level;

        public void Display(KeyValuePair<SkillType, SkillData> skill)
        {
	        transform.Shake();
            level.text = skill.Value.level.ToString();
        }
    }
}
