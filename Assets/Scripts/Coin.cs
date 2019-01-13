using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
    public Text CoinText;
    public float MultiP;
	public float earning;

    
    void Update()
    {

		CoinText.text = PlayerPrefs.GetFloat("allCoins").ToString("0");
		PlayerPrefs.SetFloat("allCoins", earning * MultiP);

	}
}
