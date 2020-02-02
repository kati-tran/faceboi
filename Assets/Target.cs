using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 1f;
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;


    public float explosionForce = 100f;
    public float explosionRadius = 6f;
    public float explosionUpward = 0.4f;

    //float cubesPivotDistance = cubeSize * cubesInRow / 2;;
    //Vector3 cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

    //cubesPivotDistance = cubeSize* cubesInRow/2;


    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f){
            Die();
        }
    }

    void createPiece(int x, int y, int z)
    {
        //float cubesPivotDistance = cubeSize * cubesInRow / 2; ;
        //Vector3 cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.GetComponent<BoxCollider>().isTrigger = true;
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z);
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

        
    }
    void Die()
    {

        Destroy(gameObject);
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y=0; y<cubesInRow; y++)
            {
                for (int z=0; z<cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }
}
