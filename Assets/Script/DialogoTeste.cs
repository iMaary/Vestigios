using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoTeste : Dialogo
{

    void Start()
    {
        resp1 = new string[] { "Você por acaso não viu uma garota da minha idade por aqui nos últimos dias, viu?", "É assim que góticos se vestem hoje em dia. Hoje é o dia anual de conhecer um novo cemitério." };
        intro = new string[] { "A igreja está fechada! Sem primeira comunhão hoje! Fora! Que diachos você está vestindo, garota?!", "A", "B"};
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
        base.Intro();
    }

    protected override void Resposta01()
    {
        StartCoroutine(ApareceTexto(intro[1]));
        base.Resposta01();
    }

    protected override void Resposta02()
    {
        StartCoroutine(ApareceTexto(intro[2]));
        base.Resposta02();
    }

}
