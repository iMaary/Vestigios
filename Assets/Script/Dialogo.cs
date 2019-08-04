using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogo : MonoBehaviour
{
    public Respostas resposta;
    [SerializeField] private Text textoResposta;

    protected string padrao = "";
    protected string[] resp1;
    protected string[] intro;
    protected bool terminouTexto = true;
    [SerializeField] protected GameObject b;
    [SerializeField] protected SpriteRenderer tabuleiro;

    protected void Update()
    {
        if(terminouTexto)
            ControllerTexts();
    }

    protected void ControllerTexts()
    {
        switch (resposta)
        {
            case Respostas.intro:
                Intro();
                PadraoTextos();
                break;
            case Respostas.pulaTexto:
                PulaTexto();
                PadraoTextos();
                break;
            case Respostas.respostaUm:
                Resposta01();
                PadraoTextos();
                break;
            case Respostas.respostaDois:
                Resposta02();
                PadraoTextos();
                break;
            default:
                break;
        }
    }

    #region Respostas
    protected virtual void Intro()
    {
        PadraoTextos();
    }

    protected virtual void PulaTexto()
    {
        PadraoTextos();
    }

    protected virtual void Resposta01()
    {
        PadraoTextos();
    }
    protected virtual void Resposta02()
    {
        PadraoTextos();
    }
    #endregion

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

    public void Quit()
    {
        Application.Quit();
    }

}
