using UnityEngine;
using System.Collections;
using System;

public class CollisionBehavior : MonoBehaviour {

	float lastVelocityY;
	// Use this for initialization
	AudioSource Whaw;
	bool isGrounded;
	void Start () {
		Whaw = GetComponents<AudioSource>()[1];
	}
	
	// Update is called once per frame
	void Update () {
		if(isGrounded)
		{
			var sign = Math.Sign (gameObject.transform.position.x);
			gameObject.transform.Translate(Time.deltaTime*2*sign,0,0);
		}
	}
	void FixedUpdate()
	{
		lastVelocityY = Math.Abs(gameObject.rigidbody2D.velocity.y);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground"){
			if(lastVelocityY>1){
			//Debug.Log("I'm Crash!:(");
				GM.ParachuterCrash();
				Destroy(gameObject,1);
				 
			}
			else{
				GM.AnotherParachuterLanded();
				Whaw.Play();
				StartCoroutine(Landing());
				Destroy(gameObject,10);
				//Debug.Log("I'm Fine :)");
			}

		}
	}

	IEnumerator Landing()
	{
		yield return new WaitForSeconds(2);
		isGrounded = true;
	}
}
