using UnityEngine;

namespace GenericComponents
{
	public class Rotator : MonoBehaviour
	{
		[SerializeField] private float speed = 1f;

		private void LateUpdate()
		{
			transform.Rotate(new Vector3(0, 0, 45) * (Time.deltaTime * speed));
		}
	}
}
