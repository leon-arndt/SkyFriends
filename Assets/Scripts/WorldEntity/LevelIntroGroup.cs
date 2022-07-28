using System.Collections.Generic;
using UnityEngine;

namespace WorldEntity
{
	public class LevelIntroGroup : MonoBehaviour
	{
		[SerializeField] private List<Pickup> pickups;
		public IReadOnlyList<Pickup> Pickups => pickups;
	}
}
