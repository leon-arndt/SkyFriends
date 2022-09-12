using ScriptableObjectSystems;
using UnityEngine;

namespace ItemTypes
{
	[CreateAssetMenu(menuName = "ScriptableObjects/ConsumableItemType")]
	public class ConsumableItemType : ScriptableObject, IHotbarItemType
	{
		[SerializeField] private StatSystem statSystem;
		[SerializeField] private HotbarSystem hotbarSystem;

		[SerializeField] private uint healAmount;
		[SerializeField] private Sprite sprite;

		public void Use()
		{
			statSystem.Gain(StatType.Health, healAmount);
			hotbarSystem.Remove(this);
		}

		public void UseAlternative()
		{
			throw new System.NotImplementedException();
		}

		public Sprite GetIcon()
		{
			return sprite;
		}
	}
}
