using UnityEngine;
using System.Collections;

public class TapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			gameObject.rigidbody2D.drag +=Random.Range(5,10);
		}
	}
}
