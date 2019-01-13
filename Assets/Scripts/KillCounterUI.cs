using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounterUI : MonoBehaviour
{
	public Text Kill;
	// Update is called once per frame
	void Update()
    {
		Kill.text = PlayerPrefs.GetFloat("KillCount").ToString("0");

	}
}
