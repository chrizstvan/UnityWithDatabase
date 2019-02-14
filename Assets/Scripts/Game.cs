using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	[SerializeField] private Text _playerDisplay;
	[SerializeField] private Text _scoreDisplay;

	private void Awake()
	{
		if (DBManager.username == null)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}

		_playerDisplay.text = "Player : " + DBManager.username;
		_scoreDisplay.text = "Score : " + DBManager.score;
	}

	public void CallSaveData()
	{
		StartCoroutine(SavePlayerData());
	}

	IEnumerator SavePlayerData()
	{
		WWWForm form = new WWWForm();
		form.AddField("name", DBManager.username);
		form.AddField("score",DBManager.score);

		WWW www = new WWW("http://localhost:8888/sqlconnect/SaveData.php");
		yield return www;

		if (www.text == "0")
		{
			Debug.Log("Game Saved.");
		}
		else
		{
			Debug.Log("Save failed. Error #" + www.text);
		}
		
		DBManager.LogOut();
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}

	public void IncreaseScore()
	{
		DBManager.score++;
		_scoreDisplay.text = "Score : " + DBManager.score;
	}
}
