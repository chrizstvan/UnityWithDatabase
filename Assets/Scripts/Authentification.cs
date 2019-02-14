using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Authentification : MonoBehaviour 
{
    public Text textEmail;
    public Text textPassword;
    public Text textFeedback;

    WWWForm _form;

    public void LoginButtonTapped()
    {
        StartCoroutine(LoginRequest());
    }

    public IEnumerator LoginRequest()
    {
        string email = textEmail.text;
        string password = textPassword.text;

        _form = new WWWForm();

        _form.AddField("email", email);
        _form.AddField("password", password);

        WWW _url = new WWW("http://localhost:8888/action_login.php", _form);
        yield return _url;

        if (string.IsNullOrEmpty(_url.error))
        {
            //success
            if(_url.text.Contains("Invalid email or password."))
            {
                textFeedback.text = "Invalid email or password.";
            }
            else
            {
                textFeedback.text = "Login Successful...";
                //TODO: launch the game
            }
        }
        else
        {
            //error
            textFeedback.text = "An error occured";
        }
    }
}
