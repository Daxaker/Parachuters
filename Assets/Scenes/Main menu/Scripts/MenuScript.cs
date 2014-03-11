using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	void OnGUI()
	{

		if(GUI.Button(new Rect(Screen.width*.25f,Screen.height*.4f,Screen.width*.5f,Screen.height*.1f),"Play"))
		{
			Application.LoadLevel("MainScene");
		}
		if(GUI.Button(new Rect(Screen.width*.25f,Screen.height*.4f+Screen.height*.15f,Screen.width*.5f,Screen.height*.1f),"Exit"))
		{
			Application.Quit();
		}

	}
}