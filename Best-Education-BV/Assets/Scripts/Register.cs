using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField usernameField;
    public InputField emailField;
    public Text errorMessage;
    public int score = 0;

    public void SaveNewPlayer()
    {
        try
        {
            if (UserExists() == true)
            {
                errorMessage.text = "User already exists";
            }
            else
            {
                if (usernameField.text != string.Empty && emailField.text != string.Empty)
                {
                    if (ValidateEmail(emailField.text))
                    {
                        Player newPlayer = new Player();
                        newPlayer.username = usernameField.text;
                        newPlayer.email = emailField.text;
                        newPlayer.score = score;
                        SaveSystem.SavePlayer(newPlayer);
                        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                        errorMessage.text = "";
                    }
                    else
                    {
                        errorMessage.text = "Invalid email";
                    }
                }
                else
                {
                    errorMessage.text = "Invalid input";
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public bool UserExists()
    {
        try
        {
            PlayerData currentPlayer = SaveSystem.LoadPlayer();
            if (currentPlayer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            return false;
        }
    }

    public bool ValidateEmail(string email)
    {
        try
        {
            var emailad = new System.Net.Mail.MailAddress(email);
            return emailad.Address == email;
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            return false;
        }
    }
}
