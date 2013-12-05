using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public float score;
	public float multiplier;
	public float time;
	public int currentFrogLives;
	public int incrementScore;
	private float scoreTimer;

	// Use this for initialization
	void Start () {
		score = 0;
		multiplier = 1;
		time = 0;
		scoreTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		textUpdate();
		timer();
		addToScore();
	}

	public void addMultiplier(){
		multiplier += 1;
	}

	public void subtractMultiplier(){
		multiplier -= 1;
	}

	void textUpdate(){
		guiText.text = "Score: " + score + " Multiplier: " + multiplier + " Time: " + timeFormat() + " Lives: " + currentFrogLives;
	}

	void timer(){
		time += Time.deltaTime;
	}

	void addToScore(){
		scoreTimer += Time.deltaTime;
		if( scoreTimer > incrementScore ){
			scoreTimer = 0f;
			score += multiplier;
		}
	}

	string timeFormat(){
		string formattedTime = (int)(time / 60) + ":" + (int)(time % 60);
		return formattedTime;
	}
}
