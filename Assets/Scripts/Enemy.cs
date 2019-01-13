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
	public Coin Coin;

	private float timeBtwShots;
	public float startTimeBtwShots;
	public GameObject projectile;
	public Transform player;
	public GameObject Player;
	public float Kill;
	public Coin coin;

	#endregion
	#region Methods

	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 1;
		timeBtwShots = startTimeBtwShots;
		Player = GameObject.FindGameObjectWithTag("Player");
		Kill = PlayerPrefs.GetFloat("KillCount");
	}


	void Update()
    {

		Distance = Vector2.Distance(transform.position, player.position);

		if (Distance < pDistance)
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

		if(health <= 0)
		{
			Destroy(gameObject);
			Kill += 1;
			PlayerPrefs.SetFloat("KillCount", Kill);
			coin.earning += 5;
		}

	}
	
	IEnumerator Chase()
	{
		pDistance = 100;
		yield return new WaitForSeconds(3);
		pDistance = 5;
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

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("pBullet"))
		{
			health -= damage;
			StartCoroutine(Chase());
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Range"))
		{
			if (PlayerPrefs.GetFloat("Explode") == 1)
			{
				health = 0;
			}
		}
	}
	#endregion
}
