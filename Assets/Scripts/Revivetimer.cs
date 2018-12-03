using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revivetimer : MonoBehaviour
{

	public Image Timebar;
	public float MaxTime = 5f;
	private float timeLeft;

	// Start is called before the first frame update
	void Start()
	{
		Timebar = GetComponent<Image>();
		timeLeft = MaxTime;
	}

	// Update is called once per frame
	void Update()
	{
		if (timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
			Timebar.fillAmount = timeLeft / MaxTime;
		}
		else
		{


		}
	}
}