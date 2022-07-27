using DG.Tweening;
using UnityEngine;

namespace Utility
{
	public static class Shaker
	{
		public static void Shake(this Transform rectTransform, float shakeDuration = 0.5f, float shakeStrength = 0.1f)
		{
			var isTweening = DOTween.IsTweening(rectTransform, true);
			if (isTweening)
			{
				return;
			}

			rectTransform.DOShakeScale(shakeDuration, shakeStrength).SetUpdate(true)
				.OnComplete(() =>
				{
					rectTransform.localScale = Vector3.one;
				});
		}
	}
}
