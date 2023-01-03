using System.Collections.Generic;
using ScriptableObjectSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UserInterface.Overlay
{
	public class SkillView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI level;
		[SerializeField] private TextMeshProUGUI skillName;
		[SerializeField] private Image icon;

		public void Display(KeyValuePair<SkillType, SkillData> skill, Sprite sprite)
		{
			transform.Shake();
			icon.sprite = sprite;
			level.text = skill.Value.level.ToString();
			skillName.text = skill.Key.ToString();
		}
	}
}
