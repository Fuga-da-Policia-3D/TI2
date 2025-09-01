using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float forceamount = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * forceamount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * forceamount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * forceamount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * forceamount * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            GameOver.instacia.GameOverScreen();
        }
    }
}
