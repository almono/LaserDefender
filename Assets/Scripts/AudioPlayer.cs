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
}
