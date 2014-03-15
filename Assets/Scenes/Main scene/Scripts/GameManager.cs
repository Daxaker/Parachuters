using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
public class GameManager : MonoBehaviour {

	public GameObject Parachuter;
	public GameObject Ground;
	float maxDelay = 5;
	float minDelay = 3;
	float randomRange;
	float nextTime;
	float nextDecrementRate = 7; 
	float nextDecrement;
	void Start()
	{
		Game.Unpause();
		Game.UpdateRecord();
		float height = (float)(Camera.main.orthographicSize * 4.0f);
		float width = (float)(height * Screen.width / Screen.height);
		Ground.transform.localScale = new Vector2(width, 1f);
		nextDecrement = Time.time+nextDecrementRate;
		randomRange = Random.Range(2,3);
		nextTime = randomRange+Time.time;
	}

	// Update is called once per frame
	void Update () {
		if(!Game.IsPaused&&Game.IsStarted){
			if(!Game.IsGameOver){
				if(nextTime<Time.time){
					Parachuter.transform.position  =  new Vector2(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0f+Screen.width*.1f,0f)).x,Camera.main.ScreenToWorldPoint(new Vector2(Screen.width-Screen.width*.1f,0f)).x),Camera.main.ScreenToWorldPoint(new Vector2(0f,Screen.height)).y);
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

	void OnApplicationPause(bool pause)
	{
		Game.Pause();
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