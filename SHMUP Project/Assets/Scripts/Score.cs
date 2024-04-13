using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
