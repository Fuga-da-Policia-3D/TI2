using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseGame;
    public GameObject menuSom;
    public GameObject pauseprincipal;
    public static Pause instacia;
    private bool isPaused = false;

    public void Awake()
    {
        instacia = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
           
        }
    }
    public void PauseScreen()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            PauseGame.SetActive(true);
            MovingThings.pausado = true;
        }
        else
        {
            Time.timeScale = 1;
            PauseGame.SetActive(false);
            MovingThings.pausado = false;
        }
    }
    public void Sair()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu inicial");
    }
    public void Continuar()
    {
        PauseScreen();
    }
    public void ConfigSom()
    {
        pauseprincipal.SetActive(false);
        menuSom.SetActive(true);
    }
    public void SairConfigSom()
    {
        pauseprincipal.SetActive(true);
        menuSom.SetActive(false);
    }

    public void Pausar()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            PauseGame.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PauseGame.SetActive(false);
        }
    }
}
