﻿using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Utility
{
	public class Walk : MonoBehaviour
	{
		[SerializeField] NavMeshAgent agent;
		[SerializeField] private float moveHeight = 0.1f;
		[SerializeField] private float rotateAmount = 15f;

		private Tween bounceTween, rotateTween;

		private void Start()
		{
			const float bounceDuration = 0.15f;
			bounceTween = transform
				.DOLocalMoveY(moveHeight, bounceDuration)
				.SetLoops(-1, LoopType.Yoyo)
				.SetDelay(Random.value);

			transform.Rotate(Vector3.forward * -0.5f * rotateAmount, Space.Self);
			rotateTween = transform
				.DOLocalRotate(Vector3.forward * rotateAmount, 1f)
				.SetLoops(-1, LoopType.Yoyo)
				.SetDelay(Random.value)
				.SetEase(Ease.InOutSine);
		}

		private void Update()
		{
			if (agent.velocity.magnitude < 0.1f)
			{
				bounceTween.Pause();
			}
			else
			{
				bounceTween.Play();
			}
		}
	}
}