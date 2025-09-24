using UnityEngine;

public class Score : MonoBehaviour
{
    public static int scoreCalculo = 0;
    public static int coinsCalculo = 0;
    static float multiplyer = 1;

    private void Start()
    {
        
        
    }
    private void Update()
    {
        ScoreMaking();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Moedas")
        {
            coinsCalculo++;
            Destroy(other.gameObject);
            GameController.instancia.CoinCount();
        }
    }
    private void ScoreMaking()
    {
        scoreCalculo = Mathf.FloorToInt(transform.position.x);
        //print(scoreCalculo);
        GameController.instancia.ScoreCount();
    }
}
