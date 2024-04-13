using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Player Data", menuName = "Player Data", order = 51)]
//Display Player Info
public class PlayerData : ScriptableObject
{
    //Initialize Data
    [SerializeField]
    private int lives;

    [SerializeField]
    private int score;

    [SerializeField]
    private string powerUp;

    public int PlayerLives
    {
        get { return lives; }
    }

    public int PlayerScore
    {
        get { return score; }
    }

    public string PlayerPowerUp
    {
        get { return powerUp; }
    }
}
