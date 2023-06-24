using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false;

    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
    }

    void Update()
    {
        
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (pressed)
        {
            ShopManager.instance.toggleShop();
        }
    }
}
