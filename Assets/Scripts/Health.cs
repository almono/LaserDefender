using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int maxHealth = 50;
    [SerializeField] ParticleSystem explosionEffect;

    private void Awake()
    {
        if(health >  maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dmgDealer = other.GetComponent<DamageDealer>();

        if(dmgDealer != null)
        {
            TakeDamage(dmgDealer.GetDamage());
            ShowHitEffect();
            dmgDealer.Hit();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ShowHitEffect()
    {
        if(explosionEffect != null)
        {
            ParticleSystem instance = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
