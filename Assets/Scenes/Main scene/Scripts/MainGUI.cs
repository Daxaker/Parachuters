using UnityEngine;
using System.Collections;

public class MainGUI : MonoBehaviour {

	public GUIStyle LabelStyle;
	public GUIStyle PlayButton;
	public GUIStyle ExitButton;
	public GUIStyle ReplayButton;
	public GUIStyle Logo;
	public GUIStyle[] SoundButton;
	public GUIStyle[] PauseButton;
	float cameraSpeedMultiply = 5;
	bool starting;
	static bool mainMenu = true;
	float logoWndWidth;
	float logoWndHeight;
	float virtualWidth = 800.0f;	
	float virtualHeight =450.0f;
	void OnStart()
	{

	}

	void OnLevelWasLoaded()
	{
		if(!mainMenu)
		{
			Camera.main.transform.position = new Vector3(0,0f,-10f);
		}
	}

	void OnGUI(){
		var svdMtrx = GUI.matrix;
		var matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
		GUI.matrix = matrix;
		if(mainMenu||Game.IsGameOver)
		{
			logoWndWidth = virtualWidth*.36f;
			logoWndHeight = virtualHeight*.8f;
			GUI.Window(0,new Rect(virtualWidth*.35f,virtualHeight*.1f,logoWndWidth,logoWndHeight),MainForm,"",Logo);
		}
		else
		{
			//Score
			GUI.Label(new Rect(virtualWidth*.025f,5,virtualWidth,virtualHeight),string.Format("SCORE:{0}",Game.LandedParachuters),LabelStyle);
			//Pause
			if(GUI.Button(new Rect(virtualWidth*.9f,virtualHeight*.02f,virtualWidth*.1f,virtualWidth*.1f),"",PauseButton[Game.IsPaused?1:0]))
			{
				Game.InvertPause();
			}
		}
		if(Game.IsPaused||mainMenu){
			//Sound
			if(GUI.Button(new Rect(virtualWidth*.02f,virtualHeight*.8f,virtualWidth*.15f,virtualHeight*.15f),"",SoundButton[Game.IsSoundEnabled?0:1]))
			{
				Game.InvertSoundSettings();
			}
		}
		if(Game.IsGameOver){

			//Summary
			GUI.Label(new Rect(virtualWidth*.1f,virtualHeight*.1f,virtualWidth,virtualHeight),string.Format("Score:{0}\nBest:{1}",Game.LandedParachuters,Game.Record),LabelStyle);
		}

		GUI.matrix = svdMtrx;
	}

	void MainForm(int wnd)
	{

		if(GUI.Button(new Rect(logoWndWidth*.3f,logoWndHeight*.38f,logoWndWidth*.43f,logoWndWidth*.43f),"",PlayButton))
		{
			if(Game.IsGameOver){
				Replay();
			}
			else{
			GameStart();
			}
		}
		if(GUI.Button(new Rect(logoWndWidth*.38f,logoWndHeight*.4f+logoWndHeight*.28f,logoWndWidth*.4f,logoWndWidth*.4f),"",ExitButton))
		{
			Application.Quit();
		}
	}

	void FixedUpdate()
	{
		if(starting)
		{
			Camera.main.transform.Translate(new Vector2(0f,-Time.fixedDeltaTime*cameraSpeedMultiply));
			if(Camera.main.transform.position.y<=0){
				starting = false;
				Starting();
			}
		}
	}

	void GameStart()
	{
		starting = true;
		mainMenu = false;
	}

	void Starting()
	{

		//tutorial mod on only before this
		Game.Start();
		//StartCoroutine(Wait ());
		//Game.Pause();
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2);
	}

	void Replay()
	{
		Game.Reset();
		Application.LoadLevel(Application.loadedLevelName);
	}
}
