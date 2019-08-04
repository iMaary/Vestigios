using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PerguntasMapa : MonoBehaviour
{
    private DialogoMapa dl;
    [SerializeField] private Respostas rp;
    private Button b;

    void Start()
    {
        //dl = UIController.Instance.dialogoMapa;
        SetDefault();
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
