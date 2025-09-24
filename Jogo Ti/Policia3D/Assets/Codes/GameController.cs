using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public static GameController instancia;
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
        if (PlayerPrefs.HasKey("Coins"))
        {
            LoadCoins();
        }
        else
        {
            CoinCount();
        }
    }
    public void ScoreCount()
    {
        scoreText.text = "Score:" + Score.scoreCalculo.ToString();
        PlayerPrefs.SetInt("Score", Score.scoreCalculo);
        PlayerPrefs.Save();
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

}
