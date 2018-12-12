using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{

    public float coinAmount;
    public float earning;
    public Text CoinText;
    public PlayerHealth PlayerHealth;
    public float MultiP;


   
    void Start()
    {
        
        CoinText.text = earning.ToString("0");
        coinAmount = PlayerPrefs.GetFloat("allCoins");
        
    }

    
    void Update()
    {
        
        if(PlayerHealth.health <= 0)
        {
            if(earning > 0)
            {
                PlayerPrefs.SetFloat("allCoins", earning);
            }

        }     

        CoinText.text = earning.ToString("0");
        earning += coinAmount;
    }

	public void Enemy1()
	{
		earning += 5;
	}
}
