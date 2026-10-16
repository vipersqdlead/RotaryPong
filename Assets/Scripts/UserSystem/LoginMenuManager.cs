using RotaryPong;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginMenuManager : MonoBehaviour
{

    [SerializeField] Button[] userLoginButtons;
    [SerializeField] Button[] userCreateButtons;
    [SerializeField] InputField[] userCreateInputField;

    [SerializeField] string currentUserKey = "";

    [SerializeField] CreateUserPanel createUserPanel;

    private void Awake()
    {

    }

    private void Start()
    {
        RefreshSavefileList();
    }

    void RefreshSavefileList()
    {
        for (int i = 0; i < userLoginButtons.Length; i++)
        {
            userLoginButtons[i].gameObject.SetActive(UserDataManagerSingleton.Instance.CheckForSavefile(i));
            userCreateButtons[i].gameObject.SetActive(!UserDataManagerSingleton.Instance.CheckForSavefile(i));
        }
    }

    void OnLogin(int userID)
    {
        print("Log In Attempt!");

        PlayerPrefs.SetInt(currentUserKey, userID);
        UserDataManagerSingleton.Instance.SetUserID(userID);

        SceneManager.LoadScene(1);
        
    }

    void OnSignIn(string username)
    {
        print("Sign In Attempt!");

        // Error cases
        {
            if(username == "")
            {
                createUserPanel.ChangeTextMessage("Please enter a name", Color.red);

                return;
            }
            if (username == PlayerPrefs.GetString(CreateUserPanel.usernameKey1) || username == PlayerPrefs.GetString(CreateUserPanel.usernameKey2) || username == PlayerPrefs.GetString(CreateUserPanel.usernameKey3))
            {
                createUserPanel.ChangeTextMessage("The username is already being used", Color.red);

                return;
            }
        }

        // User Creation
        {
            if (PlayerPrefs.GetString(CreateUserPanel.usernameKey1) == null)
            {
                PlayerPrefs.SetString(CreateUserPanel.usernameKey1, username);
            }
            else if (PlayerPrefs.GetString(CreateUserPanel.usernameKey1) != null)
            {
                PlayerPrefs.SetString(CreateUserPanel.usernameKey2, username);
            }
            else if (PlayerPrefs.GetString(CreateUserPanel.usernameKey2) != null)
            {
                PlayerPrefs.SetString(CreateUserPanel.usernameKey3, username);
            }
            else
            {
                createUserPanel.ChangeTextMessage("Error!", Color.red);
                return;
            }
            createUserPanel.ChangeTextMessage("User succesfully created!", Color.black);
        }
    }

    private void OnDestroy()
    {
        //loginPanel.RemoveListenerToOnLoginPressed(OnLogin);
        //createUserPanel.RemoveListenerToOnCreatePressed(OnSignIn);
    }
}
