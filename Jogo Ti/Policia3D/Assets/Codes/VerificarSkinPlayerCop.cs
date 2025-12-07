using UnityEngine;

public class VerificarSkinPlayerCop : MonoBehaviour
{
    public GameObject skinplay0;
    public GameObject skin0normalinv;
    public GameObject skin0zfight;
    public GameObject skinplay1;
    public GameObject skin1normalinv;
    public GameObject skin1zfight;
    public GameObject skinplay2;
    public GameObject skin2normalinv;
    public GameObject skin2zfight;

    public static int trocardevolta;

    public GameObject skincop0;
    public GameObject skincop1;
    void Start()
    {
        switch (PlayerPrefs.GetInt("Skinplayer"))
        {
            case 0:
                skinplay0.SetActive(true);
                skinplay1.SetActive(false);
                skinplay2.SetActive(false);
            break;
            case 1:
                skinplay0.SetActive(false);
                skinplay1.SetActive(true);
                skinplay2.SetActive(false);
                break;
            case 2:
                skinplay0.SetActive(false);
                skinplay1.SetActive(false);
                skinplay2.SetActive(true);
                break;
        }

        switch (PlayerPrefs.GetInt("SkinCop"))
        {
            case 0:
                skincop0.SetActive(true);
                skincop1.SetActive(false);
                break;
            case 1:
                skincop0.SetActive(false);
                skincop1.SetActive(true);
                break;
        }
        

       
    }
    private void Update()
    {
       
        if (PlayerPrefs.GetInt("Skinplayer") == 0 && trocardevolta == 1)
        {
            skinplay0.SetActive(true);
            skin0normalinv.SetActive(false);
            trocardevolta = 0;
        }
        if (PlayerPrefs.GetInt("Skinplayer") == 1 && trocardevolta == 1)
        {
            skinplay1.SetActive(true);
            skin1normalinv.SetActive(false);
            trocardevolta = 0;
        }
        if (PlayerPrefs.GetInt("Skinplayer") == 2 && trocardevolta == 1)
        {
            skinplay2.SetActive(true);
            skin2normalinv.SetActive(false);
            trocardevolta = 0;
        }
        if (PlayerPrefs.GetInt("Skinplayer") == 0 && trocardevolta == 2)
        {

            skin0zfight.SetActive(false);
            trocardevolta = 0;
        }
        if (PlayerPrefs.GetInt("Skinplayer") == 1 && trocardevolta == 2)
        {

            skin1zfight.SetActive(false);
            trocardevolta = 0;
        }
        if (PlayerPrefs.GetInt("Skinplayer") == 2 && trocardevolta == 2)
        {

            skin2zfight.SetActive(false);
            trocardevolta = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Especial")
        {
            other.TryGetComponent<PowerUps>(out PowerUps powerUp);
            int numerodoid = powerUp.PowerUpID();
            switch (numerodoid)
            {
                case 1:
                    if(PlayerPrefs.GetInt("Skinplayer") == 0)
                    {
                        skinplay0.SetActive(false);
                        skin0normalinv.SetActive(true);
                    }
                    if (PlayerPrefs.GetInt("Skinplayer") == 1)
                    {
                        skinplay1.SetActive(false);
                        skin1normalinv.SetActive(true);
                    }
                    if (PlayerPrefs.GetInt("Skinplayer") == 2)
                    {
                        skinplay2.SetActive(false);
                        skin2normalinv.SetActive(true);
                    }
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("Skinplayer") == 0)
                    {

                        skin0zfight.SetActive(true);
                    }
                    if (PlayerPrefs.GetInt("Skinplayer") == 1)
                    {
                        
                        skin1zfight.SetActive(true);
                    }
                    if (PlayerPrefs.GetInt("Skinplayer") == 2)
                    {
                       
                        skin2zfight.SetActive(true);
                    }
                    break;
            }
        }
    }

    public static int VoltarSkinNormal(int valor)
    {
        return valor;
    }



}
