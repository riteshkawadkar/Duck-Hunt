using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject duckPrefab;
    public GameObject WinningStatus;
    public GameObject LoosingStatus;
    public GameObject CountdownTimer;

    public Text score;
    public int scoreCount = 0;

    bool hasWon;
    bool hasPlayedWinLoose;
    public bool hasTimeUp;



    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Spawn", 1f, 0.5f);
        SoundManager.backgroundAudioSource.Play();
    }

    public void StartGame()
    {
        CountdownTimer.SetActive(true);
        InvokeRepeating("Spawn", 0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWon)
        {
            if (hasPlayedWinLoose == false)
            {
                hasPlayedWinLoose = true;
                SoundManager.backgroundAudioSource.Stop();
                SoundManager.youWinAudioSource.Play();
            }
            CancelInvoke("Spawn");
            WinningStatus.SetActive(true);
            //<a href='https://pngtree.com/so/brush'>brush png from pngtree.com</a>
        }

        if (hasTimeUp)
        {
            //check if score is not equal to 10 then you loose
            if (scoreCount < 20)
            {
                if (hasPlayedWinLoose==false)
                {
                    CameraShake.Shake();
                    hasPlayedWinLoose = true;
                    SoundManager.backgroundAudioSource.Stop();
                    SoundManager.youLoseAudioSource.Play();
                }
                
                CancelInvoke("Spawn");
                LoosingStatus.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.shotAudioSource.Play();
        }


        //quit App on back button press
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

    void Spawn()
    {
        float randX = Random.Range(-8f, 8f);
        float randY = Random.Range(-4f, 4f);
        Vector3 spawnPostion = new Vector3(randX, randY, 0f);

        Instantiate(duckPrefab, spawnPostion, Quaternion.identity);
    }

    public void updateScore()
    {
        scoreCount++;
        score.text = scoreCount.ToString();
        SoundManager.quackAudioSource.Play();

        if (scoreCount==20)
        {
            hasWon = true;
        }
    }

    IEnumerator StopAudio(AudioSource _audio)
    {
        _audio.Stop();
        yield return new WaitForSeconds(1);

    }

}
