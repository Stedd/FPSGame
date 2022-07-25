using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{

    private void Awake()
    {

        //fireAction.performed += OnFire;
        //reloadAction.performed += OnReload;
    }

    private void OnFire()
    {
        print("Boom!");
    }

    private void OnReload()
    {
        print("Reload!");
    }
}
