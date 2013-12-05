using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 0f;		// The amount of time before spawning starts.
	public GameObject car;				// The prefab car to create
	public float carSpeeds;
	public Direction carDirection;
	public float spawnLength;			//lenght of where cars can spawn
	public int carsToSpawn;


	
	void Start ()
	{
		//keeps carSpeed pos for the car movement to be handled correctly
		carSpeeds = Mathf.Abs( carSpeeds );
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	
	void Spawn ()
	{
		Vector3 spawningXAxis = transform.position;
		float minRange = transform.position.x;
		float maxRange = transform.position.x + spawnLength;

		for( int i = 0; i < carsToSpawn; i++){
			spawningXAxis.x = Random.Range( minRange , maxRange );

			//makes a clone of a car desired and sets speed and direction according to the spawn point
			GameObject carClone = (GameObject)Instantiate( car, spawningXAxis, transform.rotation);
			carClone.GetComponent<Automobile>().carSpeed = carSpeeds;
			carClone.GetComponent<Automobile>().carDirection = carDirection;
		}

	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Vector3 target = transform.position;
		target.x = target.x + spawnLength;
		Gizmos.DrawLine(transform.position, target );
	}
}
