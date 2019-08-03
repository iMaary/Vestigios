using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoIntro : Dialogo
{

    void Start()
    {
        resp1 = new string[] { "você apertou na primeira perguntar", "você apertou na segunda perguntar" };
        intro = new string[] { "Já estou nesse ônibus a três horas. Acabei cochilando mas a estrada cheia de buracos me fez acordar. Sonhei com minha amiga, desaparecida há quase um mês, e o motivo pelo qual estou fazendo essa viagem. Preciso saber onde ela está. Recebi uma mensagem falando que ela foi vista nessa cidade.", " A cidade está vazia. Nenhuma alma viva rondando esse lugar. Posso jurar que vi uma bola de feno se arrastando pelo chão. Os únicos três prédios nesse lugar são uma Igreja, um Bar e uma Fazenda. Que cidadezinha mais estranha..." };
        resposta = Respostas.intro;
    }

    protected override void Intro()
    {
        StartCoroutine(ApareceTexto(intro[0]));
        base.Intro();
    }

    protected override void PulaTexto()
    {
        StartCoroutine(ApareceTexto(intro[1]));
        b.SetActive(true);
        base.PulaTexto();
    }

    protected override void Resposta01()
    {
        canva.SetActive(false);
        botoes.SetActive(true);
        tabuleiro.color = new Color(1, 1, 1, 1);
        base.Resposta01();
    }

    protected override void Resposta02()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        base.Resposta02();
    }

}
