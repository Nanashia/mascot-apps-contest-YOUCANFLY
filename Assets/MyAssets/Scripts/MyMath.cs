using UnityEngine;
using System.Collections;

public class MyMath {

	public static float NSin(float a)
	{
		return Mathf.Sin(a * 2 * Mathf.PI );
	}

	public static float NCos(float a)
	{
		return Mathf.Cos(a * 2 * Mathf.PI);
	}

	public static float frameIn(int interval)
	{
		return (Time.frameCount % interval) / (float)interval;
	}

	public static float PosSin(float a)
	{
		return 1 + Mathf.Sin(a);
	}
}
