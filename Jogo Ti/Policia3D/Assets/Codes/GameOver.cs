/*
 Código feito por Gabriel Ramos Torres
*/
using UnityEngine;
using UnityEngine.InputSystem.XR;

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
        gameOver.SetActive(true);
    }
}
