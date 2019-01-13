using System.Collections;
using UnityEngine;

public class pBulletDestroy : MonoBehaviour
{
	#region Variables

	public float speed;
	public Transform player;
	public float Distance;
	public float Range=100;

	#endregion

	#region Methods

	void Start()
	{
	//	StartCoroutine(Destroy());
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		if(Distance >= Range)
		{
			Destroy(gameObject);
		}

		Distance = Vector2.Distance(transform.position, player.position);
	}

	private void OnTriggerEnter2D(Collider2D hitinfo)
	{
		Destroy(gameObject);
		gameObject.GetComponent<Renderer>().enabled = false;
	}
	#endregion
}
