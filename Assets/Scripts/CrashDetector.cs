using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    private CircleCollider2D playerHead;

    private void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") && playerHead.IsTouching(col.collider))
        {
            Debug.Log("OUCH!");
        }
    }
}
