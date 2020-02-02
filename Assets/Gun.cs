
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
            Shoot("joy");
        }
    }

    public void Shoot(string emotion)
    {
        //Vector3 dir = new Vector3(0, 4, 0);
        //double z = g.transform.position.z;
        RaycastHit hit; //g.transform.forward
        if (Physics.Raycast(g.transform.position + g.transform.up*5.7f,g.transform.forward, out hit, range))//condition for if in front of block
        {
            //(0.0, 5.7, )
            //Debug.Log(g.transform.up * 5.7f);
            //Debug.Log(g.transform.position.z);
           // Debug.Log(g.transform.position);
          //  Debug.Log(hit.transform.name);
            //Debug.Log("should shoot?");
            Target target = hit.transform.GetComponent<Target>();

     
            // destroys it if its that emotion
            if (target != null && hit.transform.gameObject.tag == emotion)
            {
                Debug.Log("AAAAAAAAAAAAAAAA");
                target.takeDamage(damage);
            }//add visual effect for destroy here. or actually in target. 
        }
        if(Physics.Raycast(g.transform.position,g.transform.forward, out hit, range)) {
            //Debug.Log("should shoot?");
            Target target = hit.transform.GetComponent<Target>();

     
            // destroys it if its that emotion
            if (target != null && hit.transform.gameObject.tag == emotion)
            {
                Debug.Log("AAAAAAAAAAAAAAAA");
                target.takeDamage(damage);
            }//add visual effect for destroy here. or actually in target. 
        }
    }


}
