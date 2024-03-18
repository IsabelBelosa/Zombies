using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidad = 20.0f;
    public float valorherida = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movDistancia = Time.deltaTime* velocidad;
        transform.Translate(Vector3.up * movDistancia);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("he chocado");
        other.SendMessage("tocado",valorherida, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}


