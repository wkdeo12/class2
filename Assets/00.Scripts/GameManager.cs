using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject enemyPrefab;
    public float boundryX;
    public float boundryY;
    public float spwanTime = 1;
    public float currentSpwanTime = 1;
    public Text timeText;
    public Text evadeText;
    private float timer;
    private int evadeCount;
    public static GameManager Instance;
    public AudioSource AudioSource;
    
    
    public AudioClip phase2BGM;
    private void Awake()
    {
        Instance = this;
        AudioSource = GetComponent<AudioSource>();
    }

    public int EvadeCount
    {
        get
        {
            return evadeCount;
        }

        set
        {
            evadeCount = value;
            evadeText.text = evadeCount.ToString();
        }
    }

    private bool gameover = false;
    private bool phase2 = false;
    private void Update()
    {
        if (gameover)
        {
            return;
        }
        currentSpwanTime -= Time.deltaTime;
        
        if (currentSpwanTime <= 0)
        {
            Spwan();
            currentSpwanTime = spwanTime;
        }
        timeText.text = (timer += Time.deltaTime).ToString();
        if (timer > 30f)
        {
            if (!phase2)
            {
                AudioSource.clip = phase2BGM;
                AudioSource.Play();
                spwanTime = 0.1f;
                phase2 = true;
            }
        }
    }
    
    
    private void Spwan()
    {
        float posX = UnityEngine.Random.Range(-boundryX, boundryX);
        var go = Instantiate(enemyPrefab);
        go.transform.position = new Vector3(posX, boundryY, 0f);
    }

    public GameObject gameoverWindow;
    public Text gameoverDescription;
    public void GameOver()
    {
        gameover = true;
        gameoverWindow.SetActive(true);
        gameoverDescription.text = "당신은   " + timer.ToString() + "초 동안  " + evadeCount.ToString() + "개의 벽돌을 피하고 죽었습니다.";
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
