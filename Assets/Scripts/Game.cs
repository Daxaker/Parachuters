using UnityEngine;
using System.Collections;

public class Game {

	static Game()
	{
		IsPaused = false;
	}
	public static int Record {get; private set;}
	public static int LandedParachuters{get;private set;}
	public static int CrachedParachuters{get;private set;}
	public static bool IsPaused{get;private set;}
	public static bool IsGameOver{get;private set;}
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
	}
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
}
