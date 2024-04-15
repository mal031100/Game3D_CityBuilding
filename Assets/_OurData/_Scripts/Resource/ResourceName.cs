using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResNameParser
{
    public static ResourceName FromString(string name)
    {
        //name = name.ToLower();
        return (ResourceName) Enum.Parse(typeof(ResourceName), name);
    }
}

public enum ResourceName
{
    noResource = 0,

    // currency - money
    gold = 1,
    diamond = 2,

    // Material level 1
    water = 1000,
    logwood = 1001,
    ironOre = 1002,


    // Material level 2
    blank = 2001,
    ironIngot = 2002,

}
