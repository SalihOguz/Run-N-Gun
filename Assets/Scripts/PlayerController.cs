using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public UnityAction OnDead;
    public UnityAction OnWon;
    
    [SerializeField] private float speed = 8f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Animator animator;
    [SerializeField] private CinemachineVirtualCamera finishCam;

    private bool _isActive = true;
    
    private float mZCoord;
    private Vector3 mOffset;
    private bool _hasGameStarted;
    private WeaponControlller _weaponControlller;
    private bool _finishReached;

    private void Start()
    {
        _weaponControlller = FindObjectOfType<WeaponControlller>();
        _weaponControlller.HasRifle += ToggleHasRifle;
    }

    private void OnDestroy()
    {
        _weaponControlller.HasRifle -= ToggleHasRifle;
    }

    private void ToggleHasRifle(bool hasRifle)
    {
        animator.SetBool("hasPistol", !hasRifle);
    }

    void Update()
    {
        if (!_isActive)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!_hasGameStarted)
            {
                _hasGameStarted = true;
                animator.SetTrigger("Run");
            }
            
            mZCoord = mainCamera.WorldToScreenPoint(transform.position).z;
            mOffset = transform.position - GetMouseWorldPos();
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPos = GetMouseWorldPos() + mOffset;

            transform.position = new Vector3(Mathf.Clamp(newPos.x, -2.3f, 2.3f), 0, transform.position.z);
        }

        if (_hasGameStarted)
        {
            transform.position += Vector3.forward * (Time.deltaTime * speed);
        }
    }
    
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (!_finishReached)
            {
                Lose();
            }
            else
            {
                OnWon?.Invoke();
                animator.enabled = false;
                _weaponControlller.Stop();
                _isActive = false;
            }
        }
        else if (other.CompareTag("Finish"))
        {
            if (!_finishReached)
            {
                _finishReached = true;
                finishCam.Priority = 100;
            }
            else
            {
                OnWon?.Invoke();
                _isActive = false;
                animator.Play("Dance");
                animator.transform.DORotate(new Vector3(0, 180, 0), 1f);
                _weaponControlller.Stop();
                finishCam.Priority = 0;
            }
        }
    }

    private void Lose()
    {
        animator.enabled = false;
        _weaponControlller.Stop();
        _isActive = false;
        OnDead?.Invoke();
    }
}
