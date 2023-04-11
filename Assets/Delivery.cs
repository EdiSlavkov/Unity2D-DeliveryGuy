using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] Color32 hasPackageColor = new Color32(255, 16, 10, 255);
    [SerializeField] Color32 noPackageColor = new Color32(10, 255, 35, 255);
    [SerializeField] float destroyDelay = 0.3f;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ops");
    }

    void OnTriggerEnter2D(Collider2D element)
    {
        if (element.tag == "Package" && !hasPackage)
        {
            Debug.Log("Picked");
            hasPackage = true;
            Destroy(element.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        if (element.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
