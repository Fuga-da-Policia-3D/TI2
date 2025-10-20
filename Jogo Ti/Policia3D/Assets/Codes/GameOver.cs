/*
 Código feito por Gabriel Ramos Torres
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public static GameOver instacia;
    public void Awake()
    {
        instacia = this;
    }
    public void GameOverScreen()
    {
        Score.scoreCalculo = 0;
        gameOver.SetActive(true);
       
    }
    public void Sair()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("test");
    }
}
