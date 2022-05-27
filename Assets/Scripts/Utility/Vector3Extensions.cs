using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 Round(this Vector3 input)
    {
        return new Vector3(
            Mathf.Round(input.x), 
            Mathf.Round(input.y), 
            Mathf.Round(input.z)
        );
    }
}