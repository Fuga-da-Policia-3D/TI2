using UnityEngine;

public class Acoesanimais : MonoBehaviour
{
    public int ID;
    public Rigidbody rb;

    private bool indo = false;

    // Update is called once per frame
    private void Start()
    {
        Destroy(this.gameObject, 6);
    }
    void Update()
    {
        if(ID == 1)
        {
            rb.AddForce(new Vector3(-1, 0, 0) * 500 * Time.deltaTime);
        }
        if(ID == 2)
        {
            if(this.gameObject.transform.position.z > 10 )
            {
                indo = true;
            }
            else if(this.gameObject.transform.position.z < -10)
            {
                indo = false;
            }
            if (indo)
            {
                rb.AddForce(new Vector3(0, 0, -1) * 1000 * Time.deltaTime);
            }
            else
            {
                rb.AddForce(new Vector3(0, 0, 1) * 1000 * Time.deltaTime);
            }
            
        }
        if (ID == 4)
        {
            rb.AddForce(new Vector3(-1, 0, 0) * 500 * Time.deltaTime);
        }
    }
}
