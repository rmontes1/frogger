using UnityEngine;
using System.Collections;

public class FrogControl : MonoBehaviour {


	public enum FrogMovement{ physics , transform };

	public float frogSpeed;
	public float frogSpeedPhysic;
	public FrogMovement currentMovementType;
	private Score scoreTracker;
	public bool canMoveUp;
	public bool canMoveDown;
	public bool canMoveLeft;
	public bool canMoveRight;
	public int frogLives;
	public int deathTimer = 180;
	private Vector3 respawnPos;



	// Use this for initialization
	void Start () {
		scoreTracker = GameObject.Find("Score").GetComponent<Score>();
		scoreTracker.currentFrogLives = frogLives;
		canMoveUp = true;
		canMoveDown = true;
		canMoveRight = true;
		canMoveLeft = true;
		respawnPos = new Vector3( 0.23f , -0.8993872f , 0f );
	}
	
	// Update is called once per frame
	void Update () {
		//choses movement type for frog
		if( currentMovementType == FrogMovement.transform ){
			frogMovementTransform();
		}
		else{
			frogMovementPhysics();
		}
	}


	//Frog Death
	void frogDeath(){
		if (deathTimer > 180) {
						deathTimer = 0;
						frogLives -= 1;
						scoreTracker.currentFrogLives = frogLives;
						//gameover
						if (frogLives <= 0) {
								Destroy (this.gameObject);
						}
			else{
				rigidbody2D.velocity = Vector3.zero;
				transform.position = respawnPos;
				transform.eulerAngles = Vector3.zero;
			}
				}
		//lifes left reset frog pos/sprite/speed

	}

	//Frog Transform Movement Functions
	void frogMovementTransform(){
		if( Input.GetKeyDown(KeyCode.UpArrow) && canMoveUp ){
			moveUpTransform();
		}
		if( Input.GetKeyDown(KeyCode.DownArrow) && canMoveDown ){
			moveDownTransform();
		}
		if( Input.GetKeyDown(KeyCode.LeftArrow) && canMoveLeft ){
			moveLeftTransform();
		}
		if( Input.GetKeyDown(KeyCode.RightArrow) && canMoveRight ){
			moveRightTransform();
		}
	}

	//Frog Transform Movement
	void moveUpTransform(){
		Vector3 currentPos = this.transform.position;
		currentPos.y += frogSpeed;
		transform.position = currentPos;
		transform.eulerAngles = Vector3.zero;
		scoreTracker.addMultiplier();
	}

	void moveDownTransform(){
		Vector3 currentPos = this.transform.position;
		currentPos.y -= frogSpeed;
		transform.position = currentPos;
		scoreTracker.subtractMultiplier();
		transform.eulerAngles = Vector3.forward * 180;
	}

	void moveLeftTransform(){
		Vector3 currentPos = this.transform.position;
		currentPos.x -= frogSpeed;
		transform.position = currentPos;
		transform.eulerAngles = Vector3.forward * 90;
	}

	void moveRightTransform(){

		Vector3 currentPos = this.transform.position;
		currentPos.x += frogSpeed;
		transform.position = currentPos;
		transform.eulerAngles = Vector3.forward * 270;
	}

	//Frog Physics Movement Functions
	void frogMovementPhysics(){
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.velocity = new Vector2( rigidbody2D.velocity.x, frogSpeedPhysic );
			transform.eulerAngles = Vector3.zero;
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow)){
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.velocity = new Vector2( rigidbody2D.velocity.x, frogSpeedPhysic * -1 );
			transform.eulerAngles = Vector3.forward * 180;
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow)){
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.velocity = new Vector2( frogSpeedPhysic * -1, rigidbody2D.velocity.y );
			transform.eulerAngles = Vector3.forward * 90;
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow)){
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.velocity = new Vector2( frogSpeedPhysic, rigidbody2D.velocity.y );	
			transform.eulerAngles = Vector3.forward * 270;

		}

		if( Input.GetKeyUp(KeyCode.UpArrow) && !Input.GetKeyUp(KeyCode.DownArrow) ){
			rigidbody2D.velocity = Vector2.zero;
		}
		else if( Input.GetKeyUp(KeyCode.DownArrow) && !Input.GetKeyUp(KeyCode.UpArrow)){
			rigidbody2D.velocity = Vector2.zero;
		}
		else if( Input.GetKeyUp(KeyCode.LeftArrow) ){
			rigidbody2D.velocity = Vector2.zero;
		}
		else if( Input.GetKeyUp(KeyCode.RightArrow) ){
			rigidbody2D.velocity = Vector2.zero;
		}

		   
	}


	//Frog Collision
	void OnCollisionEnter2D( Collision2D col ){
		if( col.transform.CompareTag("automobile") ){
			frogDeath();
		}
	}
	void FixedUpdate(){
		deathTimer++;
		}

}
