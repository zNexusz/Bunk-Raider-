using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public int health;
    public int damage;
	private Transform ThisB;


	// Update is called once per frame
	private void Start()
	{
		ThisB = gameObject.transform;
	}

	void Update()
    {
		if (health <= 0){
            Destroy(gameObject);
        }
	}


    void OnTriggerEnter2D(Collider2D other) {

		if (other.CompareTag("pBullet")){

			health -= damage;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Range")
		{
			if (PlayerPrefs.GetFloat("Explode") == 1)
			{
				ThisB.parent = null;
				health = 0;
			}
		}
	}
}
