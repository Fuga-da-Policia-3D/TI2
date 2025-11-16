using UnityEngine;

public class CopActions : MonoBehaviour
{
    public GameObject playerlocation;
    public float moveSpeed = 2.0f;
    private int contador;
    private int AtaquesTotal;
    //camera pos para salvar (-11.32,1.48,0) rotation (0,90,0)

    public GameObject[] objdeataque;
    private float tempodeataque;
    private int acaopolicial;
    private int distanciadecadaacao;
    private bool policialAtacando;

    private int[] posicoeslane = { 10, 5, 0, -5, -10 };

    public Vector3 offset = new Vector3(-2, 0, 0);

    private void Start()
    {
        acaopolicial = Random.Range(1, 4);
        switch (acaopolicial)
        {
            case 1:
                distanciadecadaacao = 400;
                break;
            case 2:
                distanciadecadaacao = 500;
                break;
            case 3:
                distanciadecadaacao = 600;
                break;
        }
    }
    
    private void Update()
    {
        if (MovingThings.isSlowed)
        {
            Vector3 targetPosition = playerlocation.transform.position + offset;

            
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        if(distanciadecadaacao <= playerlocation.transform.position.x && acaopolicial != 0)
        {
            PathMaking.pathafazer = 2;
            policialAtacando = true;
            acaopolicial = 0;
            contador = 0;
        }
        if (policialAtacando && acaopolicial == 0 && AtaquesTotal < 10) 
        {
            AtaquePolicial();
        }
        if(tempodeataque + 2.5f < Time.time)
        {
            policialAtacando = true;
            contador = 0;
        }
        if(AtaquesTotal >= 10)
        {
            PathMaking.pathafazer = 1;
            acaopolicial = Random.Range(1, 4);
            switch (acaopolicial)
            {
                case 1:
                    distanciadecadaacao += 1000;
                    break;
                case 2:
                    distanciadecadaacao += 1200;
                    break;
                case 3:
                    distanciadecadaacao += 1400;
                    break;
            }
            AtaquesTotal = 0;
        }

    }

    public void AtaquePolicial()
    {
        tempodeataque = Time.time;
        if (contador == 0)
        {
            int random = Random.Range(0, posicoeslane.Length);//tem que arrumar
            if(random == 0)
            {
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random + 1]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random + 2]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random + 3]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random + 4]), transform.rotation);
            }
            else if (random == 1)
            {
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random - 1]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random + 1]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random + 2]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random + 3]), transform.rotation);
            }
            else if (random == 2)
            {
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random - 2]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random - 1]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random + 1]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random + 2]), transform.rotation);
            }
            else if (random == 3)
            {
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random - 3]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random - 2]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random - 1]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random + 1]), transform.rotation);
            }
            else if (random == 4)
            {
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random - 1]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random - 2]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random - 3]), transform.rotation);
                Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[random - 4]), transform.rotation);
            }
            Instantiate(objdeataque[Random.Range(0, objdeataque.Length)], new Vector3(playerlocation.transform.position.x + 60, 2, playerlocation.transform.position.z), transform.rotation);
            contador++;
            AtaquesTotal++;
        }
        policialAtacando = false;
    }
}
