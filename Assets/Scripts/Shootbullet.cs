using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shootbullet : MonoBehaviour
{
	public GameObject Bullet;
	public GameObject cBullet;
	public Vector2 velocity;
	public Vector2 offset;
	public Transform player;
	private Rigidbody2D rb;
	public float speed;
	private float side;
	public float BulletTime;

	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void Update()
	{
		side = transform.localScale.x;
		rb.freezeRotation = true;
		if (Input.GetKeyDown("e"))
		{
			Shoot();
		}

		if(side < 0)
		{
			speed = -5;
		}
		else
		{
			speed = 5;
		}
	}

	void Shoot()
	{
		cBullet = Instantiate(Bullet, new Vector2(player.position.x, player.position.y) + offset * transform.localScale.x, Quaternion.identity);
		GameObject go = (GameObject)cBullet;
		go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * speed, 0);
		Destroy(cBullet, BulletTime);

	}
}
