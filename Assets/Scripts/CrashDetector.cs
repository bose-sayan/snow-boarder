using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    private CircleCollider2D _playerHead;
    [SerializeField] private float reloadDelay = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;

    private void Start()
    {
        _playerHead = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") && _playerHead.IsTouching(col.collider))
        {
            Debug.Log("Ouch!");
            crashEffect.Play();
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
