using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoMapa : MonoBehaviour
{

    //[Header("Data")]
    //public DialogData data;

    [Header("Settings")]
    public Respostas resposta;
    public List<string> respostas = new List<string>();

    [SerializeField] private Text textoResposta;
    private string padrao = "";

    private void Awake()
    {
        resposta = Respostas.nulo;
        //StartCoroutine(ApareceTexto(data.questions[0].questionText));

        //GameManager.Instance.UpdateData(data);
        //UIController.Instance.dialogoMapa = this;
    }

    void Update()
    {
        //ControllerTexts();
    }

    private void ControllerTexts()
    {
        switch (resposta)
        {
            case Respostas.respostaUm:
                StartCoroutine(ApareceTexto(respostas[0]));
                PadraoTextos();
                break;
            case Respostas.respostaDois:
                StartCoroutine(ApareceTexto(respostas[1]));
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
        for (int i = 0; i <= resp.Length; i++)
        {
            padrao = resp.Substring(0, i);
            textoResposta.text = padrao;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
