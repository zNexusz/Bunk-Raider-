using System.Collections;
using UnityEngine;

public class pBulletDestroy : MonoBehaviour
{
	#region Variables

	public float speed;

	#endregion

	#region Methods

	void Start()
	{
		StartCoroutine(NDestroy());
	}

	void Update()
	{
	//	transform.Translate(speed * Time.deltaTime, 0, 0);

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("pBullet"))
		{
			StartCoroutine(DestroyBullet());
		}
	}


	IEnumerator DestroyBullet()
	{
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}

	IEnumerator NDestroy()
	{
		yield return new WaitForSeconds(1.5f);
		Destroy(gameObject);
	}

	#endregion
}
