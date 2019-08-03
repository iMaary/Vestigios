using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    public Respostas resposta;
    [SerializeField] private Text textoResposta;
    private string padrao = "";
    private string[] resp1;

    void Start()
    {
        resp1 = new string[] { "você apertou na primeira perguntar", "você apertou na segunda perguntar" };
    }

    void Update()
    {
        ControllerTexts();
    }

    private void ControllerTexts()
    {
        switch (resposta)
        {
            case Respostas.respostaUm:
                StartCoroutine(ApareceTexto(resp1[0]));
                PadraoTextos();
                break;
            case Respostas.respostaDois:
                StartCoroutine(ApareceTexto(resp1[1]));
                PadraoTextos();
                break;
            default:
                break;
        }
    }

    private void PadraoTextos()
    {
        resposta = Respostas.nulo;
    }

    public IEnumerator ApareceTexto(string resp)
    {
        for (int i = 0; i < resp.Length; i++)
        {
            padrao = resp.Substring(0, i);
            textoResposta.text = padrao;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
