using UnityEngine;
using System.Collections;

public class CanMove : MonoBehaviour {

	public Direction canMoveDirection;
	private GameObject frogPlayer;
	private FrogControl frog;
	// Use this for initialization
	void Start () {
		track();
		frogPlayer = GameObject.Find("Frog");
		frog = frogPlayer.GetComponent<FrogControl>();
	}
	
	// Update is called once per frame
	void Update () {
		if( frog != null )
			track();
	}

	void track(){
		Debug.Log( frogPlayer );
	/*	transform.position = frogPlayer.transform.position;
		BoxCollider2D parent = frogPlayer.transform.GetComponent<BoxCollider2D>();
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
		}*/
	}

	void OnTriggerEnter2D( Collider2D col ){
		if( col.CompareTag("wall") ){
			switch( canMoveDirection ){
				case Direction.UP:
				frog.canMoveUp = false;
					break;
				case Direction.DOWN:
				frog.canMoveDown = false;
					break;
				case Direction.LEFT:
				frog.canMoveLeft = false;
					break;
				case Direction.RIGHT:
				frog.canMoveRight = false;
					break;
			}
		}
	}

	void OnTriggerExit2D( Collider2D col ){
		if( col.CompareTag("wall") ){
			switch( canMoveDirection ){
			case Direction.UP:
				frog.canMoveUp = true;
				break;
			case Direction.DOWN:
				frog.canMoveDown = true;
				break;
			case Direction.LEFT:
				frog.canMoveLeft = true;
				break;
			case Direction.RIGHT:
				frog.canMoveRight = true;
				break;
			}
		}
	}
}
