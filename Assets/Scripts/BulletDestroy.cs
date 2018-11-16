using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
  void Update()
  {
        
  }

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "BreakBlock")
		{
			Destroy(gameObject);   
		}
	}
}

