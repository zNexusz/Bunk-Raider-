using UnityEngine;

public class Shootbullet : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject cBullet;
    public Vector2 offset;
    public Vector2 velocity;
    public Transform player;
	private Rigidbody2D rb;


	void Start()
	{
        rb = GetComponent<Rigidbody2D>();
		
	}


	// Update is called once per frame
	void Update()
    {
		rb.freezeRotation = true;
		if (Input.GetKeyDown("e"))
        {
            Shoot();
        }
    }

    void Shoot(){
        cBullet = Instantiate(Bullet, new Vector2(player.position.x, player.position.y) + offset * transform.localScale.x, Quaternion.identity);
        GameObject go = (GameObject)cBullet;
		go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
        Destroy(cBullet, 1);
    }
}
 