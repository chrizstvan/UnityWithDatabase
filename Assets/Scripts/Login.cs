using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

	[SerializeField] InputField _nameField;
	[SerializeField] InputField _passwordField;

	[SerializeField] Button _submitButton;

	public void CallLogin()
	{
		StartCoroutine(LoginPlayer());
	}

	IEnumerator LoginPlayer()
	{
		WWWForm form = new WWWForm();
		form.AddField("name", _nameField.text);
		form.AddField("password", _passwordField.text);
		WWW www = new WWW("http://localhost:8888/sqlconnect/Login.php", form);
		yield return www;

		if (www.text[0] == '0')
		{
			DBManager.username = _nameField.text;
			DBManager.score = Int32.Parse(www.text.Split('\t')[1]);
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}
		else
		{
			Debug.Log("User login failed. Error #" + www.text);
		}
	}
	
	public void VerifyInput()
	{
		_submitButton.interactable = (_nameField.text.Length >= 8 && _passwordField.text.Length >= 8);
	}
}
