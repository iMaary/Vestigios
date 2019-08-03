using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogo : MonoBehaviour
{
    public Respostas resposta;
    [SerializeField] private Text textoResposta;
    private string padrao = "";
    private string[] resp1;
    private string[] intro;
    private bool terminouTexto = true;
    [SerializeField] private GameObject b, canva;
    [SerializeField] SpriteRenderer tabuleiro;

    void Start()
    {

        resp1 = new string[] { "você apertou na primeira perguntar", "você apertou na segunda perguntar" };
        intro = new string[] { "Já estou nesse ônibus a três horas. Acabei cochilando mas a estrada cheia de buracos me fez acordar. Sonhei com minha amiga, desaparecida há quase um mês, e o motivo pelo qual estou fazendo essa viagem. Preciso saber onde ela está. Recebi uma mensagem falando que ela foi vista nessa cidade.", " A cidade está vazia. Nenhuma alma viva rondando esse lugar. Posso jurar que vi uma bola de feno se arrastando pelo chão. Os únicos três prédios nesse lugar são uma Igreja, um Bar e uma Fazenda. Que cidadezinha mais estranha..." };
        resposta = Respostas.intro;
    }

    void Update()
    {
        if(terminouTexto)
            ControllerTexts();
    }

    private void ControllerTexts()
    {
        switch (resposta)
        {
            case Respostas.intro:
                StartCoroutine(ApareceTexto(intro[0]));
                PadraoTextos();
                break;
            case Respostas.pulaTexto:
                StartCoroutine(ApareceTexto(intro[1]));
                b.SetActive(true);
                PadraoTextos();
                break;
            case Respostas.respostaUm:
                canva.SetActive(false);
                tabuleiro.color = new Color(1,1,1,1);
                PadraoTextos();
                break;
            case Respostas.respostaDois:
                SceneManager.LoadScene("GameOver");
                PadraoTextos();
                break;
            default:
                break;
        }
    }

    private void PadraoTextos()
    {
        resposta = Respostas.nulo;
        terminouTexto = false;
    }

    public IEnumerator ApareceTexto(string resp)
    {
        for (int i = 0; i <= resp.Length; i++)
        {
            padrao = resp.Substring(0, i);
            textoResposta.text = padrao;
            yield return new WaitForSeconds(0.07f);
        }
        textoResposta.text = resp;
        terminouTexto = true;
    }

}
