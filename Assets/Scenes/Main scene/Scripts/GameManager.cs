using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
public class GameManager : MonoBehaviour {

	public GameObject Parachuter;
	public GameObject Ground;
	bool GameOver = false;
	float maxDelay = 5;
	float minDelay = 3;
	float randomRange;
	float nextTime;
	float nextDecrementRate = 7; 
	float nextDecrement;
	int best;
	string debugInfo;
	void Start()
	{
		Game.Unpause();
		best = PlayerPrefs.GetInt("last");
		float height = (float)(Camera.main.orthographicSize * 4.0f);
		float width = (float)(height * Screen.width / Screen.height);
		Ground.transform.localScale = new Vector2(width, 1f);
		nextDecrement = Time.time+nextDecrementRate;
		randomRange = Random.Range(2,3);
		nextTime = randomRange+Time.time;
	}

	// Update is called once per frame
	void Update () {
		if(!Game.IsPaused){
			if(Game.CrachedParachuters>=1){
				GameOver=true;
				if(Game.LandedParachuters>best)
				PlayerPrefs.SetInt("last",Game.LandedParachuters);
			}
			if(!GameOver){
				debugInfo = "Next instatiation "+nextTime+" "+Time.time;
				if(nextTime<Time.time){
					debugInfo = "Into instatiation block";
					Parachuter.transform.position  =  new Vector2(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0f,0f)).x,Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0f)).x),Camera.main.ScreenToWorldPoint(new Vector2(0f,Screen.height)).y);
					Instantiate(Parachuter);
					nextTime = Time.time+randomRange;
				}
				if(Time.time>nextDecrement){
					nextDecrement = Time.time+nextDecrementRate;
					DecrementRange();
				}
			}
		}
	}

	void OnGUI(){
		GUI.Label(new Rect(0,0,Screen.width,Screen.height),string.Format("parachuters landed: {0}\nparachuters crached: {1}\nBest:{2}\nDebug info:{3}",Game.LandedParachuters,Game.CrachedParachuters,best,debugInfo));
		if(GameOver){
			//Draw gameover gui
			GUI.Window(0,new Rect(Screen.width/2-100,Screen.height/2-100,200,200),GameOverWindowFunc,"GameOver");
		}
			if(GUI.Button(new Rect(Screen.width-40,25,20,20),"||"))
			{
				Game.InvertPause();
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

	void OnApplicationPause(bool pause)
	{
		Debug.Log("Pause");
		Game.Pause();
	}

	void Reload(string level)
	{
		Game.Reset();
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