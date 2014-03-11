using UnityEngine;
using System.Collections;

public class MainGUI : MonoBehaviour {

	public GUIStyle LabelStyle;

	void OnGUI(){
		GUI.Label(new Rect(20,5,Screen.width,Screen.height),string.Format("{0}",Game.LandedParachuters),LabelStyle);
		if(Game.IsGameOver){
			//Draw gameover gui
			if(GUI.Button(new Rect(Screen.width*.25f,Screen.height*.4f,Screen.width*.5f,Screen.height*.1f),"Repeat")){
				Reload(Application.loadedLevelName);
			}
			if(GUI.Button(new Rect(Screen.width*.25f,Screen.height*.4f+Screen.height*.15f,Screen.width*.5f,Screen.height*.1f),"Main menu")){
				Reload ("MainMenu");
			}
		}
		if(GUI.Button(new Rect(Screen.width-40,25,20,20),"||"))
		{
			Game.InvertPause();
		}
	}
		
	void Reload(string level)
	{
		Game.Reset();
		Application.LoadLevel(level);
	}
}
