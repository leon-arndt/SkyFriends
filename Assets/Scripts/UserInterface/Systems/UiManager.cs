using Events;
using UniRx;
using UnityEngine;

namespace UserInterface.Systems
{
	public class UiManager : MonoBehaviour
	{
		[SerializeField] private UiConfig[] uiConfigs;

		private void Start()
		{
			MessageBroker.Default.Receive<ShowUi>().TakeUntilDestroy(gameObject).Subscribe(ShowUi);
		}

		[System.Serializable]
		public struct UiConfig
		{
			public UiType type;
			public GameObject uiObject;
		}

		private void ShowUi(ShowUi ui)
		{
			foreach (var uiConfig in uiConfigs)
			{
				if (uiConfig.type == ui.type)
				{
					uiConfig.uiObject.SetActive(true);
					return;
				}
			}
		}
	}
}
