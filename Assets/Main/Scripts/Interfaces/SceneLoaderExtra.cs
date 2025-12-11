using System;
using UnityEngine;
using UnityEngine.Events;
public class SceneLoaderExtra : MonoBehaviour
{
    [Tooltip("When you press th escape button")] public UnityEvent OnESCPressed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            OnESCPressed.Invoke();

    }
}
