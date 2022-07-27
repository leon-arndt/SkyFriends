using UnityEngine;

namespace GenericComponents
{
	public class Rotator : MonoBehaviour
	{
		[SerializeField] private float speed = 1f;

		private void Update()
		{
			transform.Rotate(new Vector3(0, 0, 45) * (Time.deltaTime * speed));
		}
	}
}
