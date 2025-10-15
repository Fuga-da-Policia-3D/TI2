using UnityEngine;

public class ScenaryMake : MonoBehaviour
{
    private int x = 0 ;
    private Vector3 distorcao = new Vector3(750, 0, 0); 
    public int distanciaCaminhodestruir = 750;
    public GameObject[] Cenarios;
    public GameObject caminhoDireita, caminhoEsquerda;
    private GameObject scenaryDireita, scenenaryEsquerda;
    private void Start()
    {
        int rng = Random.Range(0, Cenarios.Length);
        scenaryDireita = Instantiate(Cenarios[rng], caminhoDireita.transform.position, caminhoDireita.transform.rotation);
        scenenaryEsquerda = Instantiate(Cenarios[rng], caminhoEsquerda.transform.position, caminhoEsquerda.transform.rotation);// inicio do jogo
    }

    private void Update()
    {
        if(x + distanciaCaminhodestruir < Score.scoreCalculo)
        {
            Invoke("DestruirPath", 0.5f);
            Invoke("CriarPath", 1f);
            x += distanciaCaminhodestruir;
        }
    }


    public void DestruirPath()
    {
        Destroy(scenenaryEsquerda);
        Destroy(scenaryDireita);
    }

    public void CriarPath()
    {
        int rng = Random.Range(0, Cenarios.Length);

        scenaryDireita = Instantiate(Cenarios[rng], caminhoDireita.transform.position + distorcao, caminhoDireita.transform.rotation);
        scenenaryEsquerda = Instantiate(Cenarios[rng], caminhoEsquerda.transform.position + distorcao, caminhoEsquerda.transform.rotation);// inicio do jogo
        distorcao.x += 750;
    }
}
