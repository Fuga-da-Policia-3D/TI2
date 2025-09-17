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
    void Start()
    {
        cc = GetComponent<CharacterController>();

    }
    void Update()
    {
        CheckKeyboardInputs();
        Run();
        SpeedUP();
    }


    private void Run()
    {
        float currentX = transform.position.z;
        float targetX = lanePos[myLane];

        float newX = Mathf.MoveTowards(currentX, targetX, laneTransitionSpeed * Time.deltaTime);
        float deltaX = newX - currentX;

        Vector3 motion = new Vector3(playerSpeed * Time.deltaTime, -10f * Time.deltaTime, deltaX);
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
        if (playerSpeed < 50)
        {
            playerSpeed += 2 * Time.deltaTime;
        }
    }

}
