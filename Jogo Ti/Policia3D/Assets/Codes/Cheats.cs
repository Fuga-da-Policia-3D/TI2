using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    
    
    private float lastTapTime = 0f;
    private int tapCount = 0;
    private Vector2 touchStartPos;
    private float maxTapMovement = 20f;
    public float tapdelay = 0.35f;
    private bool iswaiting = false;

    public Rigidbody rb;
    public float forca = 5f;

    public Material[] outrosmateriais;
    public Mesh[] newMesh;
    private int tamanho = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            Score.coinsCalculo += 999999;
        }
        if (Input.GetKey(KeyCode.H))
        {
            PlayerPrefs.SetInt("PowerUPtempoInv",100000);
        }
        DetectTaps();
    }


    void DetectTaps()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                float moveDistance = (touch.position - touchStartPos).magnitude;

                if (moveDistance < maxTapMovement)  // valid tap
                {
                    float timeNow = Time.time;

                    if (timeNow - lastTapTime < 0.3f)
                        tapCount++;
                    else
                        tapCount = 1;

                    lastTapTime = timeNow;

                    // START countdown after the last tap
                    CancelInvoke("ProcessTap");
                    Invoke("ProcessTap", 0.3f);
                }
            }
        }
    }


    void ProcessTap()
    {
        // CHEATS
        if (tapCount == 5)
        {
            PlayerPrefs.SetInt("PowerUPtempoInv", 100000);
            Debug.Log("Cheat 5 taps activated!");
        }
        else if (tapCount == 4)
        {
            Score.coinsCalculo += 999999;
            Debug.Log("Cheat 4 taps activated!");
        }

        // reset for next cheat
        tapCount = 0;
    }

}
