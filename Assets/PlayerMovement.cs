using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
	public Rigidbody rb;

	public float forwardForce = 2000f;
	public float sidewaysForce = 500f;

	// FixedUpdate for physics
    // Update is called once per frame
    void FixedUpdate()
    {
    	// This is the block movement speed.
    	// Should probably change speed the longer played (faster)
    	rb.AddForce(0,0, forwardForce * Time.deltaTime);   

    	// Implement right/left movement with voice later
    	if(Input.GetKey("d"))
    	{
    		// To be changed to have the player "pop" a certain
    		// position right
    		rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
    	}

    	if(Input.GetKey("a"))
    	{
    		// To be changed to have the player "pop" a certain
    		// position left
    		rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
    	}
    }
}
