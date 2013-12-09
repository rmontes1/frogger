using UnityEngine;
using System.Collections;

public class Highscore: MonoBehaviour 
{
	public bool isGameOver;
	public string highscorePos;
	public int scoreRecorded;
	public float timeRecorded;
	public int replacedScore;
	private Score scoreTracker;
	private int highscoreLimit;
	private int [] oldScore;
	private GUIText gameOverText;

	void Awake(){
		gameOverText = GameObject.Find("GameOverText").GetComponent<GUIText>();
		gameOverText.enabled = false;
	}

	void Start () 
	{
		scoreTracker = GameObject.Find("Score").GetComponent<Score>();
		isGameOver = false;
		highscoreLimit = 1;
	}
	
	void GameOver() 
	{
		isGameOver= true;
		finalScore();
		for(int i=1; i <= highscoreLimit; i++) //for top 5 highscores
		{
			if(PlayerPrefs.GetInt("highscorePos"+i)< scoreRecorded)   //if cuurent score is in top 5
			{
	
				replacedScore = PlayerPrefs.GetInt("highscorePos"+i);  //store the old highscore in temp varible to shift it down 
				PlayerPrefs.SetInt("highscorePos"+i,scoreRecorded);     //store the currentscore to highscores
		
			}
		}
	}

	int switchScore( int rank , int newScore ){
		int oldscore = PlayerPrefs.GetInt("highscorePos"+ rank );//get replacement value
		PlayerPrefs.SetInt("highscorePos" + rank , newScore );				//set new pos value;
		return oldscore;

	}

	void finalScore(){
		scoreRecorded = scoreTracker.score;
		timeRecorded = scoreTracker.time;
	}
	
	void OnGUI() 
	{
		if( isGameOver )
		{
			gameOverText.enabled = true;
			for(int i=1; i<= highscoreLimit; i++)
			{
				GUI.Box(new Rect(750, 75*i, 200, 50), "HighestScoreHolder: "+" "+PlayerPrefs.GetInt("highscorePos"+i));
			}
			PlayerPrefs.Save();
		}
	}
}