using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private HealthController hc;
    [SerializeField] bool stayOnContact;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        hc.playerHealth = hc.playerHealth - damage;
        hc.UpdateHealth();
        gameObject.SetActive(stayOnContact);
    }
}
