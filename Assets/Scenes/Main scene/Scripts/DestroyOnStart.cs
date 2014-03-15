using UnityEngine;
using System.Collections;

public class DestroyOnStart : MonoBehaviour {
	
	void Update () {
		if(Game.IsStarted)
		{
			Destroy(gameObject);
		}
	}
}
