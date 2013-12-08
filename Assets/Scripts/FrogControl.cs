using UnityEngine;
using System.Collections;

public class FrogControl : MonoBehaviour {


	public enum FrogMovement{ physics , transform };

	public float frogSpeed;
	public float frogSpeedPhysic;
	public FrogMovement currentMovementType;
	private Score scoreTracker;
	public int frogLives;
	public bool canMove;
	public Vector3 lastPos;
	public int croaksLeft;
	public Sprite [] spriteState;

	private Vector3 respawnPos;
	private bool croaking;
	private bool canCroak;
	private float croakTime;
	private float croakReset;



	// Use this for initialization
	void Start () {

		scoreTracker = GameObject.Find("Score").GetComponent<Score>();
		scoreTracker.currentFrogLives = frogLives;
		canMove = true;
		respawnPos = new Vector3( 0.23f , -0.8993872f , 0f );
		croaking = false;
		croakTime = 0;
		croakReset = 0.1f;
		canCroak = true;
	}
	
	// Update is called once per frame
	void Update () {

		croak();

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
		destroyAutomobiles();
		frogLives -= 1;
		scoreTracker.currentFrogLives = frogLives;
		//gameover
		if( frogLives <= 0 ){
			Destroy(this.gameObject);
		}
		//lifes left reset frog pos/sprite/speed
		else{
			scoreTracker.resetMultiplier();
			rigidbody2D.velocity = Vector3.zero;
			transform.position = respawnPos;
			transform.eulerAngles = Vector3.zero;
		}
	}

	void destroyAutomobiles(){
		GameObject [] vehicles = GameObject.FindGameObjectsWithTag("automobile");
		if( vehicles != null ){
			foreach( GameObject carToDelete in vehicles ){
				Destroy( carToDelete );
			}
		}
	}

	//Frog Transform Movement Functions
	void frogMovementTransform(){
		if( Input.GetKeyDown(KeyCode.UpArrow) ){
			moveUpTransform();
		}
		if( Input.GetKeyDown(KeyCode.DownArrow) ){
			moveDownTransform();
		}
		if( Input.GetKeyDown(KeyCode.LeftArrow) ){
			moveLeftTransform();
		}
		if( Input.GetKeyDown(KeyCode.RightArrow) ){
			moveRightTransform();
		}
	}

	//Frog Transform Movement
	void moveUpTransform(){
		//transform.eulerAngles = Vector3.zero;
		this.GetComponent<SpriteRenderer>().sprite = spriteState[0];
		Debug.Log( Vector3.up * frogSpeed );
		lastPos = transform.position;
		transform.Translate( Vector3.up * frogSpeed );

		scoreTracker.addMultiplier();
		
	}

	void moveDownTransform(){
		//transform.eulerAngles = Vector3.forward * 180;
		this.GetComponent<SpriteRenderer>().sprite = spriteState[1];
		lastPos = transform.position;
		transform.Translate( Vector3.down * frogSpeed);
		scoreTracker.subtractMultiplier();
	
	}

	void moveLeftTransform(){
		//transform.eulerAngles = Vector3.forward * 90;
		this.GetComponent<SpriteRenderer>().sprite = spriteState[2];
		lastPos = transform.position;
		transform.Translate( Vector3.left * frogSpeed );
	}

	void moveRightTransform(){
		//transform.eulerAngles = Vector3.forward * 270;
		this.GetComponent<SpriteRenderer>().sprite = spriteState[3];
		lastPos = transform.position;
		transform.Translate( Vector3.right * frogSpeed );

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

	public void croak(){
		croakDuration();
		if( Input.GetKeyDown(KeyCode.Space) && canCroak ){
			croaking = true;
			canCroak = false;
		}
	}


	void croakDuration(){

		if( croaking ){
			croakTime += Time.deltaTime;
			if( croakTime > croakReset ){
				croakTime = 0;
				croaking = false;
				if( croaksLeft > 0 ){
					canCroak = true;
				}
			}
		}
	}


	//Frog Collision
	void OnCollisionStay2D( Collision2D col ){
		if( col.transform.CompareTag("automobile") ){
	
			frogDeath();
		}
		else{
			transform.position = lastPos;
		}
	}

	void OnTriggerStay2D( Collider2D col ){
		if( col.transform.CompareTag("automobile") && croaking ){
			col.rigidbody2D.velocity = Vector3.zero;
		}
	}

}
