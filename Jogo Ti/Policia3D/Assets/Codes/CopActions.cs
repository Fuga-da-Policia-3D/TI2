using UnityEngine;

public class CopActions : MonoBehaviour
{
    public GameObject playerlocation;
    public float moveSpeed = 2.0f;
    private int contador;
    private int AtaquesTotal;
    private int AtaquesTotalanimal;
    //camera pos para salvar (-11.32,1.48,0) rotation (0,90,0)

    public GameObject[] objdeataque;
    private float tempodeataque;
    private int acaopolicial;
    private int distanciadecadaacao;
    private bool policialAtacando;

    public GameObject[] animaisataque;
    private float tempodeataqueanimais;
    private int acaopolicialanimal;
    private int distaciadeacaoanimal;
    private bool policialAtacandoanimal;

    private int[] posicoeslane = { 10, 5, 0, -5, -10 };

    public Vector3 offset = new Vector3(-2, 0, 0);
    public Vector3 offsetmaior = new Vector3(-5, -0, -0);

    private void Start()
    {
        acaopolicial = Random.Range(1, 4);
        switch (acaopolicial)
        {
            case 1:
                distanciadecadaacao = 800;
                distaciadeacaoanimal = 100;
                break;
            case 2:
                distanciadecadaacao = 900;
                distaciadeacaoanimal = 200;
                break;
            case 3:
                distanciadecadaacao = 1000;
                distaciadeacaoanimal = 300;
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
        else
        {
            Vector3 targetPosition = playerlocation.transform.position + offsetmaior;


            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        }





        if(distanciadecadaacao <= playerlocation.transform.position.x && acaopolicial != 0)
        {
            PathMaking.pathafazer = 2;
            policialAtacando = true;
            acaopolicial = 0;
            contador = 0;
        }
        if(distaciadeacaoanimal <= playerlocation.transform.position.x && acaopolicial != 0)
        {
            PathMaking.pathafazer = 2;
            policialAtacandoanimal = true;
            acaopolicial = 0;
            contador = 0;

        }
        if(policialAtacandoanimal && acaopolicial == 0 && AtaquesTotalanimal < 10)
        {
            int random = Random.Range(0, animaisataque.Length);
            AtaqueAnimalPolicial(random);
        }
        if (policialAtacando && acaopolicial == 0 && AtaquesTotal < 10) 
        {
            int random = Random.Range(0, posicoeslane.Length);//tem que arrumar
            AtaquePolicial(random);
        }
        if(distaciadeacaoanimal + 2.5f < Time.time)
        {
            policialAtacando = false;
            policialAtacandoanimal = true;
            contador = 0;
        }
        if(tempodeataque + 2.5f < Time.time)
        {
            policialAtacando = true;
            policialAtacandoanimal = false;
            contador = 0;
        }
        if(AtaquesTotalanimal >= 10)
        {
            PathMaking.pathafazer = 1;
        }
        if(AtaquesTotal >= 10)
        {
            PathMaking.pathafazer = 1;
            acaopolicial = Random.Range(1, 4);
            switch (acaopolicial)
            {
                case 1:
                    distanciadecadaacao += 1400;
                    distaciadeacaoanimal += 700;
                    break;
                case 2:
                    distanciadecadaacao += 1500;
                    distaciadeacaoanimal += 900;
                    break;
                case 3:
                    distanciadecadaacao += 1600;
                    distaciadeacaoanimal += 1100;
                    break;
            }
            AtaquesTotal = 0;
        }

    }

    public void AtaquePolicial(int random)
    {
        tempodeataque = Time.time;
        if (contador == 0)
        {
            
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
            
            contador++;
            AtaquesTotal++;
        }
        policialAtacando = false;
    }


    public void AtaqueAnimalPolicial(int random)
    {
        tempodeataqueanimais = Time.time;
        if(contador == 0)
        {
            if(random == 0)//pombo
            {
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[0]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[1]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[2]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[3]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[4]), transform.rotation);
            }
            if (random == 1)//superdoggo
            {
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[0]), transform.rotation);
            }
            if (random == 2)//porco-espinho
            {
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[0]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[1]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[2]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[3]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[4]), transform.rotation);
            }
            if (random == 3)//porco
            {
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[0]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[1]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[2]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[3]), transform.rotation);
                Instantiate(animaisataque[random], new Vector3(playerlocation.transform.position.x + 60, 2, posicoeslane[4]), transform.rotation);
            }

            contador++;
            AtaquesTotalanimal++;
        }
        policialAtacandoanimal = false;
    }
}
