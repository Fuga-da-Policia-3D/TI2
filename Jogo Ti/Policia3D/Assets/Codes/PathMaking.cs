using UnityEngine;

public class PathMaking : MonoBehaviour
{
    public GameObject[] paths;
    private int rng;
    private GameObject[] kill = new GameObject[2];
    private new Vector3 chaodetectado;
    public static float pulando;
    private float timing;

    //Lucas de Lima e ilva
    private void Update()
    {
        rng = Random.Range(0, paths.Length);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "chao" && kill[0] == null || kill[0] == collision.gameObject)
        {
            
            Destroy(kill[1]);
            chaodetectado = collision.gameObject.transform.position;
            kill[0] = collision.gameObject;
        }
        else if(collision.gameObject.tag == "chao" && kill[1] == null || kill[1] == collision.gameObject)
        {
            Destroy(kill[0]);
            chaodetectado = collision.gameObject.transform.position;
            kill[1] = collision.gameObject;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MakePath")
        {
            Instantiate(paths[rng], new Vector3(chaodetectado.x + 80, 0,0) , this.gameObject.transform.rotation);
        }
    }
}
