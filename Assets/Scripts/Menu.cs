using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	private GameObject selectedOption;
	private int currentOption;
	// Use this for initialization
	void Start () {
		currentOption = 1;
		setSelected( currentOption );
	}
	
	// Update is called once per frame
	void Update () {
		CycleOptions();
	//	Debug.Log( currentOption );
	}

	void CycleOptions(){
		if( Input.GetKeyDown( KeyCode.UpArrow ) ){
			changeOptionUp();
		}
		if( Input.GetKeyDown( KeyCode.DownArrow) ){
			changeOptionDown();
		}
		if( Input.GetKeyDown( KeyCode.Return ) ) {
			excuteOption();
		}
	}

	void changeOptionDown(){
		deSelect( currentOption );
		currentOption--;
		if( currentOption < 0 ){
			currentOption = this.transform.childCount - 1;
			setSelected( currentOption );
		}
		else{
			setSelected( currentOption );
		}

	}

	void changeOptionUp(){
		deSelect( currentOption );
		currentOption++;
		if( currentOption >= this.transform.childCount ){
			currentOption = 0;
			setSelected( currentOption );
		}
		else{
			setSelected( currentOption );
		}
	}

	void setSelected( int newOption ){
		selectedOption = transform.GetChild( newOption ).gameObject;
		selectedOption.GetComponent<GUIText>().color = new Color( 0 , 0 , 1 );
	}

	void deSelect( int oldOption ){
		selectedOption = transform.GetChild( oldOption ).gameObject;
		selectedOption.GetComponent<GUIText>().color = new Color( 1 , 1 , 1 );
	}

	void excuteOption(){
		if( currentOption == 1 ){
			Application.LoadLevel( 1 );
	
		}
		else{
			Application.Quit();
		}
	}

}
