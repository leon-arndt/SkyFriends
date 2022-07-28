using GameInput;
using ScriptableObjectSystems;
using UnityEngine;

namespace GenericComponents
{
	public class MusicZone : MonoBehaviour
	{
		[SerializeField] private MusicService musicService;
		[SerializeField] private MusicService.TrackType trackType;

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<InputMovable>() != null)
			{
				musicService.Play(trackType);
			}
		}
	}
}
