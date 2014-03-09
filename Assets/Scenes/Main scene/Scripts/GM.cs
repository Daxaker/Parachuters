using UnityEngine;
using System.Collections;

public class GM {

	public static int LandedParachuters{get;private set;}
	public static int CrachedParachuters{get;private set;}
	public static void ParachuterLanded()
	{
		LandedParachuters++;
	}
	public static void ParachuterCrash()
	{
		CrachedParachuters++;
	}
	public static void Reset()
	{
		LandedParachuters=CrachedParachuters=0;
	}
}
