using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f, projectileLifetime = 5f, firingRate = 0.3f;

    [Header("AI")]
    [SerializeField] bool useAI = true;
    [SerializeField] float firingRateVariance = 0.2f;
    [SerializeField] float minimumFiringRate = 0.2f;

    [HideInInspector] public bool isFiring;
    AudioPlayer audioPlayer;

    Coroutine firingCoroutine;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        } else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }        
    }

    IEnumerator FireContinuously()
    {
        do
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D projectileBody = projectile.GetComponent<Rigidbody2D>();
            if(projectileBody != null)
            {
                if(useAI)
                {
                    projectileBody.velocity = -(transform.up) * projectileSpeed;
                } else
                {
                    projectileBody.velocity = transform.up * projectileSpeed;
                }
            }

            Destroy(projectile, projectileLifetime);
            audioPlayer.PlayShootingSound();

            // if its player then firing rate should be consisten, if enemy then add a bit of randomizer
            if (useAI)
            {
                float fireRate = Random.Range(firingRate - firingRateVariance, firingRate + firingRateVariance);
                fireRate = Mathf.Clamp(fireRate, minimumFiringRate, float.MaxValue);

                yield return new WaitForSeconds(fireRate);
            } else
            {
                yield return new WaitForSeconds(firingRate);
            }
        } while (isFiring);
    }
}
