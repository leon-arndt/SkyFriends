using UnityEngine;

namespace GenericComponents
{
	public class LookAtVector : MonoBehaviour
	{
		[SerializeField] private ScriptableVector3 target;
		[SerializeField] private float maxDistance = 5f;

		private void Update()
		{
			var targetPosition = new Vector3(target.value.x, transform.position.y, target.value.z);
			if (Vector3.Distance(transform.position, targetPosition) < maxDistance)
			{
				transform.LookAt(targetPosition, Vector3.up);
			}
		}
	}
}
