using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gestionVidas : MonoBehaviour
{
    public float vida = 5f;
    public float MaxVida = 5f;

    public UnityEvent hesidotocado;
    public UnityEvent estoyMuerto;
    public delegate void OnDieEnemy();
    public static event OnDieEnemy onDieEnemy;

    public void TakeHit(float damage, RaycastHit hit){

        tocado(damage);
    }

    void tocado(float fuerza)
    {
        Debug.Log("-3 quito fuerza");
        vida -= fuerza;
        hesidotocado.Invoke();
        if(vida <= 0)
        {
            estoyMuerto.Invoke();
            if (onDieEnemy != null){
                onDieEnemy();
            }
        }
    }
}
