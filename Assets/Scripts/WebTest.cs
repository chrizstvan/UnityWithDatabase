using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTest : MonoBehaviour 
{

	// Use this for initialization
	IEnumerator Start () 
	{
		WWW request = new WWW("http://localhost:8888/sqlconnect/WebTest.php");
		yield return request;

		string[] webResult = request.text.Split('\t');
		Debug.Log(webResult[0]);
		int webNumber = Int32.Parse(webResult[1]);
		webNumber *= 2;
		Debug.Log(webNumber);
	}
	
}
