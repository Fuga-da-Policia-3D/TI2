using UnityEngine;

public class PathMaking : MonoBehaviour
{
    public GameObject[] paths;
    private int rng;
    [SerializeField]private GameObject[] kill = new GameObject[3];
    private new Vector3 chaodetectado;
    public static float pulando;
    private Transform parenteTrigger;
    public GameObject parenteTriggerObj;
    public Collider playercolider;
    private float timing;
    private float fila = 0;

    //Lucas de Lima e ilva
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
           
            //print(chaodetectado);
            Instantiate(paths[rng], new Vector3(chaodetectado.x + 80 - 10, 0, 0), other.gameObject.transform.rotation);
        }
    }
}
