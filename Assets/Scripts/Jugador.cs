using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    Transform salida;
    float proximodisparo = 0f;
    float tiempodeEspera = 0.3f;
    public GameObject bala;
    public static int vecesAtacado = 0; // Contador de veces atacado
    public bool puedeSerAtacado = true; // Bandera para controlar si el jugador puede ser atacado
    public delegate void OnDeathJugador();
    public static event OnDeathJugador OnDeathPlayer;
    
    void Start()
    {
        salida = gameObject.transform.GetChild(0).transform;
    }

    void Update()
    {
        if(Time.time >= proximodisparo && Input.GetMouseButtonDown(0))
        {
            proximodisparo = Time.time + tiempodeEspera;
            Debug.Log(" 1 - he disparado");
            GameObject nuevabala = Instantiate(bala, salida.position, salida.rotation);
        }
    }

    // Método para incrementar el contador de veces atacado
    public static void IncrementarVecesAtacado()
    {
        if (vecesAtacado < 3) // Solo incrementar si no se ha alcanzado el límite
        {
            vecesAtacado++;
            // Verifica si el jugador ha sido atacado tres veces
            if (vecesAtacado == 3)
            {
                Morir();
            }
        }
    }

    // Método para manejar la muerte del jugador
    static void Morir()
    {
        // Notifica a los suscriptores de que el jugador ha muerto
        if (OnDeathPlayer != null)
        {
            OnDeathPlayer();
        }

        // Carga la escena de "HasPerdido"
        SceneManager.LoadScene("HasPerdido");

        // Destruye al jugador
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    // Método para activar la bandera que permite al jugador ser atacado
    public void PermitirAtaque()
    {
        puedeSerAtacado = true;
    }

    // Método para desactivar la bandera que permite al jugador ser atacado
    public void DenegarAtaque()
    {
        puedeSerAtacado = false;
    }
}
