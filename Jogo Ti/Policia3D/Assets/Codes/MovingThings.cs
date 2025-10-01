using NUnit.Framework;
using System;
using Unity.Mathematics;
using UnityEngine;

public class MovingThings : MonoBehaviour
{

    AudioManager aM;
    public CharacterController cc;
    [SerializeField] float playerSpeed;
    public float[] lanePos = new float[5];
    [SerializeField] int myLane;
    [SerializeField] float targetPos;
    [SerializeField] float laneTransitionSpeed;
    public static bool isGround = false;
    public static bool isSlowed = false;
    private float slowedTimer = -1;
    private int contato = 0; //Solução super bonder
    [SerializeField] float Gravidade = -10f;
    [SerializeField] float temponoAr = 0.3f;
    [SerializeField] float forcadePulo = 5f;

    public float acceleration = 2f;
    private bool isscale = false;
    public float scalespeed = 10f;
    public float minscale = 1f;
    public float cooldowndown = 2f;
    private float cooldowntimerdown = 0f;
    private Vector3 origalscale = new Vector3(1, 1.8f, 1);
    private float inputJump = 0;

    private float inicialY;
    private float lastTapTime = 0f;
    private int tapCount = 0;
    private Vector2 startTouch;


    private void Awake()
    {
        aM = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        Time.timeScale = 1;
        contato = 0;
        cc = GetComponent<CharacterController>();
        inicialY = this.gameObject.transform.position.y;

    }
    void Update()
    {
        CheckKeyboardInputs();
        Run();
        SpeedUP();
        DetectSwipes();
        if (inputJump + temponoAr < Time.time && isGround == false)
        {
            Gravidade = -10f;
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
        if(slowedTimer + 1f > Time.time && isSlowed == true && contato > 5)
        {
            Time.timeScale = 0;
            GameOver.instacia.GameOverScreen();
        }
        if(slowedTimer + 1f < Time.time && isSlowed == true )
        {
            isSlowed = false;
            contato = 0;
        }
    }


    private void Run()
    {
        float currentZ = transform.position.z;
        float targetZ = lanePos[myLane];

        float newZ = Mathf.MoveTowards(currentZ, targetZ, laneTransitionSpeed * Time.deltaTime);
        float deltaZ = newZ - currentZ;

        Vector3 motion = new Vector3(playerSpeed * Time.deltaTime, Gravidade * Time.deltaTime, deltaZ);
        cc.Move(motion);
    }

    void CheckKeyboardInputs()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.S) && !isscale)
        {
            Slide();
        }


    }

    void MoveLeft()
    {
        if (myLane > 0)
        {
            myLane--;
            targetPos = lanePos[myLane];
        }
    }
    void MoveRight()
    {
        if (myLane < 4)
        {
            myLane++;
            targetPos = lanePos[myLane];
        }
    }
    void SpeedUP()
    {
        float posicao = 1;
        if(Score.scoreCalculo >= 0 && Score.scoreCalculo < 500)
        {
            playerSpeed += 2f * Time.deltaTime;
            if(playerSpeed > 10)
            {
                playerSpeed = 10f;
            }
        }
        if (Score.scoreCalculo >= 500)
        {
            playerSpeed += 2f * Time.deltaTime;
            posicao = 2;
            if (playerSpeed > 20 && posicao == 2)
            {
                playerSpeed = 20f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            isGround = true;

        }
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 normal = contact.normal;

            if (Vector3.Dot(normal, Vector3.forward) > 0.5f)
            {
                Debug.Log("Hit from behind");
                slowedTimer = Time.time;
                playerSpeed = 2;
                contato++;
                isSlowed = true;
            }
            else if (Vector3.Dot(normal, Vector3.back) > 0.5f)
            {
                Debug.Log("Hit from the front");
                slowedTimer = Time.time;
                playerSpeed = 2;
                isSlowed = true;
            }
        }
    }


    void Jump()
    {
        inputJump = Time.time;
        Gravidade = forcadePulo;
        isGround = false;
        aM.PlaySFX(aM.jump);

    }

    void Slide()
    {
        Vector3 scaledecrese = new Vector3(0, 1, 0) * scalespeed * Time.deltaTime;
        Vector3 newscale = transform.localScale - scaledecrese;
        newscale.y = Mathf.Max(newscale.y - minscale);

        transform.localScale = newscale;

        isscale = true;
        cooldowntimerdown = cooldowndown;

    }

    void DetectSwipes()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startTouch = t.position;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Vector2 delta = t.position - startTouch;

                if (delta.magnitude > 100) // Minimum swipe distance
                {
                    if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                    {
                        // Horizontal swipe
                        if (delta.x > 0)
                        {
                            Debug.Log("Swipe Right");
                            MoveRight();
                        }
                        else
                        {
                            Debug.Log("Swipe Left");
                            MoveLeft();
                        }
                    }
                    else
                    {
                        // Vertical swipe
                        if (delta.y > 0 && isGround)
                        {
                            Debug.Log("Swipe Up");
                            Jump();
                        }
                        else if (delta.y < 0 && !isscale)
                        {
                            Debug.Log("Swipe Down");
                            Slide();
                        }
                    }
                }
            }
        }
    }
}
