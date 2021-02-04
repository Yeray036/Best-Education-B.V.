using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string username;
    public string email;
    public int score;

    //Calling constructer. with Player object as parameter.
	//this is to pass the player save data into a playerData object.
    public PlayerData (Player player)
    {
        username = player.username;
        email = player.email;
        score = player.score;
    }
}
