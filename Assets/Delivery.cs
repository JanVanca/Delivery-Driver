using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision detected");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && hasPackage == false) {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        if(other.tag == "Customer" && hasPackage == true) {
            Debug.Log("Package delivered");
            hasPackage = false;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = noPackageColor;
        }
    }
}
