using UnityEngine;

public class MakingScenary : MonoBehaviour
{
    public GameObject cenario;
    public GameObject Localproximocenario;
    public GameObject cenarioaserDestruido;

    private void Update()
    {
       if(Localproximocenario == null)
       {
            Localproximocenario = GameObject.FindGameObjectWithTag("SpawnProximoCenario");
       }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TriggerCenario")
        {
            cenarioaserDestruido = other.gameObject.transform.parent.gameObject;
            Instantiate(cenario, Localproximocenario.transform.position, Localproximocenario.transform.rotation);
        }
        if(other.gameObject.tag == "SpawnProximoCenario")
        {
            Destroy(cenarioaserDestruido, 5);
        }
    }
}
