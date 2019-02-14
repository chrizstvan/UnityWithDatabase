using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BundleLoader : MonoBehaviour
{

	public string bundleURL;
	private AssetBundle bundle;

	// Use this for initialization
	private IEnumerator Start () 
	{
		WWW www = new WWW(bundleURL);
		yield return www;

		if (www.error != null)
		{
			throw new SystemException("There's an error " + www.error );
		}

		bundle = www.assetBundle;
	}

	public void Spawn(string assetName)
	{
		if (assetName == String.Empty)
		{
			Instantiate(bundle.mainAsset);
		}
		else
		{
			Instantiate(bundle.LoadAsset(assetName));
		}
	}
}
