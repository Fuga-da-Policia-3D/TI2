
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPrincial;
    public GameObject loja;
    public GameObject creditos;
    public GameObject soundConfig;
    public TextMeshProUGUI textomoney;

    public int upgradetempoI = 0,upgradetempoM=0,maismult = 0;
    public Slider Upgradeinivicivel, Upgrademult;


    private void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            LoadCoins();
        }
        else
        {
            CoinCount();
        }
        if (PlayerPrefs.HasKey("ValorDoUpgradeMult"))
        {
            Upgrademult.value = PlayerPrefs.GetFloat("ValorDoUpgradeMult");
        }
        if (PlayerPrefs.HasKey("ValordoUpgradeInv"))
        {
            Upgradeinivicivel.value = PlayerPrefs.GetFloat("ValordoUpgradeInv");
        }
    }


    public void LoadCoins()
    {
        Score.coinsCalculo = PlayerPrefs.GetInt("Coins", 0);
        CoinCount();
    }

    public void CoinCount()
    {
        textomoney.text = "Coins:" + Score.coinsCalculo.ToString();
        PlayerPrefs.SetInt("Coins", Score.coinsCalculo);
        PlayerPrefs.Save();
    }


    public void IniciarJogo()
    {
        SceneManager.LoadScene(1);
        Score.scoreCalculo = 0;
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
        if(Upgrademult.value == 0 && Score.coinsCalculo >= 100)
        {
            Score.coinsCalculo -= 100;
            CoinCount();
            Upgrademult.value += 1;
            upgradetempoM = 1;
            PlayerPrefs.SetInt("PowerUPtempoMult", upgradetempoM);
            PlayerPrefs.SetFloat("ValorDoUpgradeMult", Upgrademult.value);
            
        }
        else if (Upgrademult.value == 1 && Score.coinsCalculo >= 100)
        {
            Score.coinsCalculo -= 100;
            CoinCount();
            Upgrademult.value += 1;
            upgradetempoM = 2;
            PlayerPrefs.SetInt("PowerUPtempoMult", upgradetempoM);
            PlayerPrefs.SetFloat("ValorDoUpgradeMult", Upgrademult.value);

        }
        else if(Upgrademult.value == 2 && Score.coinsCalculo >= 100)
        {
            Score.coinsCalculo -= 100;
            CoinCount();
            Upgrademult.value += 1;
            upgradetempoM = 3;
            PlayerPrefs.SetInt("PowerUPtempoMult", upgradetempoM);
            PlayerPrefs.SetFloat("ValorDoUpgradeMult", Upgrademult.value);

        }
        else if(Upgrademult.value == 3 && Score.coinsCalculo >= 100)
        {
            Score.coinsCalculo -= 100;
            CoinCount();
            Upgrademult.value += 1;
            upgradetempoM = 4;
            PlayerPrefs.SetInt("PowerUPtempoMult", upgradetempoM);
            PlayerPrefs.SetFloat("ValorDoUpgradeMult", Upgrademult.value);
        }
        else if(Upgrademult.value == 4 && Score.coinsCalculo >= 100)
        {
            Score.coinsCalculo -= 100;
            CoinCount();
            Upgrademult.value += 1;
            upgradetempoM = 5;
            PlayerPrefs.SetInt("PowerUPtempoMult", upgradetempoM);
            PlayerPrefs.SetFloat("ValorDoUpgradeMult", Upgrademult.value);

        }
    }

    public void UpgradeInv()
    {
        if(Upgradeinivicivel.value  == 0 && Score.coinsCalculo >= 100)
        {
            Score.coinsCalculo -= 100;
            CoinCount();
            Upgradeinivicivel.value += 1;
            PlayerPrefs.SetInt("PowerUPtempoInv", upgradetempoI);
            PlayerPrefs.SetFloat("ValordoUpgradeInv", Upgradeinivicivel.value);
        }
        else if(Upgradeinivicivel.value == 1 && Score.coinsCalculo >= 100)
        {
            Score.coinsCalculo -= 100;
            CoinCount();
            Upgradeinivicivel.value += 1;
            PlayerPrefs.SetInt("PowerUPtempoInv", upgradetempoI);
            PlayerPrefs.SetFloat("ValordoUpgradeInv", Upgradeinivicivel.value);

        }
        else if (Upgradeinivicivel.value == 2 && Score.coinsCalculo >= 100)
        {
            Score.coinsCalculo -= 100;
            CoinCount();
            Upgradeinivicivel.value += 1;
            PlayerPrefs.SetInt("PowerUPtempoInv", upgradetempoI);
            PlayerPrefs.SetFloat("ValordoUpgradeInv", Upgradeinivicivel.value);
        }
        else if (Upgradeinivicivel.value == 3 && Score.coinsCalculo >= 100)
        {
            Score.coinsCalculo -= 100;
            CoinCount();
            Upgradeinivicivel.value += 1;
            PlayerPrefs.SetInt("PowerUPtempoInv", upgradetempoI);
            PlayerPrefs.SetFloat("ValordoUpgradeInv", Upgradeinivicivel.value);
        }
        else if (Upgradeinivicivel.value == 4 && Score.coinsCalculo >= 100)
        {
            Score.coinsCalculo -= 100;
            CoinCount();
            Upgradeinivicivel.value += 1;
            PlayerPrefs.SetInt("PowerUPtempoInv", upgradetempoI);
            PlayerPrefs.SetFloat("ValordoUpgradeInv", Upgradeinivicivel.value);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
