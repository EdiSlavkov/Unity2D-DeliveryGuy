using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 0.5f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float boostDuration = 2f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D gameObject)
    {
        if (gameObject.tag == "Booster")
        {
            StartCoroutine(Boost());
        }
        if (gameObject.tag == "Obstacle")
        {
            StartCoroutine(Slow());
        }
    }
    
    IEnumerator Boost()
    {
        moveSpeed = boostSpeed;
        yield return new WaitForSeconds(boostDuration);
        moveSpeed = 15f;
    }

    IEnumerator Slow()
    {
        moveSpeed = slowSpeed;
        yield return new WaitForSeconds(boostDuration);
        moveSpeed = 15f;
    }
}