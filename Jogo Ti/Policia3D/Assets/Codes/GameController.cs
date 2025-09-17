using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public static GameController instancia;
    public void Awake()
    {
        instancia = this;
    }
    public void ScoreCount()
    {
        scoreText.text = "Score:" + Score.scoreCalculo.ToString();
    }

    public void CoinCount()
    {
        coinsText.text = "Coins:" + Score.coinsCalculo.ToString();
    }

}
