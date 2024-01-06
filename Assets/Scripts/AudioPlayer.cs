using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 0.5f;

    [Header("Being Hit")]
    [SerializeField] AudioClip hitSoundClip;
    [SerializeField] [Range(0f, 1f)] float hitVolume = 0.8f;

    static AudioPlayer instance;

    // getter for singleton class so it cant be modified from outside
    public AudioPlayer getInstance()
    {
        return instance;
    }

    private void Awake()
    {
        ManageSingleton();
    }

    public void PlayShootingSound()
    {
        if(shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayHitSound()
    {
        if (hitSoundClip != null)
        {
            AudioSource.PlayClipAtPoint(hitSoundClip, Camera.main.transform.position, hitVolume);
        }
    }
    
    void ManageSingleton()
    {
        // get type returns name of current class
        // first 2 lines is one way of creating singleton
        //int instanceCount = FindObjectsOfType(GetType()).Length;
        //if(instanceCount > 1 )
        if(instance != null)
        {
            // we are setting it to false due to execution order
            // so the order at which it will pick audio player object might be different
            // at a very small chance which would destroy wrong object
            gameObject.SetActive(false); 
            Destroy(gameObject);
        } else
        {
            instance = this; // 2nd way of creating singleton
            DontDestroyOnLoad(gameObject);
        }
    }
}
