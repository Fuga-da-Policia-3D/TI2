using UnityEngine;

public class Player : MonoBehaviour
{
    AudioManager audioManager;
    //private Rigidbody rb;
    //private float forceamount = 10f;
    /*void Start()
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
    }*/

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 normal = contact.normal;
            if (Vector3.Dot(normal, Vector3.right) > 0.5f && collision.gameObject.tag == "Obstacle" && !MovingThings.isIndestructuble)
            {
                audioManager.PlaySFX(audioManager.grunt);
                Debug.Log("Hit from the left side");
                Time.timeScale = 0;
                GameOver.instacia.GameOverScreen();
            }
            else if (Vector3.Dot(normal, Vector3.left) > 0.5f && collision.gameObject.tag == "Obstacle" && !MovingThings.isIndestructuble)
            {
                audioManager.PlaySFX(audioManager.grunt);
                Debug.Log("Hit from the right side");
                Time.timeScale = 0;
                GameOver.instacia.GameOverScreen();
            }
            else if(Vector3.Dot(normal, Vector3.right) > 0.5f && collision.gameObject.tag == "Obstacle" || Vector3.Dot(normal, Vector3.left) > 0.5f && collision.gameObject.tag == "Obstacle" && MovingThings.isIndestructuble)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = (other.transform.position - transform.position).normalized;

        if (Vector3.Dot(direction, Vector3.right) > 0.5f && other.gameObject.tag == "Obstacle")
        {
            audioManager.PlaySFX(audioManager.grunt);
            Debug.Log("Triggered on the right side");
            Time.timeScale = 0;
            GameOver.instacia.GameOverScreen();
        }
        else if (Vector3.Dot(direction, Vector3.left) > 0.5f && other.gameObject.tag == "Obstacle")
        {
            audioManager.PlaySFX(audioManager.grunt);
            Debug.Log("Triggered on the left side");
            Time.timeScale = 0;
            GameOver.instacia.GameOverScreen();
        }
    }
}