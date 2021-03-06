﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadyCountdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public int countdownTimer = 3;

    GameManager gm;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine(Countdown(countdownTimer));
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {

            // display something...
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

        gameObject.SetActive(false);

        // count down is finished...
        gm.StartGame();
    }

    

}
