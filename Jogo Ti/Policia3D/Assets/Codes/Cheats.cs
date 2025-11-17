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

                float moveDistance = (touch.position - touchStartPos).magnitude;//Verifica se a pessoa ta fazendo um swipe ao invez de um touch


                if (moveDistance < maxTapMovement)
                {
                    float timeNow = Time.time;

                    if (timeNow - lastTapTime < 0.3f)
                    {
                        tapCount++;
                    }
                    else
                    {
                        tapCount = 1;
                    }

                    lastTapTime = timeNow;

                    if (!iswaiting)//isso daqui e para fazer com que os tap count não se atrapalhem
                    {
                        iswaiting = true;
                        Invoke("ProcessTap", tapdelay);
                    }
                }
            }
        }

    }


    void ProcessTap()
    {
        
        if (tapCount == 5)
        {
            PlayerPrefs.SetInt("PowerUPtempoInv", 100000);
        }
        else if (tapCount == 4)// dependendo da cena faz algo diferente ja na cena 0 que é a sena 1 ela fica mudando aleatoriamente entre materiais podendo ate cair no mesmo material
        {
            Score.coinsCalculo += 999999;
        }
        
    }
}
