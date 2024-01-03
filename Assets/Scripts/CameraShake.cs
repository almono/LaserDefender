using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.3f, shakeMagnitude = 0.2f;
    Vector3 initialCamPosition;
    void Start()
    {
        initialCamPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float shakeTime = 0f;

        while(shakeTime < shakeDuration)
        {
            transform.position = initialCamPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            shakeTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        transform.position = initialCamPosition;
    }
}
