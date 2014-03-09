using UnityEngine;
using System.Collections;
using System;

public class CollisionBehavior : MonoBehaviour {

	float lastVelocityY;
	// Use this for initialization
	AudioSource Whaw;
	AudioSource Crash;
	bool isGrounded;
	void Start () {
		Whaw = GetComponents<AudioSource>()[1];
		Crash = GetComponents<AudioSource>()[2];
	}
	
	// Update is called once per frame
	void Update () {
		if(Game.IsPaused)
		{
			gameObject.rigidbody2D.isKinematic = true;
		}
		else
		{
			if(gameObject.rigidbody2D.isKinematic)
			{
				gameObject.rigidbody2D.isKinematic = false;
			}
			lastVelocityY = Math.Abs(gameObject.rigidbody2D.velocity.y);
			if(isGrounded)
			{
				var sign = Math.Sign (gameObject.transform.position.x);
				gameObject.transform.Translate(Time.deltaTime*2*sign,0,0);
			}
		}
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground"){
			if(lastVelocityY>1){
			//Debug.Log("I'm Crash!:(");
				Game.ParachuterCrash();
				Crash.Play();
				Destroy(gameObject,1);
				 
			}
			else{
				StartCoroutine(Landing());
				Destroy(gameObject,10);
				//Debug.Log("I'm Fine :)");
			}

		}
	}

	IEnumerator Landing()
	{
		Game.ParachuterLanded();
		Whaw.Play();
		yield return new WaitForSeconds(2);
		isGrounded = true;
	}
}
