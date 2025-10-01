using UnityEngine;

public class CopActions : MonoBehaviour
{
    public GameObject playerlocation;
    //camera pos para salvar (-11.32,1.48,0) rotation (0,90,0)
    private void Update()
    {
        if (MovingThings.isSlowed)
        {
            this.gameObject.transform.position = playerlocation.transform.position - new Vector3(2, 0, 0);//Perguntar para o udan se faz hardcode ele chegando ou faz uma animação
        }
    }
}
