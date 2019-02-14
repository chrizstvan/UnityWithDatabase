using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour 
{
    [SerializeField] InputField _nameField;
    [SerializeField] InputField _passwordField;

    [SerializeField] Button _submitButton;

	public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", _nameField.text);
        form.AddField("password", _passwordField.text);

        WWW www = new WWW("http://localhost:8888/sqlconnect/Register.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("User created successfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation field #Error."+ www.text );
        }
    }

    public void VerifyInput()
    {
        _submitButton.interactable = (_nameField.text.Length >= 8 && _passwordField.text.Length >= 8);
    }
}
