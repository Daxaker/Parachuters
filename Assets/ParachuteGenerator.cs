using UnityEngine;
using System.Collections;
public class ParachuteGenerator : MonoBehaviour {

	public GameObject parachuter;
	public Camera cam;
	// Use this for initialization
	float intervalTimer;
	float interval;
	void Start(){
		intervalTimer=Time.time;
		interval = Random.Range(0,.5f);
	}
	
	// Update is called once per frame
	void Update () {

		if(intervalTimer+interval<=Time.time)
		{
			intervalTimer = Time.time;
			interval = Random.Range(0,.5f);
			parachuter.transform.position = new Vector2(Random.Range(cam.ScreenToWorldPoint(new Vector2(0,0)).x,cam.ScreenToWorldPoint(new Vector2(Screen.width,0)).x),parachuter.transform.position.y);
			Instantiate(parachuter);
		}
	}
}
