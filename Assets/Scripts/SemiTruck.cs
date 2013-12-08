using UnityEngine;
using System.Collections;

public class SemiTruck : Automobile {


	private int odds;
	private bool attemptedToHonk;
  	// Use this for initialization
	void Start () {
		odds = 5;
		attemptedToHonk = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void chanceToHonk(){
		if( Random.Range( 1 , odds ) == Random.Range( 1 , odds ) ){
			this.audio.Play();
		}
		else{
			attemptedToHonk = true;
		}
	}

	void OnTriggerEnter2D( Collider2D col ){

		if( col.transform.CompareTag("frog") && !attemptedToHonk ){
			chanceToHonk();
		}
	}
}
