using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float speed=3;
	private float JForce=5;
    private float moveInput;
	private float VerticalInput;
    private Rigidbody2D rb;
	private bool facingRight = true;
	public bool isGrounded;
    public Transform groundCheck;
	private float checkRadius=0.1f;
	public LayerMask whatIsGround;

	private float checkWRadius=0.3f;
	public bool isWall;
	public Transform wallCheck;
	public LayerMask whatIsWall;

	private int xJump;
    public int xJumpValue;
	//ladder
	private float Lspeed=5;
	private float inputHorizontal;
	private float inputVertical;

	private float checkLRadius=0.3f;
	public bool isLadder;
	public Transform LadderCheck;
	public LayerMask whatIsLadder;







	void Start(){
        rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 1;
	}



	void FixedUpdate()
    {
		isWall = Physics2D.OverlapCircle(wallCheck.position, checkWRadius, whatIsWall);
		isLadder = Physics2D.OverlapCircle(LadderCheck.position, checkLRadius, whatIsLadder);
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0){
            Flip();
        }else if(facingRight == true && moveInput < 0){
            Flip();
        }

	}
	void Update()
	{

		if (isGrounded == true)
		{
			xJump = xJumpValue;
		}

		if (Input.GetKeyDown("w") && xJump > 0)
		{
			rb.velocity = Vector2.up * JForce;
			xJump--;
		}
		/*else if (Input.GetKeyDown("w") && xJump == 0 && isGrounded == true && isWall == false)
		{
			rb.velocity = Vector2.up * JForce;
		}*/

		// wall climb
		/*if (Input.GetKey(KeyCode.D) && isGrounded == false && isWall == true && isLadder == false)
		{
			
			Debug.Log("wall");
			rb.velocity = new Vector2(-0,005f);
		}
		else if (Input.GetKey(KeyCode.A) && isGrounded == false && isWall == true && isLadder == false)
		{
			
			Debug.Log("wall");

		}*/

		if (Input.GetKey(KeyCode.D) && isGrounded == false && isWall == true && isLadder == false)
		{

			xJump = xJumpValue;
			GlideDown();
		}
		else if (Input.GetKey(KeyCode.A) && isGrounded == false && isWall == true && isLadder == false)
		{

			xJump = xJumpValue;
			GlideDown();

		}
		else if (isGrounded == true && isWall == true && isLadder == false)
		{

			xJump = xJumpValue;

		}
	}

	public void GlideDown()
	{
		//rb.isKinematic = true;
		rb.velocity = Vector3.zero;
	}

	void Flip()
	{
      facingRight = !facingRight;
      Vector2 Scaler = transform.localScale;
      Scaler.x *= -1;
      transform.localScale = Scaler;
	}

	//ladder
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Ladder" && Input.GetKey(KeyCode.W))
		{
			rb.velocity = new Vector2(0, Lspeed);

		}
		else if (other.tag == "Ladder" && Input.GetKey(KeyCode.S))
		{
			rb.velocity = new Vector2(0, -Lspeed);
		}
		else
		{
			rb.velocity = new Vector2(0, 0.19621f);
		}
		//wall


		/*if (isGrounded == false && isWall == true && isLadder == false)
		{

		}*/

	}
}

