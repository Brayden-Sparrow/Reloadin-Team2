using UnityEngine;

public class KeyRotator : MonoBehaviour
{
	[Tooltip("The degrees per second to rotate the GameObject around the up-axis")]
	[Range(-720, 720)]
	public float DegreesPerSec = 30;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, DegreesPerSec * Time.deltaTime, Space.World);
    }
}
