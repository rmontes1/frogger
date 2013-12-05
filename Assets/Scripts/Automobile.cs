using UnityEngine;
using System.Collections;

public enum Direction{ UP , DOWN , LEFT , RIGHT };
[RequireComponent (typeof (Rigidbody2D))]

public class Automobile : MonoBehaviour {

	public float carSpeed;
	public Direction carDirection;



	// Use this for initialization
	void Start () {
		carSpeed = Mathf.Abs( carSpeed );
		moveAutomobile();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void moveAutomobile(){
		switch( carDirection ){

		case Direction.LEFT:
			rigidbody2D.velocity = new Vector2( carSpeed * -1, rigidbody2D.velocity.y );	
			break;
		case Direction.RIGHT:
			rigidbody2D.velocity = new Vector2( carSpeed, rigidbody2D.velocity.y );	
			break;
		case Direction.UP:
			rigidbody2D.velocity = new Vector2( rigidbody2D.velocity.x, carSpeed );
			break;
		case Direction.DOWN:
			rigidbody2D.velocity = new Vector2( rigidbody2D.velocity.x, carSpeed * -1 );
			break;
		}

	}


}
