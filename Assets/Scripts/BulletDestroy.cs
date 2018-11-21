using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
	public float speed;
	private Transform player;
	private Vector2 target;



	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		target = new Vector2(player.position.x, player.position.y);

	}

	void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

		if(transform.position.x == target.x && transform.position.y == target.y)
		{
			DestroyBullet();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
	
			gameObject.GetComponent<Renderer>().enabled = false;
			StartCoroutine(DestroyBullet());
		}

		if (other.CompareTag("Enemy"))
		{
			
			gameObject.GetComponent<Renderer>().enabled = false;
			StartCoroutine(DestroyBullet());
		}

	}

	IEnumerator DestroyBullet()
	{
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}

