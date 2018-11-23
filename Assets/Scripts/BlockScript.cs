using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public int health;
    public int damage;


    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("pBullet")){
	
			health -= damage;

		}
	}
}
