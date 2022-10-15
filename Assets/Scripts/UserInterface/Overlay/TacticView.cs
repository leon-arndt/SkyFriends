using System.Collections.Generic;
using Events;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Overlay
{
	public class TacticView : MonoBehaviour
	{
		[SerializeField] private ScriptableInt tacticSystem;
		[SerializeField] private TextMeshProUGUI tacticName;
		[SerializeField] private Image tacticIcon;
		[SerializeField] private Sprite[] tacticIcons;

		private void Start()
		{
			UpdateView();
			MessageBroker.Default
				.Receive<TacticChanged>()
				.TakeUntilDestroy(this)
				.Subscribe(_ => UpdateView());
		}

		private void UpdateView()
		{
			tacticName.text = ((Tactic) tacticSystem.value).ToString();
			if (tacticSystem.value >= 0 && tacticSystem.value < tacticIcons.Length)
			{
				tacticIcon.sprite = tacticIcons[tacticSystem.value];
			}
		}
	}
}
