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
        intro = new string[] { "A igreja está fechada! Sem primeira comunhão hoje! Fora! Que diachos você está vestindo, garota?!", "O padre muda sua expressão mas não sei se foi a pergunta ou só um efeito do álcool.\n 'Ninguém entra ou sai dessa igreja há duas semanas!'\n  Ele cambaleia um pouco mas volta a olhar para mim. Quem sabe dessas coisas é o dono do bar. Nunca vi uma alma mais perdida. Talvez você ache sua amiga desaparecida por lá. Agora, FORA!", "O padre parece confuso. Ele tropeça para trás e cai de bunda no chão. 'Ah, que se dane. Vá lá dentro e pegue uma garrafa de vinho no altar.' O padre se deita no chão e soluça."};
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
        Invoke("VaiMenu", 20f);
    }

    protected override void Resposta02()
    {
        StartCoroutine(ApareceTexto(intro[2]));
        base.Resposta02();
        Invoke("VaiMenu", 20f);
    }

    void VaiMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Mapa");
    }
}
