using GameInput;
using UnityEngine;

namespace ItemTypes
{
	public class GrapplingHookItemType : MonoBehaviour
	{
		private bool tethered;
		private CharacterController rb;
		private float tetherLength;
		private Vector3 tetherPoint;

		private void Start()
		{
			rb = GetComponent<CharacterController>();
		}

		private void Update()
		{
			if (Input.GetMouseButton(1))
			{
				if (!tethered)
				{
					BeginGrapple();
				}
				else
				{
					EndGrapple();
				}
			}
		}

		private void FixedUpdate()
		{
			if (tethered)
			{
				ApplyGrapplePhysics();
			}
		}

		private void BeginGrapple()
		{
			if (Physics.Raycast(transform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity))
			{
				tethered = true;
				tetherPoint = hit.point;
				tetherLength = Vector3.Distance(tetherPoint, transform.position);
			}
		}

		private void EndGrapple()
		{
			tethered = false;
		}

		private void ApplyGrapplePhysics()
		{
			var gravityCancelling = Time.fixedDeltaTime * Vector3.up * InputMovable.GravityValue;
			rb.Move((tetherPoint - transform.position).normalized - gravityCancelling);
			return;
			// TODO: add reasonable physics here
			Vector3 directionToGrapple = Vector3.Normalize(tetherPoint - transform.position);
			float currentDistanceToGrapple = Vector3.Distance(tetherPoint, transform.position);

			float speedTowardsGrapplePoint =
				Mathf.Round(Vector3.Dot(rb.velocity, directionToGrapple) * 100) / 100;

			if (speedTowardsGrapplePoint < 0)
			{
				if (currentDistanceToGrapple > tetherLength)
				{
					// rb.velocity -= speedTowardsGrapplePoint * directionToGrapple;
					rb.enabled = false;
					transform.position = tetherPoint - directionToGrapple * tetherLength;
					rb.enabled = true;
				}
			}
		}
	}
}
