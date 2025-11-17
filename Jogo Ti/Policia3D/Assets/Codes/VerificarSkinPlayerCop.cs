using UnityEngine;

public class VerificarSkinPlayerCop : MonoBehaviour
{
    public GameObject skinplay0;
    public GameObject skinplay1;
    public GameObject skinplay2;

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

    
}
