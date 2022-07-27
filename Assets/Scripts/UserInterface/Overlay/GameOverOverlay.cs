using UnityEngine;

namespace UserInterface.Overlay
{
	public class GameOverOverlay : MonoBehaviour
	{
		private void OnEnable()
		{
			var hideAfterSeconds = 2f;
			Invoke(nameof(Disable), hideAfterSeconds);
		}

		private void Disable()
		{
			gameObject.SetActive(false);
		}
	}
}
