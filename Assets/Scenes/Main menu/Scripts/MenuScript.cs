using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-100,200,200),"Hi, idiots!"))
		{
			Debug.Log("11111");
			Application.LoadLevel("MainScene");
		}
	}
}