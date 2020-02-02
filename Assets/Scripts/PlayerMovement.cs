using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;
	public bool isGrounded;
	public static bool uniGrounded;

	public Transform player;

	public float forwardForce = 6000f;	// Variable that determines the forward force
	//public float sidewaysForce = 500f;  // Variable that determines the sideways force

   void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
    }

	//int speed = 0;
	//float smooth;
	//var test : Vector3 = Vector3(6, 0, 0);
    public void moveLeft(){
    	player.transform.position = new Vector3(player.position.x - 6, player.position.y, player.position.z);
    }

    public void moveRight(){
    	player.transform.position = new Vector3(player.position.x + 6, player.position.y, player.position.z);
    }

	// We marked this as "Fixed"Update because we
	// are using it to mess with physics.
	void Update ()
	{
		// Add a forward force
		//smooth = speed * Time.deltaTime;
		uniGrounded = isGrounded;
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKeyDown("d"))	// If the player is pressing the "d" key
		{
			// Add a force to the right
			moveRight();
			//player.transform.position = new Vector3(player.position.x + 6, player.position.y, player.position.z);
			//transform.Translate (transform.position + test.position * smooth);
			//rb.AddForce(new Vector3(12, 0, 0), ForceMode.Impulse);
			//Vector3 newPos = new Vector3(player.position.x + 6, player.position.y, player.position.z);
         	//transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 40f);
			//Debug.Log(player.position);
		}

		if (Input.GetKeyDown("a"))  // If the player is pressing the "a" key
		{
			// Add a force to the left
			moveLeft();
			//rb.AddForce(new Vector3(-12, 0, 0), ForceMode.Impulse);
			//Vector3 newPos = new Vector3(player.position.x - 6, player.position.y, player.position.z);
         	//transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 40f);
			//Debug.Log(player.position);
		}

		if (Input.GetKeyDown("w") && isGrounded)  // If the player is pressing the "a" key
		{
			// Add a force to jump
            rb.AddForce(new Vector3(0, 10, 0) * 3f, ForceMode.Impulse);
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            //rb.mass = 10f;
            isGrounded = false;
            //rb.AddForce(new Vector3(0, -10, 0), ForceMode.Impulse);
		}

		if (Input.GetKeyDown("s") && isGrounded)  // If the player is pressing the "a" key
		{
			// Add a force to jump
            rb.AddForce(new Vector3(0, -10, 0) * 5f, ForceMode.Impulse);
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            //rb.mass = 10f;
            //isGrounded = false;
            //rb.AddForce(new Vector3(0, -10, 0), ForceMode.Impulse);
            Debug.Log("GOING DOWNNN");
		}

		if(isGrounded == false){
			rb.AddForce(new Vector3(0,-1,0), ForceMode.Impulse);
		}

		if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
