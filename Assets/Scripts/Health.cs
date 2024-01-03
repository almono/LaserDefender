using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int maxHealth = 50;
    [SerializeField] ParticleSystem explosionEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();

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
            ShakeCamera();
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

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
