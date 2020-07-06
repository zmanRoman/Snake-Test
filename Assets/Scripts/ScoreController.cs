using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text ScoreText;

    private short _score;
    public short Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            UpdateUIScore(_score);
        }
    }

    private static ScoreController instance;
    public static ScoreController Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        Score = 0;
    }

    private void UpdateUIScore(short score)
    {
        ScoreText.text = score.ToString();
    }
}
