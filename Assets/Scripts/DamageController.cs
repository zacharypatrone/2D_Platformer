using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int damage = 1;
    [SerializeField] private HealthController hc;
    [SerializeField] bool stayOnContact;

    // AUDIO
    // [SerializeField] private AudioSource damageSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        // damageSound.Play();
        hc.playerHealth = hc.playerHealth - damage;
        hc.UpdateHealth();
        gameObject.SetActive(stayOnContact);
    }

    public void setDamage(int dmg)
    {
        damage = dmg;
    }
}
