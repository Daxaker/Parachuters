﻿using UnityEngine;
using System.Collections;

public class TapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit = new RaycastHit();
		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) {
				// Construct a ray from the current touch coordinates
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				if (Physics.Raycast(ray, out hit)) {
					hit.transform.gameObject.rigidbody2D.drag +=Random.Range(10,15);
				}
			}
		}
	}

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			gameObject.rigidbody2D.drag +=Random.Range(10,15);
		}
	}
}
