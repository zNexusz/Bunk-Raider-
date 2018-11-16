using UnityEngine;

public class CameraFollower : MonoBehaviour {

	public Transform target; 
	public Vector3 offset;

	// Use this for initialization
	void LateUpdate ()
	{
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0) + offset;
	}
}
