using UnityEngine;

public class SpawnerMove : MonoBehaviour
{
	public Transform player;	// A variable that stores a reference to our Player
	//public Vector3 offset;		// A variable that allows us to offset the position (x, y, z)
	public float spawnerDistance = 100f;
	
	// Update is called once per frame
	void Update () {
		// Set our position to the players position and offset it
		transform.position = new Vector3(0, 1, player.position.z + spawnerDistance);
	}
}
