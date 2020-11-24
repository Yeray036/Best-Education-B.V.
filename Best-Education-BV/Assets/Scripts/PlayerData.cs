using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
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
