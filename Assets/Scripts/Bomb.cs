using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

#region Variables

	public bool isGrounded;
	public Transform groundCheck;
	private float checkRadius = 0.3f;
	public LayerMask whatIsGround;
	public float stopJ;
	public Vector2 velocity;
	private Rigidbody2D rb;
	private float speed;
	private bool JumpYes;

	private int ExplodeNow; //if 1 then explode

	#endregion


	#region Methods
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		speed = PlayerPrefs.GetFloat("Side");
		JumpYes = true;
		ExplodeNow = 0;
		PlayerPrefs.SetFloat("Explode", ExplodeNow);
		StartCoroutine(Insta());
	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

	}

	private void Update()
	{

		if (isGrounded == true)
		{
			if(JumpYes == true)
			{
				rb.velocity = new Vector2(velocity.x * speed, velocity.y);
				rb.AddForce(transform.up * 2);
				stopJ += 1;
			}
			
		}

		if(stopJ > 6)
		{
			JumpYes = false;
			rb.velocity = Vector3.zero;
			StartCoroutine(Explode());
		}
	}

	IEnumerator Explode()
	{
		if(isGrounded == true)
		{
			ExplodeNow = 1;
			PlayerPrefs.SetFloat("Explode", ExplodeNow);
			yield return new WaitForSeconds(0.1f);
			ExplodeNow = 0;
			PlayerPrefs.SetFloat("Explode", ExplodeNow);
			yield return new WaitForSeconds(0.1f);
			Destroy(gameObject);
		}
	}
	
	IEnumerator Insta()
	{
		yield return new WaitForSeconds(5f);
		ExplodeNow = 0;
		PlayerPrefs.SetFloat("Explode", ExplodeNow);
		yield return new WaitForSeconds(0.1f);
		Destroy(gameObject);
	}


	#endregion
}
