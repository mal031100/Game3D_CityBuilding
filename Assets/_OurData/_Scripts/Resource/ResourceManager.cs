using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    [SerializeField] protected List<Resource> resources;

    protected void Awake()
    {
        if (ResourceManager.instance != null) Debug.LogError("On 1 ResourceManager allow");
        ResourceManager.instance = this;
    }

    protected virtual void AddResource(ResourceName resourceName, int number)
    {

    }
}
