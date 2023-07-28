using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject inGameUI;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI lives;
    [SerializeField] TextMeshProUGUI lightBullets;
    [SerializeField] TextMeshProUGUI darkBullets;
    [SerializeField] TextMeshProUGUI immunityTimer;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            inGameUI.SetActive(true);
        }
    }

    public void UpdateScoreUI(int updateScore)
    {
        score.text = "Score: " + updateScore;
    }

    public void UpdateLivesUI(int updateLives)
    {
        lives.text = "Lives: " + updateLives;
    }

    public void UpdateBulletsUI(int updateBullets, Enumerations.BulletType type)
    {
        if(type == Enumerations.BulletType.Light)
        {
            lightBullets.text = "Light Bullets Left: " + updateBullets;
        }
        if (type == Enumerations.BulletType.Dark)
        {
            darkBullets.text = "Dark Bullets Left: " + updateBullets;
        }
    }

    void UpdateImmunityUI()
    {

    }
}
