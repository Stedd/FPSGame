using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas _gameOverCanvas;

    private void Start()
    {
        _gameOverCanvas.enabled = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            HandleDeath();
        }
    }

    public void HandleDeath()
    {
        print("Player died");
        _gameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}