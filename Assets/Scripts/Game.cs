using UnityEngine;
using System.Collections;

public class Game {

	static Game(){
		IsTutorialMod = true;
		if(PlayerPrefs.HasKey("sound")){
		IsSoundEnabled = PlayerPrefs.GetInt("sound")==1;
		}
		else
		{
			IsSoundEnabled = true;
		}
		SwitchSound(IsSoundEnabled);
	}
	public static int Record {get; private set;}
	public static int LandedParachuters{get;private set;}
	public static int CrachedParachuters{get;private set;}
	public static bool IsPaused{get;private set;}
	public static bool IsGameOver{get;private set;}
	public static bool IsStarted{get;private set;}
	public static bool IsTutorialMod{get;private set;}
	public static bool IsSoundEnabled{get;private set;}

	public static void ParachuterLanded()
	{
		LandedParachuters++;
	}
	public static void ParachuterCrash()
	{
		CrachedParachuters++;

		GameOver();
	}
	public static void Reset()
	{
		IsGameOver = false;
		LandedParachuters=CrachedParachuters=0;
		IsTutorialMod = false;
	}

	#region Pause
	public static void Pause()
	{
		IsPaused = true;
	}
	public static void Unpause()
	{
		IsPaused = false;
	}
	public static void InvertPause()
	{
		IsPaused = !IsPaused;
	}
	#endregion

	public static void GameOver()
	{
		IsGameOver = true;
		UpdateRecord();
	}
	public static void UpdateRecord()
	{
		if(LandedParachuters>Record)
		{
			PlayerPrefs.SetInt("best",LandedParachuters);
		}
		Record = PlayerPrefs.GetInt("best");
	}
	public static void Start()
	{
		IsStarted = true;
		IsTutorialMod = false;
	}
	public static void InvertSoundSettings()
	{
		IsSoundEnabled = !IsSoundEnabled;
		PlayerPrefs.SetInt("sound",IsSoundEnabled?1:0);
		SwitchSound(IsSoundEnabled);
	}
	static void SwitchSound(bool enebled)
	{
		AudioListener.pause = !IsSoundEnabled;
	}
}
