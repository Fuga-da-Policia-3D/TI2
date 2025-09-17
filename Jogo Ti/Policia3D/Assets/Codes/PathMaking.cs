using UnityEngine;

public class PathMaking : MonoBehaviour
{
    public GameObject[] paths;
    private int rng;
    [SerializeField]private GameObject[] kill = new GameObject[3];
    private new Vector3 chaodetectado;
    public static float pulando;
    private Transform parenteTrigger;
    private float timing;

    //Lucas de Lima e ilva
    private void Update()
    {
        rng = Random.Range(0, paths.Length);
        
    }


    
    private void OnCollisionEnter(Collision collision)
    {
        // Por enquanto solução super bonder
        if (collision.gameObject.tag == "chao" && kill[0] == null || kill[0] == collision.gameObject)
        {
            
            Destroy(kill[1]);
            chaodetectado = collision.gameObject.transform.position;
            kill[0] = collision.gameObject;
        }
        else if(collision.gameObject.tag == "chao" && kill[1] == null || kill[1] == collision.gameObject)
        {
            Destroy(kill[2]);
            chaodetectado = collision.gameObject.transform.position;
            kill[1] = collision.gameObject;
        }
        else if(collision.gameObject.tag == "chao" && kill[2] == null || kill[2] == collision.gameObject)
        {
            Destroy(kill[0]);
            chaodetectado = collision.gameObject.transform.position;
            kill[2] = collision.gameObject;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MakePath")
        {
            parenteTrigger = other.GetComponentInParent<Transform>();
            chaodetectado = parenteTrigger.transform.position;
            //print(chaodetectado);
            Instantiate(paths[rng], new Vector3(chaodetectado.x + 80 -10, 0,0) , other.gameObject.transform.rotation);
            
        }
    }
}
