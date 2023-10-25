using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Herir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int damagePoints = 1;
    [SerializeField] Boolean disableOnHit = false;
     
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.ReceiveDamage(damagePoints);
            if (disableOnHit) gameObject.SetActive(false);
        }
    }
}