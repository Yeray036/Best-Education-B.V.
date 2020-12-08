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
    public PlayerData (Player player)
    {
        username = player.username;
        email = player.email;
        score = player.score;
    }
}
