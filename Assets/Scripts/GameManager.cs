using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private FrogControl frog;
	private bool toggleMovement;

	// Use this for initialization
	void Start () {
		frog = GameObject.Find("Frog").GetComponent<FrogControl>();
	}
	
	// Update is called once per frame
	void Update () {
		reset();
		switchMovement();
	}

	void switchMovement(){
		if( Input.GetKeyDown( KeyCode.M ) ){
			if(toggleMovement){
				frog.currentMovementType = FrogControl.FrogMovement.physics;
				toggleMovement = false;
			}
			else{
				frog.transform.rigidbody2D.velocity = Vector3.zero;
				frog.currentMovementType = FrogControl.FrogMovement.transform;
				toggleMovement = true;
			}
		}
	}

	void reset(){
		if( Input.GetKeyDown( KeyCode.R ) ){
			Application.LoadLevel( 0 );
		}
	}


}
