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

    void Start()
    {

        resp1 = new string[] { "você apertou na primeira perguntar", "você apertou na segunda perguntar" };
        intro = new string[] {"estou andando de Ônibus..." , "eu vou salvar minha amiga?"};
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
                PadraoTextos();
                break;
            case Respostas.respostaDois:
                //referencia da scene game over
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
            yield return new WaitForSeconds(0.09f);
        }
        terminouTexto = true;
    }

}
