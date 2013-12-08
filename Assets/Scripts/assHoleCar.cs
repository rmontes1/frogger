using UnityEngine;
using System.Collections;

public class assHoleCar : MonoBehaviour {
	public GameObject frogger;

	// Use this for initialization
	void Start () {
		frogger = GameObject.Find ("Frog");
		//float x = frogger.transform.position.x;

	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.015f,0);
		if (this.transform.position.y > frogger.transform.position.y) {
						if (this.transform.position.x > frogger.transform.position.x) {
								this.transform.position = new Vector3 (this.transform.position.x - .003f, this.transform.position.y, 0);
						}
						if (this.transform.position.x < frogger.transform.position.x) {
								this.transform.position = new Vector3 (this.transform.position.x + .003f, this.transform.position.y, 0);
						}
				}


	
	}
}
