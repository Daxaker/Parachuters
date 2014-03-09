using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {

	// Use this for initialization

	int time =100;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(time--<=0){
			Destroy(gameObject);
				this.enabled = false;
		}
	}
}
