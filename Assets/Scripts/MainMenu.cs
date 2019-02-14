using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _playerDisplay;

    private void Start()
    {
        _playerDisplay.text = "Player : " + DBManager.username;
    }


    public void SceneChange(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
