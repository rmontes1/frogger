﻿using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
	public float spawnTime = 0.3f;		// The amount of time between each spawn.
	public float spawnDelay = 0f;		// The amount of time before spawning starts.
	public GameObject car;				// The prefab car to create
	public float carSpeeds;
	public Direction carDirection;
	public float spawnLength;			//lenght of where cars can spawn
	public int carsToSpawn;

	public int spawner1T;
	public int spawner1D = 30;

	public int spawner2T;
	public int spawner2D = 60;
	public int spawner3T;
	public int spawner3D = 30;
	public int spawner4T;
	public int spawner4D = 0;
	public int spawner5T;
	public int spawner5D = 60;
	public int spawner6T;
	public int spawner6D = 50;
	public int spawner7T;
	public int spawner7D = 50;
	public int spawner8T;
	public int spawner8D = 50;

	public int minT = 50;
	public int maxT = 350;
	public float horizConst = 0.30f;

	private float laneWidth = 0.16f;
	//private float numberMaxLanes = 8f;
	private float centerLane;


	
	void Start ()
	{
		//keeps carSpeed pos for the car movement to be handled correctly
		carSpeeds = Mathf.Abs( carSpeeds );
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
		centerLane = laneWidth/2;
	}
	
	
	void Spawn ()
	{
		Vector3 spawningXAxis = transform.position;
		if (spawner1T > spawner1D) {
			spawner1T = 0;
			spawner1D = Random.Range(minT, maxT);
			spawningXAxis.x = transform.position.x +  laneWidth  - centerLane;
			GameObject carClone = (GameObject)Instantiate( car, spawningXAxis, transform.rotation);
			carClone.GetComponent<Automobile>().carSpeed = Random.Range(2,4)/2;
			carClone.GetComponent<Automobile>().carDirection = carDirection;
		}
		else spawner1T++;
		if (spawner2T > spawner2D) {
			spawner2T = 0;
			spawner2D = Random.Range(minT, maxT);
			spawningXAxis.x = transform.position.x + laneWidth * 2 - centerLane;
			GameObject carClone = (GameObject)Instantiate( car, spawningXAxis, transform.rotation);
			carClone.GetComponent<Automobile>().carSpeed = Random.Range(2,4)/2;
			carClone.GetComponent<Automobile>().carDirection = carDirection;
		}
		else spawner2T++;
		if (spawner3T > spawner3D) {
			spawner3T = 0;
			spawner3D = Random.Range(minT, maxT);
			spawningXAxis.x = transform.position.x + laneWidth * 3 - centerLane;
			GameObject carClone = (GameObject)Instantiate( car, spawningXAxis, transform.rotation);
			carClone.GetComponent<Automobile>().carSpeed = Random.Range(2,4)/2;
			carClone.GetComponent<Automobile>().carDirection = carDirection;
		}
		else spawner3T++;
		if (spawner4T > spawner4D) {
			spawner4T = 0;
			spawner4D = Random.Range(minT, maxT);
			spawningXAxis.x = transform.position.x + laneWidth * 4 - centerLane;
			GameObject carClone = (GameObject)Instantiate( car, spawningXAxis, transform.rotation);
			carClone.GetComponent<Automobile>().carSpeed = Random.Range(2,4)/2;
			carClone.GetComponent<Automobile>().carDirection = carDirection;
		}
		else spawner4T++;
		if (spawner5T > spawner5D) {
			spawner5T = 0;
			spawner5D = Random.Range(minT, maxT);
			spawningXAxis.x = transform.position.x + laneWidth * 5 - centerLane;
			GameObject carClone = (GameObject)Instantiate( car, spawningXAxis, transform.rotation);
			carClone.GetComponent<Automobile>().carSpeed = Random.Range(2,4)/2;
			carClone.GetComponent<Automobile>().carDirection = carDirection;
		}
		else spawner5T++;
		if (spawner6T > spawner6D) {
			spawner6T = 0;
			spawner6D = Random.Range(minT, maxT);
			spawningXAxis.x = transform.position.x + laneWidth * 6 - centerLane;
			GameObject carClone = (GameObject)Instantiate( car, spawningXAxis, transform.rotation);
			carClone.GetComponent<Automobile>().carSpeed = Random.Range(2,4)/2;
			carClone.GetComponent<Automobile>().carDirection = carDirection;
		}
		else spawner6T++;
		if (spawner7T > spawner7D) {
			spawner7T = 0;
			spawner7D = Random.Range(minT, maxT);
			spawningXAxis.x = transform.position.x + laneWidth * 7 - centerLane;
			GameObject carClone = (GameObject)Instantiate( car, spawningXAxis, transform.rotation);
			carClone.GetComponent<Automobile>().carSpeed = Random.Range(2,4)/2;
			carClone.GetComponent<Automobile>().carDirection = carDirection;
		}
		else spawner7T++;
		if (spawner8T > spawner8D) {
			spawner8T = 0;
			spawner8D = Random.Range(minT, maxT);
			spawningXAxis.x = transform.position.x + laneWidth * 8 - centerLane;
			GameObject carClone = (GameObject)Instantiate( car, spawningXAxis, transform.rotation);
			carClone.GetComponent<Automobile>().carSpeed = Random.Range(2,4)/2;
			carClone.GetComponent<Automobile>().carDirection = carDirection;
		}
		else spawner8T++;



	}

	void spawnLanes(){

	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Vector3 target = transform.position;
		target.x = target.x + spawnLength;
		Gizmos.DrawLine(transform.position, target );
	}
	void FixedUpdate()
	{
				Spawn ();
	}
}
