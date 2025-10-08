using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int ID;
    public static PowerUps InstanciarPowerUps;

    private void Awake()
    {
        InstanciarPowerUps = this;
        
    }

    public int PowerUpID()
    {
        return ID;
    }
}
