using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGranade : MonoBehaviour {

	#region Variables
	public GameObject Granade;
	public GameObject cGranade;
	public Vector2 velocity;
	public Vector2 offset;
	public Transform player;
	private Rigidbody2D rb;
	public float speed;
	private float side;
	//explosion
	public BlockScript BlockScript;
	public Enemy Enemy;
	public float Thrownow;
	#endregion


	#region Methods

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void Update()
	{
		Thrownow = PlayerPrefs.GetFloat("Explode");
		side = transform.localScale.x;
		rb.freezeRotation = true;
		if (Input.GetKeyDown("q"))
		{
			Throw();
		}

		if (side < 0)
		{
			speed = -5;

		}
		else
		{
			speed = 5;
		}
	}

	void Throw()
	{
		cGranade = Instantiate(Granade, new Vector2(player.position.x, player.position.y) + offset * transform.localScale.x, Quaternion.identity);
		GameObject go = (GameObject)cGranade;
		go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * speed, velocity.y);
	}
	//explod

	#endregion
}
