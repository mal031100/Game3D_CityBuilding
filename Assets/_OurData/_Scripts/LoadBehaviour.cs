using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void FixedUpdate()
    {
        // For overide
    }

    protected virtual void LoadComponents()
    {
        // For Overide
    }
}
