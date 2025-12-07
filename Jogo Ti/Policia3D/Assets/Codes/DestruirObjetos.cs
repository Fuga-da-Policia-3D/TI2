using UnityEngine;

public class DestruirObjetos : MonoBehaviour
{
    
    

    private bool indo = false;

    // Update is called once per frame
    private void Start()
    {
        Destroy(this.gameObject,20);
    }
    
}
