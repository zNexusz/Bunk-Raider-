using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour
{
	public GameObject Live1;
	public GameObject Live2;
	public GameObject Live3;
	public PlayerHealth playerHealth;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (playerHealth.health <= 0)
		{
			Live1.SetActive(false);
			Live2.SetActive(false);
			Live3.SetActive(false);
		}

		if (playerHealth.health == 1)
		{
			Live1.SetActive(true);
			Live2.SetActive(false);
			Live3.SetActive(false);
		}

		if (playerHealth.health == 2)
		{
			Live1.SetActive(true);
			Live2.SetActive(true);
			Live3.SetActive(false);
		}

		if (playerHealth.health == 3)
		{
			Live1.SetActive(true);
			Live2.SetActive(true);
			Live3.SetActive(true);
		}
	}
}
