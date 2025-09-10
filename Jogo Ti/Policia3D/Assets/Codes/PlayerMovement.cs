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
    public float scalespeed = 10f;
    public float minscale = 200f;
    public float cooldowndown = 2f;

    private Vector3 origalscale = new Vector3(1, 3, 1);
    private float cooldowntimerdown = 0f;
    private bool isscale;
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
                MoveSide(-Vector3.back);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                MoveSide(-Vector3.forward);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isground)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isground = false;
        }
        if (Input.GetKeyDown(KeyCode.S) && !isscale)
        {
            Vector3 scaledecrese = new Vector3(0, 1, 0) * scalespeed * Time.deltaTime;
            Vector3 newscale = transform.localScale - scaledecrese;
            newscale.y = Mathf.Max(newscale.y - minscale);

            transform.localScale = newscale;

            isscale = true;
            cooldowntimerdown = cooldowndown;
        }

        if (isscale)
        {
            cooldowntimerdown -= Time.deltaTime;

            if (cooldowntimerdown <= 0f)
            {
                transform.localScale = origalscale;
                isscale = false;
            }
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
        Vector3 Movement = new Vector3 (1,0,0) * currentspeed * Time.fixedDeltaTime;
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