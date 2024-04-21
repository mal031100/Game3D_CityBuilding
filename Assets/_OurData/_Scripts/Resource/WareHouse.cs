using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareHouse : LoadBehaviour
{
    [SerializeField] protected List<ResHoder> resHoders;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHoders();
    }

    protected virtual void LoadHoders()
    {
        if (this.resHoders.Count > 0) return;

        Transform res = transform.Find("Res");
        foreach (Transform resTran in res)
        {
            Debug.LogWarning(resTran.name);

            ResHoder resHoder = resTran.GetComponent<ResHoder>();
            if (resHoder == null) continue;
            this.resHoders.Add(resHoder);
        }

        Debug.Log(transform.name + ": Load Hoder");
    }

    protected virtual ResHoder GetHoder(ResourceName name)
    {
        return this.resHoders.Find((holder) => holder.Name() == name);
    }
}
