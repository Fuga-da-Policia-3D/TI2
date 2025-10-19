using UnityEngine;

public class CopActions : MonoBehaviour
{
    public GameObject playerlocation;
    public float moveSpeed = 2.0f;
    //camera pos para salvar (-11.32,1.48,0) rotation (0,90,0)

    public Vector3 offset = new Vector3(-2, 0, 0);

    private void Update()
    {
        if (MovingThings.isSlowed)
        {
            Vector3 targetPosition = playerlocation.transform.position + offset;

            
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
