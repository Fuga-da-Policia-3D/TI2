using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int scoreCalculo = 0;         // Distance-based score
    public static int coinsCalculo = 0;         // Separate coin count
    public static int multiplyer = 1;           // Score multiplier

    private float lastXPosition = 0f;           // Last recorded X position
    private float scoreAccumulator = 0f;        // Tracks exact distance to avoid rounding errors

    private void Start()
    {
        lastXPosition = transform.position.x;
    }

    private void Update()
    {
        UpdateScoreByDistance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moedas"))
        {
            coinsCalculo++;
            Destroy(other.gameObject);
            GameController.instancia.CoinCount();
        }
    }

    private void UpdateScoreByDistance()
    {
        float currentX = transform.position.x;
        float distanceMoved = currentX - lastXPosition;

        if (distanceMoved > 0f)
        {
            // Accumulate distance
            scoreAccumulator += distanceMoved * multiplyer;

            // Add score in whole number steps (e.g. every 1 unit of distance * multiplier)
            int pointsToAdd = Mathf.FloorToInt(scoreAccumulator);
            if (pointsToAdd > 0)
            {
                scoreCalculo += pointsToAdd;
                scoreAccumulator -= pointsToAdd;

                GameController.instancia.ScoreCount();

                // Update high score if needed
                if (scoreCalculo > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", scoreCalculo);
                    PlayerPrefs.Save();
                    GameController.instancia.LoadHighScore();
                }
            }

            lastXPosition = currentX;
        }
    }
}
/*private void ScoreMaking()
{
    scoreCalculo = Mathf.FloorToInt(transform.position.x * multiplyer);

    //print(scoreCalculo);
    GameController.instancia.ScoreCount();

    if (scoreCalculo > PlayerPrefs.GetInt("HighScore", 0))
    {
        PlayerPrefs.SetInt("HighScore", scoreCalculo);
        PlayerPrefs.Save();
        GameController.instancia.LoadHighScore();
    }*/