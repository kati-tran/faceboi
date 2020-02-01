using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public Transform player;
	public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
    	//transform attached to this game object
        transform.position = player.position + offset;
    }
}
