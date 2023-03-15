using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{


    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
     [SerializeField] float destroyDelay = 0.5f;
 
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0,moveAmount,0);
        transform.Rotate(0, 0, -steerAmount);
    }

        private void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Speed Up") {
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, destroyDelay);
        }
        if(other.tag == "Slow Down") {
            moveSpeed = slowSpeed;
            Destroy(other.gameObject, destroyDelay);
        }
    }
}
