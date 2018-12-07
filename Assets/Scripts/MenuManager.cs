using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
	public PlayerHealth PlayerHealth;
	public PlayerRespawn playerRespawn;
	public GameObject player;
	public Revivetimer revivetimer;
	float ReviveLimit;
	public GameObject DeathMenu;
	public GameObject GameOverMenu;



	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		ReviveLimit = 4;
	}

	public void Dead()
	{
		GameOverMenu.SetActive(true);
	}

	void Update()
    {
      if(PlayerHealth.health <= 0 && ReviveLimit > 0)
		{
			DeathMenu.SetActive(true);
		}
		if (PlayerHealth.health <= 0 && ReviveLimit <= 0)
		{
			GameOverMenu.SetActive(true);
		}
	}

	public void Revive()
	{
		revivetimer.timeLeft = 5;
		PlayerHealth.health = 3;
		DeathMenu.SetActive(false);
		player.SetActive(true);
		ReviveLimit -= 1;
		playerRespawn.Respawn();
	}

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
