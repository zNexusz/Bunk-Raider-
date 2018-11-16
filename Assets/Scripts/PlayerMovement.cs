using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float JForce;
    private float moveInput;
	private float VerticalInput;
    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int xJump;
    public int xJumpValue;
	//ladder
	public float Lspeed;
	private float inputHorizontal;
	private float inputVertical;
	public float distance;
	public LayerMask whatIsLadder;
	private bool isClimbing;




	void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    

  void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0){
            Flip();
        }else if(facingRight == true && moveInput < 0){
            Flip();
        }
		//ladder
		inputHorizontal = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(inputHorizontal * Lspeed, rb.velocity.y);
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

		if(hitInfo.collider != null)
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				isClimbing = true;
			}
		}else {
			isClimbing = false;
		}

		if(isClimbing == true)
		{
			inputVertical = Input.GetAxis("Vertical");
			rb.velocity = new Vector2(rb.position.x, inputVertical * Lspeed);
			rb.gravityScale = 0;
		} else{
			rb.gravityScale = 1;
		}
			
    }
    void Update(){
        
        if(isGrounded == true){
            xJump = xJumpValue;
        }

        if(Input.GetKeyDown("w") && xJump > 0){
            rb.velocity = Vector2.up * JForce;
            xJump--;
        }else if(Input.GetKeyDown("w") && xJump == 0 && isGrounded == true){
            rb.velocity = Vector2.up * JForce;
        }
    }
  void Flip()
  {
      facingRight = !facingRight;
      Vector3 Scaler = transform.localScale;
      Scaler.x *= -1;
      transform.localScale = Scaler;
  }

	//ladder
	/*void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Ladder" && Input.GetKey(KeyCode.W))
		{
			rb.velocity = new Vector2(0, speedlad);

		}
		else if (other.tag == "Ladder" && Input.GetKey(KeyCode.S))
		{
			rb.velocity = new Vector2(0, -speedlad);
		}
		else
		{
			rb.velocity = new Vector2(0, 0.19621f);
		}

	}*/
}
