using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]
public class TapController : MonoBehaviour {

	// Use this for initialization
	[HideInInspector]
	public bool parachuteOpened;
	public Sprite parachuteOpenSprite;
	SpriteRenderer spriteRenderer;
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit = new RaycastHit();
		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) {
				// Construct a ray from the current touch coordinates
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				if (Physics.Raycast(ray, out hit)) {
					if(hit.transform.gameObject.tag == "Player")
					ApplyParachute(hit.transform.gameObject.rigidbody2D);
				}
			}
		}
	}

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			ApplyParachute(gameObject.rigidbody2D);
		}
	}

	void ApplyParachute(Rigidbody2D rigidbody)
	{
		if(!parachuteOpened&&!Game.IsPaused)
		{
			parachuteOpened = true;
			rigidbody2D.drag +=Random.Range(10,15);
			spriteRenderer.sprite = parachuteOpenSprite;
		}
	}
}
