using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour {

	public GameObject parachuter;
	float maxDelay = 5;
	float minDelay = 3;
	float randomRange;
	float lastTime;
	float nextDecrementRate = 7; 
	float nextDecrement;
	void Start()
	{
		nextDecrement = Time.time+nextDecrementRate;
		randomRange = Random.Range(minDelay,maxDelay);
	}

	// Update is called once per frame
	void Update () {
		if(lastTime+randomRange<Time.time){
			parachuter.transform.position  =  new Vector2(Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0f,0f)).x,Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0f)).x),Camera.main.ScreenToWorldPoint(new Vector2(0f,Screen.height)).y);
		Instantiate(parachuter);
			lastTime = Time.time;
		}
		if(Time.time>nextDecrement)
		{
			Debug.Log(string.Format ("Min:{0} Max:{1}",minDelay,maxDelay));
			nextDecrement = nextDecrementRate+Time.time;
			DecrementRange();
		}
	}
	void OnGUI(){
		GUI.Label(new Rect(0,0,Screen.width,Screen.height),string.Format("parachuters landed: {0}\nparachuters crached: {1}",GM.LandedParachuters,GM.CrachedParachuters));
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