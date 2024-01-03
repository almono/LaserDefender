using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material bgMaterial;

    void Awake()
    {
        bgMaterial = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        bgMaterial.mainTextureOffset += offset;
    }
}
