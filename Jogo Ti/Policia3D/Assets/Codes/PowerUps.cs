using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int ID;
    public static PowerUps InstanciarPowerUps;

    public float rotationSpeed = 100f; // velocidade de rotação
    public float moveSpeed = 1f; // velocidade de movimento vertical
    public float moveHeight = 0.5f; // altura máxima do movimento

    private Vector3 startPosition;
    private bool movingUp = true;

    private void Awake()
    {
        InstanciarPowerUps = this;
        startPosition = transform.position;
    }

    private void Update()
    {
        // Faz o objeto rotacionar constantemente no eixo Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Movimento de cima para baixo (oscilar)
        float newY = Mathf.Sin(Time.time * moveSpeed) * moveHeight;
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }

    public int PowerUpID()
    {
        return ID;
    }
}
