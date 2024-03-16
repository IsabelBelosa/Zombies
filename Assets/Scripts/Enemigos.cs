using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigos : MonoBehaviour
{
    // Start is called before the first frame update
    float vidarestante;
    public Image imgbarraVida;
    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();        
    }

    // Update is called once per frame
    void Update()
    {
        pathfinder.SetDestination(target.position);
    }

    public void hesidotocado()
    {
        Debug.Log("4-Estoy en el enemigo");
        vidarestante = GetComponent<gestionVidas>().vida / GetComponent<gestionVidas>().MaxVida;
        imgbarraVida.transform.localScale = new Vector3(vidarestante, 1, 1);
    }

    public void estoyMuerto()
    {
        Debug.Log("5-MUERTO");
        Destroy(gameObject);
    }
}
