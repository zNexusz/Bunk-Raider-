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


	private float timeBtwShots;
	public float startTimeBtwShots;
	public GameObject projectile;
	public Transform player;


	#endregion
	#region Methods
	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		timeBtwShots = startTimeBtwShots;
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
			pDistance = 50;
		}

		if(health <= 0)
		{
			Destroy(gameObject);
		}

	}

	void Shoot()
	{
		if (timeBtwShots < -00)
		{
			Instantiate(projectile, transform.position, Quaternion.identity);
			timeBtwShots = startTimeBtwShots;
		}
		else
		{
			timeBtwShots -= Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("pBullet"))
		{
			health -= damage;
		}
	}
	#endregion
}
