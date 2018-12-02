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
		StartCoroutine(Destroy());
	}

	void Update()
	{
	//	transform.Translate(speed * Time.deltaTime, 0, 0);

	}

	private void OnTriggerEnter2D(Collider2D hitinfo)
	{
		Destroy(gameObject);
		gameObject.GetComponent<Renderer>().enabled = false;
	}


	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(1.5f);
		Destroy(gameObject);
	}

	#endregion
}
