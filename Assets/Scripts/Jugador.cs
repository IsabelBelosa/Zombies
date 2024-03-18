using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Transform salida;
    float proximodisparo = 0f;
    float tiempodeEspera = 0.3f;
    public GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        salida = gameObject.transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= proximodisparo && Input.GetMouseButtonDown(0))
        {
            proximodisparo = Time.time + tiempodeEspera;
            Debug.Log(" 1 - he disparado");
            GameObject nuevabala = Instantiate(bala, salida.position, salida.rotation);
        }
    }
}
