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
    [SerializeField] float Gravidade = -10f;
    [SerializeField] float temponoAr = 0.3f;
    [SerializeField] float forcadePulo = 5f;
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
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
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
        if(Score.scoreCalculo >= 0 || Score.scoreCalculo < 1000 || playerSpeed <=10 || playerSpeed == 10)
        {
            playerSpeed += 2 * Time.deltaTime;
        }
        if (Score.scoreCalculo >= 1000 || Score.scoreCalculo<2000 && playerSpeed<=20 || playerSpeed == 20)
        {
            playerSpeed += 2 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "chao")
        {
            isGround = true;
            
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
                        else if(delta.y < 0 && !isscale)
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
