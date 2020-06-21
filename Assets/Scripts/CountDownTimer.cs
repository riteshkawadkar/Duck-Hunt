using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private Image countdownCircleTimer;
    [SerializeField] private Text countdownText;
    [SerializeField] private float startTime = 60.0f;

    private float currentTime;
    private bool updateTime;

    GameManager gm;

    private void Start()
    {
       
    }

    private void OnEnable()
    {
        gm = GameObject.FindObjectOfType<GameManager>();

        currentTime = startTime;
        countdownCircleTimer.fillAmount = 1.0f;
        // Easy way to represent only the seconds and skip the
        // float     
        countdownText.text = (int)currentTime + "s";
        // update the countdown on the update
        updateTime = true;
    }

    private void Update()
    {
        if (updateTime)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f)
            {
                // Stop the countdown timer              
                updateTime = false;
                currentTime = 0.0f;

                gm.hasTimeUp = true;
            }

            countdownText.text = (int)currentTime + "s";
            float normalizedValue = Mathf.Clamp(
                     currentTime / startTime, 0.0f, 1.0f);
            countdownCircleTimer.fillAmount = normalizedValue;
        }
    }
}
