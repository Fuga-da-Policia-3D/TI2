using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI TempoPowerUP;
    public static GameController instancia;

    private int textoadd;

    private string multiplierText = "";
    private string invincibilityText = "";


    public void Awake()
    {
        instancia = this;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            LoadScore();
        }
        else
        {
            ScoreCount();
        }
        if (PlayerPrefs.HasKey("HighScore"))
        {
            LoadHighScore();
        }
        if (PlayerPrefs.HasKey("Coins"))
        {
            LoadCoins();
        }
        else
        {
            CoinCount();
        }
    }

    private void Update()
    {
        
    }
    public void ScoreCount()
    {
        scoreText.text = "Score:" + Score.scoreCalculo.ToString();
        PlayerPrefs.SetInt("Score", Score.scoreCalculo);
        PlayerPrefs.Save();

        int HighScore = PlayerPrefs.GetInt("HighScore", Score.scoreCalculo);
        if(Score.scoreCalculo > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", Score.scoreCalculo);
            HighScore = Score.scoreCalculo;
        }
        PlayerPrefs.Save();
        LoadHighScore();
    }

    public void CoinCount()
    {
        coinsText.text = "Coins:" + Score.coinsCalculo.ToString();
        PlayerPrefs.SetInt("Coins", Score.coinsCalculo);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        //Score.scoreCalculo = PlayerPrefs.GetInt("Score", 0);
        //ScoreCount();

    }
    
    public void LoadCoins()
    {
        Score.coinsCalculo = PlayerPrefs.GetInt("Coins", 0);
        CoinCount();
    }
    public void LoadHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        if (HighScoreText != null)
        {
            HighScoreText.text = "High Score: " + highScore.ToString();
        }
    }


    public void TempoDoPowerUp(int ID, float Tempo)
    {
        if (ID == 1) 
        {
            if (Tempo <= 0)
            {
                multiplierText = "";
            }
            else
            {
                multiplierText = "Multiplier: " + Mathf.CeilToInt(Tempo) + "s";
            }
        }
        else if (ID == 2) 
        {
            if (Tempo <= 0)
            {
                invincibilityText = "";
            }
            else
            {
                invincibilityText = "Invincibility: " + Mathf.CeilToInt(Tempo) + "s";
            }
        }



       
        string combined = "";

        if (!string.IsNullOrEmpty(multiplierText))
        {
            combined += multiplierText + "\n";
        }

        if (!string.IsNullOrEmpty(invincibilityText))
        {
            combined += invincibilityText;
        }

        TempoPowerUP.text = combined;
    }





}
