using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectSystems
{
	[CreateAssetMenu(menuName = "ScriptableObjects/SkillTypeConfigList")]
	public class SkillTypeConfigList : ScriptableObject
	{
		public List<SkillTypeConfig> skills;
	}

	[Serializable]
	public struct SkillTypeConfig
	{
		public SkillType type;
		public Sprite icon;
	}
}
