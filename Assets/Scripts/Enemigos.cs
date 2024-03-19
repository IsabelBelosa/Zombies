using UnityEngine;
using UnityEngine.UI;

public class Enemigos : MonoBehaviour
{
    float vidarestante;
    public Image imgbarraVida;
    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            pathfinder.SetDestination(target.position);

            float distanciaAlJugador = Vector3.Distance(transform.position, target.position);
            if (distanciaAlJugador <= 1.5f) // Si el enemigo está cerca del jugador, atacar
            {
                AtacarJugador();
            }
        }
    }

    // Método para atacar al jugador
    void AtacarJugador()
    {
        // Implementa tu lógica de ataque aquí
        Debug.Log("El enemigo está atacando al jugador");

        if (target != null && target.GetComponent<Jugador>().puedeSerAtacado)
        {
            target.GetComponent<Jugador>().DenegarAtaque(); // Desactiva la bandera para evitar ataques múltiples
            Jugador.IncrementarVecesAtacado();
            Invoke("PermitirAtaque", 1.0f); // Restablece la bandera después de 1 segundo
        }
    }

    void PermitirAtaque()
    {
        if (target != null)
        {
            target.GetComponent<Jugador>().PermitirAtaque(); // Restablece la bandera
        }
    }

    public void hesidotocado()
    {
        Debug.Log("Estoy en el enemigo");
        vidarestante = GetComponent<gestionVidas>().vida / GetComponent<gestionVidas>().MaxVida;
        imgbarraVida.transform.localScale = new Vector3(vidarestante, 1, 1);
    }

    public void estoyMuerto()
    {
        Debug.Log("El enemigo ha muerto");
        Destroy(gameObject);
    }
}
