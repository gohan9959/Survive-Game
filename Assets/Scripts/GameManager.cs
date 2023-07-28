using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    private int score, lives;
    private float enemySpeed, powerUpSpawnTime, debrisSpawnTime;
    private int immunityTimer;
    private int lightBulletCount, darkBulletCount;
    private UIHandler uIHandler;
    // Start is called before the first frame update
    void Start()
    {
        lightBulletCount = 3;
        darkBulletCount = 3;
        lives = 5;
        score = 0;
        uIHandler = FindObjectOfType<UIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        GameObject.Find("Title Screen").SetActive(false);
        isGameActive = true;
        uIHandler.UpdateScoreUI(score);
        uIHandler.UpdateLivesUI(lives);
        uIHandler.UpdateBulletsUI(lightBulletCount, Enumerations.BulletType.Light);
        uIHandler.UpdateBulletsUI(darkBulletCount, Enumerations.BulletType.Dark);
    }

    public void GameOver()
    {
        isGameActive = false;
    }

    public void UpdateScore(int update)
    {
        score += update;
        uIHandler.UpdateScoreUI(score);
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateLives(int update)
    {
        lives += update;
        uIHandler.UpdateLivesUI(lives);
    }

    public int GetLives()
    {
        return lives;
    }

    public void UpdateBulletCount(int update, Enumerations.BulletType type)
    {
        if (type == Enumerations.BulletType.Light)
        {
            lightBulletCount += update;
            uIHandler.UpdateBulletsUI(lightBulletCount, Enumerations.BulletType.Light);
        }
        else if (type == Enumerations.BulletType.Dark)
        {
            darkBulletCount += update;
            uIHandler.UpdateBulletsUI(darkBulletCount, Enumerations.BulletType.Dark);
        }
    }
    public int GetBulletCount(Enumerations.BulletType type)
    {
        int count = 0;
        if(type == Enumerations.BulletType.Light)
        {
            count = lightBulletCount;
        }
        else if(type == Enumerations.BulletType.Dark)
        {
            count = darkBulletCount;
        }
        return count;
    }

    public int GetImmunityTimer()
    {
        return immunityTimer;
    }
}
