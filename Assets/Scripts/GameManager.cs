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
	}

	void reset(){
		if( Input.GetKeyDown( KeyCode.R ) ){
			Application.LoadLevel( 0 );
		}
	}


}
