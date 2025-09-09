using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float speed = 5;
    public float acceleration = 2f;
    public float maxspeed = 20f;
    public float lateraldistance = 3f;
    public float movex = 1f;
    public float jumpforce = 5f;
    public float verticalMultiplier = 2f;
    public float sidecooldown = 0.2f;

    private float currentspeed = 0f;
    private Rigidbody rb;
    private bool isground;
    private bool canmove = true;
    private float sidemove = 0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!canmove)
        {
            sidemove -= Time.deltaTime;
            if (sidemove <= 0f)
            {
                canmove = true;
            }
        }
        if (currentspeed < maxspeed)
        {
            currentspeed += acceleration * Time.deltaTime;

        }
        if (canmove)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveSide(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                MoveSide(Vector3.right);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isground)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isground = false;
        }
        /*
           float movey = -Input.GetAxis("Horizontal") * verticalMultiplier;
        // float movey = Input.GetAxis("Vertical") * verticalMultiplier; 

        Vector3 movement = new Vector3(movex, 0, movey) * speed * Time.deltaTime;

        Vector3 newPosition = rb.position + movement;

        rb.MovePosition(newPosition);

        */
    }
    void FixedUpdate()
    {
        Vector3 Movement = Vector3.forward * currentspeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + Movement);
    }
    private void MoveSide(Vector3 direction)
    {
        Vector3 targetposition = rb.position + direction * lateraldistance;
        rb.MovePosition(targetposition);
        canmove = false;
        sidemove = sidecooldown;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            isground = true;
        }

    }
}