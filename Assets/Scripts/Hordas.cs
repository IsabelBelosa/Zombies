using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hordas : MonoBehaviour
{
    public ValoresEnemigos [] valoresEnemigos;
    public ValoresEnemigos enemigoActual;
    public Transform jugador;
    public float distanciaEnemigoJugador;
    float tiempoEspera;
    int numHordaActual = 0;
    int enemigosPorCrear = 0;
    int enemigosPorMatar = 0;
    Vector3 spawn;
    
    // Start is called before the first frame update
    void Start()
    {
        NextHorda();
        gestionVidas.onDieEnemy += enemigoMuetro;
    }

    void NextHorda(){
        numHordaActual++;
        enemigoActual = valoresEnemigos[numHordaActual-1];
        enemigosPorCrear= enemigoActual.numeroEnemigos;
        enemigosPorMatar = enemigoActual.numeroEnemigos;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigosPorCrear > 0 && tiempoEspera <= 0){
            spawn = jugador.position;
            spawn += new Vector3 (Random.Range(-distanciaEnemigoJugador, distanciaEnemigoJugador), 0, Random.Range(-distanciaEnemigoJugador, distanciaEnemigoJugador));
            Instantiate(enemigoActual.tipoEnemigo, spawn, Quaternion.identity);
            enemigosPorCrear--;
            tiempoEspera = enemigoActual.tiempoEntreEnemigos;
        }
        else{
            tiempoEspera -= Time.deltaTime;
        }
    }

    void enemigoMuetro(){
        enemigosPorMatar--;
        if (enemigosPorMatar == 0){
            NextHorda();
        }
    }
}
