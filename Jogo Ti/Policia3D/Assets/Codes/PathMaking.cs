using UnityEngine;

public class PathMaking : MonoBehaviour
{
    public GameObject[] paths;
    public GameObject caminhopolicail;
    public GameObject iniciarAtaquepolicial;


    private int rng;
    [SerializeField]private GameObject[] kill = new GameObject[3];
    private new Vector3 chaodetectado;
    public static float pulando;
    public static float pathafazer = 1;
    private Transform parenteTrigger;
    public GameObject parenteTriggerObj;
    public Collider playercolider;
    private float timing;
    private float fila = 0;

    //Lucas de Lima e silva

    private void Start()
    {
        pathafazer = 1;
       
        rng = Random.Range(0, paths.Length);
        Instantiate(paths[rng], new Vector3(29.59f, 0, 0), this.gameObject.transform.rotation);
        rng = Random.Range(0, paths.Length);
        Instantiate(paths[rng], new Vector3(49.59f, 0, 0), this.gameObject.transform.rotation);
        rng = Random.Range(0, paths.Length);
        Instantiate(paths[rng], new Vector3(69.59f, 0, 0), this.gameObject.transform.rotation);
        rng = Random.Range(0, paths.Length);
        Instantiate(paths[rng], new Vector3(89.59f, 0, 0), this.gameObject.transform.rotation);
        rng = Random.Range(0, paths.Length);
        Instantiate(paths[rng], new Vector3(109.59f, 0, 0), this.gameObject.transform.rotation);
        rng = Random.Range(0, paths.Length);
        Instantiate(paths[rng], new Vector3(129.59f, 0, 0), this.gameObject.transform.rotation);
        rng = Random.Range(0, paths.Length);
        Instantiate(paths[rng], new Vector3(149.59f, 0, 0), this.gameObject.transform.rotation);
        rng = Random.Range(0, paths.Length);
        Instantiate(paths[rng], new Vector3(169.59f, 0, 0), this.gameObject.transform.rotation);

    }
    private void Update()
    {
        rng = Random.Range(0, paths.Length);
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "MakePath")
        {
            parenteTrigger = other.GetComponentInParent<Transform>();
            parenteTriggerObj = other.gameObject.transform.parent.gameObject;
            chaodetectado = parenteTrigger.transform.position;
            if (fila == 0)
            {
                kill[0] = other.gameObject.transform.parent.gameObject;
                Destroy(kill[1]);
                fila++;

            }
            else if (fila == 1)
            {
                kill[1] = other.gameObject.transform.parent.gameObject;
                Destroy(kill[2]);
                fila++;


            }
            else if (fila == 2)
            {
                kill[2] = other.gameObject.transform.parent.gameObject;
                Destroy(kill[0]);
                fila++;
            }
            if (fila == 3)
            {
                fila = 0;
            }
           
            if(pathafazer == 1)
            {
                Instantiate(paths[rng], new Vector3(chaodetectado.x + 180 - 10, 0, 0), other.gameObject.transform.rotation);
            }
            else if(pathafazer == 2)
            {
                Instantiate(caminhopolicail, new Vector3(chaodetectado.x + 180 - 10, 0, 0), other.gameObject.transform.rotation);
            }
            else if(pathafazer == 3)
            {
                pathafazer = 2;
                Instantiate(iniciarAtaquepolicial, new Vector3(chaodetectado.x + 180 - 10, 0, 0), other.gameObject.transform.rotation);
            }
            
        }
    }
}
