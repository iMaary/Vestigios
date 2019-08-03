using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoMenu : MonoBehaviour
{
    public void Aumenta()
    {
        transform.localScale *= 1.2f;
    }
    public void Normal()
    {
        transform.localScale /= 1.2f;
    }
}
