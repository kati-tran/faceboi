
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 1000f;
    public float range = 100f; //how far it can shoot in one direction. 
    // Start is called be
    public GameObject g; //is the player. 
     void Update()
    {
        if (Input.GetButtonDown("Fire1"))//"shooting"
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(g.transform.position,g.transform.forward, out hit, range))//condition for if in front of block
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }//add visual effect for destroy here. or actually in target. 
        }
    }
}
