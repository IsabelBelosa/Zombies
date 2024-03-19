using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Jugador : MonoBehaviour
{
    Transform salida;
    float proximodisparo = 0f;
    float tiempodeEspera = 0.3f;
    public Text contador; // Ahora es una variable de instancia
    float vida = 3f; // Ahora es una variable de instancia
    public GameObject bala;
    public static int vecesAtacado = 0; // Contador de veces atacado
    public bool puedeSerAtacado = true; // Bandera para controlar si el jugador puede ser atacado
    public delegate void OnDeathJugador();
    public static event OnDeathJugador OnDeathPlayer;
    
    void Start()
    {
        salida = gameObject.transform.GetChild(0).transform;
        ActualizarContadorVidas(); // Actualiza el contador de vidas al inicio
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
    public void IncrementarVecesAtacado() // Ahora no es estático
    {
        if (vecesAtacado < 3) // Solo incrementar si no se ha alcanzado el límite
        {
            vecesAtacado++;
            vida--;
            ActualizarContadorVidas(); // Actualiza el contador de vidas
            // Verifica si el jugador ha sido atacado tres veces
            if (vecesAtacado == 3)
            {
                Morir();
            }
        }
    }

    // Método para manejar la muerte del jugador
    void Morir() // Ahora no es estático
    {
        // Notifica a los suscriptores de que el jugador ha muerto
        if (OnDeathPlayer != null)
        {
            OnDeathPlayer();
        }

        // Carga la escena de "HasPerdido"
        SceneManager.LoadScene("HasPerdido");

        // Destruye al jugador
        Destroy(gameObject);
    }

    // Método para actualizar el contador de vidas en el UI
    void ActualizarContadorVidas() // Ahora no es estático
    {
        contador.text = "Vidas: " + vida;
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
