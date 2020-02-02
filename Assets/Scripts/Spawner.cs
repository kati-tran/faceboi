using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] enemies;
    public GameObject[] facers;
    //public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randEnemy;

    // Start is called before the first frame update
    int step = 6;
	int GetRandomPosition () {
	    int randomPosition = Random.Range(-12, 12);
	    int numSteps = Mathf.FloorToInt (randomPosition / step);
	    int adjustedPosition = numSteps * step;
	 
	    return adjustedPosition;
	}

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
     	spawnWait = Random.Range (spawnLeastWait, spawnMostWait);   
    }

    IEnumerator waitSpawner(){

    	yield return new WaitForSeconds(startWait);

    	while(!stop){
    		randEnemy = Random.Range(0, 5);
    		Debug.Log(randEnemy);

    		if(randEnemy == 0){
    			int count = Random.Range(1,5);
    			while(count != 0){
	    			int test = GetRandomPosition();
	    			Vector3 spawnPosition = new Vector3 (test, 4, Random.Range(-10,20));
	    			GameObject clone = Instantiate (enemies[randEnemy], spawnPosition + transform.TransformPoint (0,0,0), gameObject.transform.rotation);
	    			//FACERRRR
	    			count--;
    			}
    			Vector3 facspot = new Vector3(GetRandomPosition(), 4, 1);
	    		GameObject face = Instantiate (facers[0], facspot + transform.TransformPoint (0,0,0), gameObject.transform.rotation);
    		}

    		if(randEnemy == 1){
    			int negThreeorThree = Random.Range(0, 2) == 0 ? -3 : 3;
    			Vector3 spawnPosition = new Vector3(negThreeorThree, 4, 1);
				GameObject clone = Instantiate (enemies[randEnemy], spawnPosition + transform.TransformPoint (0,0,0), gameObject.transform.rotation); 

				//facerrrr 
				int facc;

				if(negThreeorThree == -3){
					facc = 12;
				}
				else{
					facc = -12;
				}

				Vector3 facspot = new Vector3(facc, 4, 1);
				GameObject face = Instantiate (facers[0], facspot + transform.TransformPoint (0,0,0), gameObject.transform.rotation);  			
    			Destroy (clone, 5.0f);
    		}

    		if(randEnemy == 2){
    			Vector3 spawnPosition = new Vector3(0, 0, 1);
    			GameObject clone = Instantiate (enemies[randEnemy], spawnPosition + transform.TransformPoint (0,0,0), gameObject.transform.rotation);
    			Destroy (clone, 5.0f);
    		}

    		if(randEnemy == 3){
    			Vector3 spawnPosition = new Vector3(-9, 4, 0);
    			Vector3 spawnPosition2 = new Vector3(9, 4, 0);
    			GameObject clone = Instantiate (enemies[randEnemy], spawnPosition + transform.TransformPoint (0,0,0), gameObject.transform.rotation);
    			GameObject clone2 = Instantiate (enemies[randEnemy], spawnPosition2 + transform.TransformPoint (0,0,0), gameObject.transform.rotation);

				Vector3 facspot = new Vector3(0, 4, 0);
				GameObject face = Instantiate (facers[0], facspot + transform.TransformPoint (0,0,0), gameObject.transform.rotation);

    			Destroy (clone, 5.0f);
    			Destroy (clone2, 5.0f);
    		}

    		//Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 1, Random.Range (-spawnValues.z, spawnValues.z));
    		//GameObject clone = Instantiate (enemies[randEnemy], spawnPosition + transform.TransformPoint (0,0,0), gameObject.transform.rotation);
    		//Destroy (clone, 3.0f); // When object should be deleted
    		yield return new WaitForSeconds (spawnWait);
    	}
    }

}
