using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
	//this script will handle the login scene wich contains a email input and will check if email is found in player save data
    public InputField emailInput;
    public Text errorMessage;

   public void CheckLogin()
    {
        try
        {
            PlayerData currentUser = SaveSystem.LoadPlayer();
            if (currentUser != null)
            {
                if (currentUser.email.Equals(emailInput.text))
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                    errorMessage.text = "";
                }
                else
                {
                    errorMessage.text = "Wrong email";
                }
            }
            else
            {
                errorMessage.text = "No user found.";
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
