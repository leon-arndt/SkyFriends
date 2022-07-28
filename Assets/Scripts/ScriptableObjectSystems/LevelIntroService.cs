using UnityEngine;
using WorldEntity;

namespace ScriptableObjectSystems
{
	/// <summary>
	/// Used when players start a new round
	/// </summary>
	[CreateAssetMenu(menuName = "Services/" + nameof(LevelIntroService))]
	public class LevelIntroService : ScriptableObject, IResettable
	{
		public void Reset()
		{
			var levelIntro = FindObjectOfType<LevelIntroGroup>();

			foreach (var pickup in levelIntro.Pickups)
			{
				pickup.gameObject.SetActive(true);
			}
		}
	}
}
