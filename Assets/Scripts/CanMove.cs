using UnityEngine;
using System.Collections;

public class CanMove : MonoBehaviour {

	public Direction canMoveDirection;
	private GameObject frogPlayer;
	private FrogControl frog;

	// Use this for initialization
	void Start () {
		setup();
		frog = GameObject.Find("Frog").GetComponent<FrogControl>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void setup(){
		BoxCollider2D parent = transform.parent.GetComponent<BoxCollider2D>();
		BoxCollider2D moveCheck = transform.GetComponent<BoxCollider2D>();
		moveCheck.size = parent.size;

		switch( canMoveDirection ){
			case Direction.UP:
				moveCheck.center = new Vector2( 0f , parent.size.y );
				break;
			case Direction.DOWN:
				moveCheck.center = new Vector2( 0f , -parent.size.y );
				break;
			case Direction.LEFT:
				moveCheck.center = new Vector2( -parent.size.x , 0f );
				break;
			case Direction.RIGHT:
				moveCheck.center = new Vector2( parent.size.x , 0f );
				break;
		}
	}

	void OnTriggerEnter2D( Collider2D col ){
		if( col.CompareTag("wall") ){
			frog.transform.position = frog.lastPos;
		}
	}

	void OnTriggerExit2D( Collider2D col ){
		if( col.CompareTag("wall") ){
//			frog.canMove = true;
		}
	}

}
