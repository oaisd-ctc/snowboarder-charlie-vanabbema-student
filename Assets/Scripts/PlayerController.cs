using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float boostSpeed =30f;
    [SerializeField] float baseSpeed = 15f;
    bool canMove = true;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
