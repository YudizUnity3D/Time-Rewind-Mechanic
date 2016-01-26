using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public enum axis{x, y, z};

	/// <summary>
	/// The camera axis.
	/// </summary>
	public axis cameraAxis;

	public float speed;
	Vector3 setAxis;

	void Start()
	{
		switch(cameraAxis)
		{
		case axis.x:
			setAxis = Vector3.right;
			break;

		case axis.y:
			setAxis = Vector3.up;

			break;

		case axis.z:
			setAxis = Vector3.forward;

			break;
		}
	}
	void Update () 
	{
		
		transform.RotateAround(Vector3.zero, setAxis, 50  * Time.deltaTime * speed);

	
	}
}
