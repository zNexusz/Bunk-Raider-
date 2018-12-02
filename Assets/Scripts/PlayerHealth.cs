using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	#region Variables

	public int health;
	public int damage;


	#endregion
	#region Methods
	void Start()
    {

    }


    void Update()
    {
		if(health <= 0)
		{
			gameObject.SetActive(false);
		}
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Bullet"))
		{
			health -= damage;
		}
	}

	#endregion 
}
