using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetoAleatorio : MonoBehaviour
{
    [SerializeField] private GameObject[] objetosPrefabs;
    [SerializeField] private Transform jugador;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    void Start()
    {
        //InvokeRepeating(nameof(GenerarObjetoAleatorio), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjetoAleatorio()
    {
        int indexAleatorio = Random.Range(0, objetosPrefabs.Length);
        GameObject prefabAleatorio = objetosPrefabs[indexAleatorio];

        GameObject newObject = Instantiate(prefabAleatorio, transform.position, Quaternion.identity);

        if (newObject.GetComponent<Chase>())
        {
            newObject.GetComponent<Chase>().Jugador = jugador;
            newObject.GetComponent<Chase>().Velocidad = 3;
        }

        if (gameObject.GetComponent<SelfDestructChilds>())
        {
            Debug.Log("Self destruct");
            //newObject.AddComponent<SeltDestruct>();
            //newObject.GetComponent<SeltDestruct>().Duration = gameObject.GetComponent<SelfDestructChilds>().ChildLifetime;
        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log("El SpriteRenderer deja de ser visible por las cámaras en la escena");
        CancelInvoke(nameof(GenerarObjetoAleatorio));
    }

    private void OnBecameVisible()
    {
        Debug.Log("El SpriteRenderer es visible por las cámaras en la escena");
        InvokeRepeating(nameof(GenerarObjetoAleatorio), tiempoEspera, tiempoIntervalo);
    }
}