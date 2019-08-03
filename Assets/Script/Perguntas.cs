using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class Perguntas : MonoBehaviour
{
    [SerializeField] private Dialogo dl;
    [SerializeField] private Respostas rp;
    private Button b;

    void Start()
    {
        SetDefault();
    }

    void FixedUpdate()
    {
    }

    private void SetDefault()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    public void Click()
    {
        dl.resposta = rp;
    }
}
