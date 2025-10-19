using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPrincial;
    public GameObject loja;
    public GameObject creditos;
    public GameObject soundConfig;

    public Slider Upgradeinivicivel, Upgrademult;
    public void IniciarJogo()
    {
        SceneManager.LoadScene(1);
    }

    public void Loja()
    {
        menuPrincial.SetActive(false);
        loja.SetActive(true);
    }

    public void VoltandoLoja()
    {
        menuPrincial.SetActive(true);
        loja.SetActive(false);
    }


    public void Sound()
    {
        soundConfig.SetActive(true);
        menuPrincial.SetActive(false);
    }

    public void ExitSound()
    {
        soundConfig.SetActive(false);
        menuPrincial.SetActive(true);
    }


    public void EntrarCreditos()
    {
        creditos.SetActive(true);
        menuPrincial.SetActive(false);
    }

    public void SairCreditos()
    {
        creditos.SetActive(false);
        menuPrincial.SetActive(true);
    }

    public void UpgradeMult()
    {
        Upgrademult.value += 1;
    }

    public void UpgradeInv()
    {
        Upgradeinivicivel.value += 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
