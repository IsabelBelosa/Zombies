using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gestionVidas : MonoBehaviour
{
    public float vida = 10f;
    public float MaxVida = 10f;

    public UnityEvent hesidotocado;
    public UnityEvent estoyMuerto;

    void tocado(float fuerza)
    {
        Debug.Log("-3 quito fuerza");
        vida -= fuerza;
        hesidotocado.Invoke();
        if(vida <= 0)
        {
            estoyMuerto.Invoke();
        }
    }
}
