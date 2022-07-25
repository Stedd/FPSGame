using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{

    public InputAction fireAction;
    public InputAction reloadAction;

    List<InputAction> inputActions;

    private void Awake()
    {
        inputActions = new();
        inputActions.Add(fireAction);
        inputActions.Add(reloadAction);

        fireAction.performed += FireWeapon;
        reloadAction.performed += ReloadWeapon;
    }

    private void OnEnable()
    {
        foreach (InputAction inputAction in inputActions)
        {
            inputAction.Enable();
        }
    }

    private void OnDisable()
    {
        foreach (InputAction inputAction in inputActions)
        {
            inputAction.Disable();
        }
    }

    private void FireWeapon(InputAction.CallbackContext obj)
    {
        print("Boom!");
    }

    private void ReloadWeapon(InputAction.CallbackContext obj)
    {
        print("Reload!");
    }
}
