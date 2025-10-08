using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ChangeScenee : MonoBehaviour
{
    public string nomeCena = "test"; 

    void Start()
    {
        Button botao = GetComponent<Button>();
        if (botao != null)
        {
            botao.onClick.AddListener(FaseChange);
        }
    }

    void FaseChange()
    {
        if (!string.IsNullOrEmpty(nomeCena))
        {
            SceneManager.LoadScene(nomeCena);
        }
    }
}