using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    //FixedUpdate for physics
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0,0, forwardForce * Time.deltaTime);

        // Edit for voice movement
	    if ( Input.GetKey("d"))
	    {
	    	rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
	    }

	    if ( Input.GetKey("a"))
	    {
	    	rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
	    }
    }




}
