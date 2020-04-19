using UnityEngine;

public class SpeedExample : MonoBehaviour
{
	float currentSpeed = 0f;
	float targetSpeed = 30f;

	void Update ()
	{
		if (currentSpeed < targetSpeed)
			currentSpeed += Time.deltaTime;
	}
}