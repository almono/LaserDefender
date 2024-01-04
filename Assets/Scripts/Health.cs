using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int maxHealth = 50;
    [SerializeField] ParticleSystem explosionEffect;
    [SerializeField] bool isPlayer;
    [SerializeField] int scoreValue = 50;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    UI uiDisplay;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper.ResetScore();

        uiDisplay = FindObjectOfType<UI>();

        if(health >  maxHealth)
        {
            health = maxHealth;
        }

        uiDisplay.SetMaxHealth(maxHealth);
        uiDisplay.UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dmgDealer = other.GetComponent<DamageDealer>();

        if(dmgDealer != null)
        {
            TakeDamage(dmgDealer.GetDamage());
            ShowHitEffect();
            ShakeCamera();
            audioPlayer.PlayHitSound();
            dmgDealer.Hit();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(isPlayer)
        {
            uiDisplay.UpdateHealthDisplay();
        }

        if(health <= 0)
        {
            Destroy(gameObject);

            if(!isPlayer)
            {
                scoreKeeper.AddScore(scoreValue);
                uiDisplay.UpdateScoreText();
            }
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

    public int GetHealth()
    {
        return health;
    }
}
