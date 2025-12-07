/*
 Código feito por Gabriel Ramos Torres
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public static GameOver instacia;
    public GameObject pause;
    public void Awake()
    {
        instacia = this;
    }
    private void Start()
    {
        pause.SetActive(true);
    }
    public void GameOverScreen()
    {
        Score.scoreCalculo = 0;
        pause.SetActive(false);
        gameOver.SetActive(true);
       
    }
    public void Sair()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("test");
    }
}
