using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float movex = 1f;
    public float jumpforce = 5f;
    public float verticalMultiplier = 2f;

    private Rigidbody rb;
    private bool isground;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        float movey = -Input.GetAxis("Horizontal") * verticalMultiplier;
        // float movey = Input.GetAxis("Vertical") * verticalMultiplier; 

        Vector3 movement = new Vector3(movex, 0, movey) * speed * Time.deltaTime;

        Vector3 newPosition = rb.position + movement;

        rb.MovePosition(newPosition);

        if (Input.GetKeyDown(KeyCode.Space) && isground)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isground = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            isground = true;
        }

    }
}