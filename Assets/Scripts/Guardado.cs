using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardado : MonoBehaviour
{
    public static Guardado Instancia;

    private void Awake()
    {
        if(Guardado.Instancia == null)
        {
            Guardado.Instancia = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
