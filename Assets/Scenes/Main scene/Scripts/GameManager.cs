using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
public class GameManager : MonoBehaviour {

	public GameObject parachuter;
	bool GameOver = false;
	float maxDelay = 5;
	float minDelay = 3;
	float randomRange;
	DateTime nextTime;
	float nextDecrementRate = 7; 
	DateTime nextDecrement;
	int last;
	string debugInfo;
	void Start()
	{
		last = PlayerPrefs.GetInt("last");
		nextDecrement = DateTime.Now.AddSeconds(nextDecrementRate);
		randomRange = Random.Range(minDelay,maxDelay);
	}

	// Update is called once per frame
	void Update () {
		if(GM.CrachedParachuters>=1){
			GameOver=true;
			PlayerPrefs.SetInt("last",GM.LandedParachuters);
		}
		if(!GameOver){
			debugInfo = "Next instatiation "+nextTime.Second+" "+DateTime.Now.Second;
			if(nextTime<DateTime.Now){
				debugInfo = "Into instatiation block";
				parachuter.transform.position  =  new Vector2(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0f,0f)).x,Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0f)).x),Camera.main.ScreenToWorldPoint(new Vector2(0f,Screen.height)).y);
				Instantiate(parachuter);
				nextTime = DateTime.Now.AddSeconds(randomRange);
			}
			if(DateTime.Now>nextDecrement){
				nextDecrement = DateTime.Now.AddSeconds(-nextDecrementRate);
				DecrementRange();
			}
		}
	}

	void OnGUI(){
		GUI.Label(new Rect(0,0,Screen.width,Screen.height),string.Format("parachuters landed: {0}\nparachuters crached: {1}\nlast:{2}\nDebug info:{3}",GM.LandedParachuters,GM.CrachedParachuters,last,debugInfo));
		if(GameOver){
			//Draw gameover gui
			GUI.Window(0,new Rect(Screen.width/2-100,Screen.height/2-100,200,200),GameOverWindowFunc,"GameOver");
		}
	}

	void GameOverWindowFunc(int windowId)
	{
		if(GUI.Button(new Rect(10,10,100,100),"Repeat")){
			Reload(Application.loadedLevelName);
		}
		if(GUI.Button(new Rect(10,105,100,100),"Main menu")){
			Reload ("MainMenu");
		}
	}
	void Reload(string level)
	{
		GM.Reset();
		Application.LoadLevel(level);
	}
	void DecrementRange()
	{
		if(maxDelay<1){
			maxDelay=1;
			return;}
		if(minDelay<0.4f)
		{
			if(maxDelay>0)
			maxDelay -= 0.4f;
		}
		else
		{
			minDelay-=0.4f;
			if(minDelay<0)
				minDelay=0;
		}
		randomRange = Random.Range(minDelay,maxDelay);

	}

}