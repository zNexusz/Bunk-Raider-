using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
	public Vector2 respawnPoint;
	public PlayerHealth playerHealth;
	// Start is called before the first frame update
	private void Start()
	{
		respawnPoint = transform.position;
	}
	public void Respawn()
    {
		transform.position = respawnPoint;
	}

    // Update is called once per frame
    void Update()
    {
	
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("CheckPoint"))
		{
			respawnPoint = other.transform.position;
		}
		
	}
}
