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
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private bool hasCrashed;

    private void Start()
    {
        _playerHead = GetComponent<CircleCollider2D>();
        hasCrashed = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!hasCrashed && col.gameObject.CompareTag("Ground") && _playerHead.IsTouching(col.collider))
        {
            Debug.Log("Ouch!");
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            GetComponent<PlayerController>().DisableInput();
            hasCrashed = true;
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
