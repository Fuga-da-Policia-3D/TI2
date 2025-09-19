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
    private float inicialY;
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
        Jump();
        Slide();
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
        //if (playerSpeed < 50)
        //{
            //playerSpeed += 2 * Time.deltaTime;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "chao")
        {
            isGround = true;
            print("colidiu");
        }
    }


    void Jump()
    {
        float inputJump = 0;
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            inputJump = Time.time;
            Gravidade = forcadePulo;
            isGround = false;
        }
        else if (inputJump + temponoAr < Time.time && isGround == false)
        {
            Gravidade = -10f;
        }
    }

    static void Slide()
    {

    }

}
