using UnityEngine;
using System.Collections;
using System;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(TapController))]
public class ParachuterBehavior : MonoBehaviour {

	float lastVelocityY;
	// Use this for initialization
	AudioSource WhawSound;
	AudioSource CrashSound;
	bool isGrounded;
	public Sprite deadSprite;
	public Sprite LandedSprite;
	SpriteRenderer spriteRenderer;
	void Start () {
		WhawSound = GetComponents<AudioSource>()[1];
		CrashSound = GetComponents<AudioSource>()[2];
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Game.IsStarted){
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
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(!Game.IsGameOver){
			if(collision.gameObject.tag == "Ground"){
				if(lastVelocityY>1){
				//Debug.Log("I'm Crash!:(");
					Game.ParachuterCrash();
					spriteRenderer.sprite = deadSprite;
					CrashSound.Play();
					Destroy(gameObject,1);
					 
				}
				else{
					spriteRenderer.sprite = LandedSprite;
					StartCoroutine(Landing());
					Destroy(gameObject,10);
					//Debug.Log("I'm Fine :)");
				}

			}
		}
	}

	IEnumerator Landing()
	{
		Game.ParachuterLanded();
		WhawSound.Play();
		yield return new WaitForSeconds(2);
		isGrounded = true;
	}
}
