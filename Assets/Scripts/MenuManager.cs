using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public PlayerHealth PlayerHealth;
	public GameObject DeathMenu;
	public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
    {
      if(PlayerHealth.health <= 0)
		{
			DeathMenu.SetActive(true);
		}  
    }

	public void Revive()
	{
		PlayerHealth.health = 3;
		DeathMenu.SetActive(false);
		player.SetActive(true);
	}
}
