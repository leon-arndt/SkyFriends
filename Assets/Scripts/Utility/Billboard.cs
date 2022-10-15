using UnityEngine;

namespace Utility
{
	public class Billboard : MonoBehaviour
	{
		private void Update()
		{
			transform.LookAt(Camera.main!.transform.position, -Vector3.up);
		}
	}
}
