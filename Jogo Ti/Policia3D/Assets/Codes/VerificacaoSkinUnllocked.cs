using UnityEngine;

public class VerificacaoSkinUnllocked : MonoBehaviour
{
    public GameObject slectedplayer0;
    public GameObject selectplayer0;
    public GameObject lockplayer0;

    public GameObject slectedplayer1;
    public GameObject selectplayer1;
    public GameObject lockplayer1;

    public GameObject slectedplayer2;
    public GameObject selectplayer2;
    public GameObject lockplayer2;


    public GameObject slectedpolicial0;
    public GameObject selectpolicial0;
    public GameObject lockpolicial0;

    public GameObject slectedpolicial1;
    public GameObject selectpolicial1;
    public GameObject lockpolicial1;
    void Start()
    {
        PlayerPrefs.SetInt("Skin0Player", 1);
        PlayerPrefs.SetInt("Skin0Cop", 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Skin0Player") == 1 && PlayerPrefs.GetInt("Skinplayer") == 0)
        {
           slectedplayer0.SetActive(true);
            selectplayer0.SetActive(false);
            lockplayer0.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("Skin0Player") == 1 && PlayerPrefs.GetInt("Skinplayer") != 0)
        {
            selectplayer0.SetActive(true);
            slectedplayer0.SetActive(false);
            lockplayer0.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("Skin0Player") != 1)
        {
            selectplayer0.SetActive(false);
            slectedplayer0.SetActive(false);
            lockplayer0.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Skin1Player") == 1 && PlayerPrefs.GetInt("Skinplayer") == 1)
        {
            slectedplayer1.SetActive(true);
            selectplayer1.SetActive(false);
            lockplayer1.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin1Player") == 1 && PlayerPrefs.GetInt("Skinplayer") != 1)
        {
            selectplayer1.SetActive(true);
            slectedplayer1.SetActive(false);
            lockplayer1.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin1Player") != 1)
        {
            selectplayer1.SetActive(false);
            slectedplayer1.SetActive(false);
            lockplayer1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Skin2Player") == 1 && PlayerPrefs.GetInt("Skinplayer") == 2)
        {
            slectedplayer2.SetActive(true);
            selectplayer2.SetActive(false);
            lockplayer2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin2Player") == 1 && PlayerPrefs.GetInt("Skinplayer") != 2)
        {
            selectplayer2.SetActive(true);
            slectedplayer2.SetActive(false);
            lockplayer2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin2Player") != 1)
        {
            selectplayer2.SetActive(false);
            slectedplayer2.SetActive(false);
            lockplayer2.SetActive(true);
        }


        if (PlayerPrefs.GetInt("Skin0Cop") == 1 && PlayerPrefs.GetInt("SkinCop") == 0)
        {
            slectedpolicial0.SetActive(true);
            selectpolicial0.SetActive(false);
            lockpolicial0.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin0Cop") == 1 && PlayerPrefs.GetInt("SkinCop") != 0)
        {
            selectpolicial0.SetActive(true);
            slectedpolicial0.SetActive(false);
            lockpolicial0.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin0Cop") != 1)
        {
            selectpolicial0.SetActive(false);
            slectedpolicial0.SetActive(false);
            lockpolicial0.SetActive(true);
        }


        if (PlayerPrefs.GetInt("Skin1Cop") == 1 && PlayerPrefs.GetInt("SkinCop") == 1)
        {
            slectedpolicial1.SetActive(true);
            selectpolicial1.SetActive(false);
            lockpolicial1.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin1Cop") == 1 && PlayerPrefs.GetInt("SkinCop") != 1)
        {
            selectpolicial1.SetActive(true);
            slectedpolicial1.SetActive(false);
            lockpolicial1.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Skin1Cop") != 1)
        {
            selectpolicial1.SetActive(false);
            slectedpolicial1.SetActive(false);
            lockpolicial1.SetActive(true);
        }

    }


    public void SelecionarSkinPlayer0()
    {
        if(PlayerPrefs.GetInt("Skin0Player") == 1 && PlayerPrefs.GetInt("Skinplayer") != 0)
        {
            PlayerPrefs.SetInt("Skinplayer", 0);
        }
    }

    public void SelecionarSkinPlayer1()
    {
        if(PlayerPrefs.GetInt("Skin1Player") == 1 && PlayerPrefs.GetInt("Skinplayer") != 1)
        {
            PlayerPrefs.SetInt("Skinplayer", 1);
        }
    }

    public void SelecionarSkinPlayer2()
    {
        if (PlayerPrefs.GetInt("Skin2Player") == 1 && PlayerPrefs.GetInt("Skinplayer") != 2)
        {
            PlayerPrefs.SetInt("Skinplayer", 2);
        }
    }


    public void SelecionarSkinCop0()
    {
        if(PlayerPrefs.GetInt("Skin0Cop") == 1 && PlayerPrefs.GetInt("SkinCop") != 0)
        {
            PlayerPrefs.SetInt("SkinCop", 0);
        }
    }


    public void SelecionarSkinCop1()
    {
        if (PlayerPrefs.GetInt("Skin1Cop") == 1 && PlayerPrefs.GetInt("SkinCop") != 1)
        {
            PlayerPrefs.SetInt("SkinCop", 1);
        }
    }
}
