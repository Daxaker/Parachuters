using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-100,200,100),"Play"))
		{
			Application.LoadLevel("MainScene");
		}
		if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2+5,200,100),"Exit"))
		{
			Application.Quit();
		}

	}
}