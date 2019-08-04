using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoTeste2 : Dialogo
{
    void Start()
    {
        resp1 = new string[] { "Ela está escondida atrás do balcão. Ela tem medo de tempestades.", "Considerando que eu era péssima na aula de química, talvez tenhamos men...BOOM!" };
        intro = new string[] { "Que você está fazendo aqui? Estamos fechados! F, e, c... ados." };
        resposta = Respostas.intro;
    }

    protected override void Intro()
    {
        StartCoroutine(ApareceTexto(intro[0]));
        base.Intro();
    }

    protected override void PulaTexto()
    {
        b.SetActive(true);
        base.PulaTexto();
    }

    protected override void Resposta01()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
        base.Resposta01();
    }

    protected override void Resposta02()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        base.Resposta02();
    }
}
