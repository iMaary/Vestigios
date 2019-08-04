using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class Perguntas : MonoBehaviour
{
    //private Dialogo dl;
    //[SerializeField] private Respostas rp;
    //private Button b;

    void Start()
    {
        //dl = GameObject.FindWithTag("Dialogo").GetComponent<Dialogo>();
        SetDefault();
    }

    private void SetDefault()
    {
        gameObject.SetActive(true);
        GetComponent<Button>().onClick.AddListener(Click);
    }

    public void Click()
    {
        //dl.resposta = rp;
        gameObject.SetActive(false);
        UIController.Instance.CheckConsequences();
    }
}
