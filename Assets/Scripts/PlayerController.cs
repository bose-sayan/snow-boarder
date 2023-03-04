using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 15f;
    [SerializeField] private float boostSpeed = 45f;
    [SerializeField] private float normalSpeed = 25f;
    [SerializeField] bool canPlay;
    private Rigidbody2D _rb2D;
    private SurfaceEffector2D _surfaceEffector2D;
    
    private void Start()
    {
        canPlay = true;
        _rb2D = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (canPlay)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableInput()
    {
        canPlay = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _surfaceEffector2D.speed = boostSpeed;
        } 
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _surfaceEffector2D.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb2D.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb2D.AddTorque(-torqueAmount);
        }
    }
}
