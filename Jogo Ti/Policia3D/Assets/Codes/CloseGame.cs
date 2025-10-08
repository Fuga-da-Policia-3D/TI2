using UnityEngine;
using UnityEngine.UI;

public class CloseGame : MonoBehaviour
{
    void Start()
    {
        Button botao = GetComponent<Button>();
        if (botao != null)
        {
            botao.onClick.AddListener(SairDoJogo);
        }
    }

    public void SairDoJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}