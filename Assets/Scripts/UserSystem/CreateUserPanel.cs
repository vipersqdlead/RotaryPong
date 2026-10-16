using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;

public class CreateUserPanel : MonoBehaviour
{
    //[SerializeField] TMPro.TMP_InputField iF_Username, iF_Mail, iF_Password, iF_PasswordConfirm;
    [SerializeField] InputField iF_Username;
    [SerializeField] /*TMP_*/Text message;

    public string userName, mail, password, passwordConfirm;

    public const string usernameKey1 = "username1";
    public const string usernameKey2 = "username2";
    public const string usernameKey3 = "username3";

    private void Awake()
    {
        iF_Username.onValueChanged.AddListener(ChangeUsername);
    }

    void ChangeUsername(string val)
    {
        userName = val;
    }

    void ChangeMail(string val)
    {
        mail = val;

    }

    void ChangePass(string val)
    {
        password = val;

    }

    void ChangePassConfirmation(string val)
    {
        passwordConfirm = val;

    }

    [SerializeField] Button button_Create;
    public delegate void OnCreatePressed(string username, string mail, string password, string passwordConfirmation);
    OnCreatePressed onCreatePressed;

    public void OnButtonCreatePressed()
    {
        onCreatePressed?.Invoke(userName, mail, password, passwordConfirm);
    }

    public void AddListenerToOnCreatePressed(OnCreatePressed listener)
    {
        onCreatePressed += listener;
    }

    public void RemoveListenerToOnCreatePressed(OnCreatePressed listener)
    {
        onCreatePressed -= listener;
    }
    public void ChangeTextMessage(string text, Color color)
    {
        message.text = text;
        message.color = color;
    }
}
