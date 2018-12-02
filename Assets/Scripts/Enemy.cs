using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	#region Variables

	public float speed;
	public float stoppingDistance;
	public float Distance;
	public float pDistance;
	public int health;
	public int damage;
	public Vector2 offset;
	private Rigidbody2D rb;

	private float timeBtwShots;
	public float startTimeBtwShots;
	public GameObject projectile;
	public Transform player;
	public GameObject Player;


	#endregion
	#region Methods
	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 1;
		timeBtwShots = startTimeBtwShots;
		Player = GameObject.FindGameObjectWithTag("Player");

	}


	void Update()
    {

			Distance = Vector2.Distance(transform.position, player.position);
		if(Distance < pDistance)
		{
			if (Distance > stoppingDistance)
			{
				transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
				Shoot();

			}else if (Distance < stoppingDistance)
			{
				transform.position = this.transform.position;
				Shoot();

			}
		}

		if(health < 4)
		{
			StartCoroutine(Chase());
		}

		if(health <= 0)
		{
			Destroy(gameObject);
		}

	}
	
	IEnumerator Chase()
	{
		Distance *= 10f;
		yield return new WaitForSeconds(1);
		Distance /= 10f;
	}

	void Shoot()
	{
		if (Player.activeInHierarchy == true)
		{
			if (timeBtwShots < -00)
			{
				Instantiate(projectile, new Vector2(transform.position.x, transform.position.y) + offset * transform.localScale.x, Quaternion.identity);
				timeBtwShots = startTimeBtwShots;
				Destroy(projectile, 1);
			}
			else
			{
				timeBtwShots -= Time.deltaTime;
			}
		}

			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("pBullet"))
		{
			health -= damage;
		}
		if (other.CompareTag("Ladder"))
		{
			rb.gravityScale = 0;
		}
	}
	#endregion
}
