using UnityEngine;
using System.Collections;

public class MainGUI : MonoBehaviour {

	public GUIStyle LabelStyle;

	void OnGUI(){

		if(Game.IsGameOver){
			//Draw gameover gui
			GUI.Label(new Rect(Screen.width*.1f,Screen.height*.1f,Screen.width,Screen.height),string.Format("Score:{0}\nBest:{1}",Game.LandedParachuters,Game.Record),LabelStyle);
			if(GUI.Button(new Rect(Screen.width*.25f,Screen.height*.4f,Screen.width*.5f,Screen.height*.1f),"Replay")){
				Replay();
			}
			if(GUI.Button(new Rect(Screen.width*.25f,Screen.height*.4f+Screen.height*.15f,Screen.width*.5f,Screen.height*.1f),"Rage quit!!!!")){
				Application.Quit();
			}

		}
		else
		{
			GUI.Label(new Rect(Screen.width*.025f,5,Screen.width,Screen.height),string.Format("{0}",Game.LandedParachuters),LabelStyle);
		}
	}
		
	void Replay()
	{
		Game.Reset();
		Application.LoadLevel(Application.loadedLevelName);
	}
}
