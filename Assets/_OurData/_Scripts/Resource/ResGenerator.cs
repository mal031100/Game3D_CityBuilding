using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResGenerator : LoadBehaviour
{
    [SerializeField] protected List<ResHoder> resHoders;
    [SerializeField] protected List<Resource> resCreate; // item tao ra
    [SerializeField] protected List<Resource> resRequire; // item can
    [SerializeField] protected float createTimer = 0f;
    [SerializeField] protected float createDelay = 2f;

    protected override void FixedUpdate()
    {
        this.Creating();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHoders();
    }

    protected virtual void LoadHoders()
    {
        if(this.resHoders.Count > 0) return;

        Transform res = transform.Find("Res");
        foreach(Transform resTran in res)
        {
            Debug.LogWarning(resTran.name);

            ResHoder resHoder = resTran.GetComponent<ResHoder>();
            if (resHoder == null) continue;
            this.resHoders.Add(resHoder);
        }

        Debug.Log(transform.name + ": Load Hoder");
    }

    protected virtual void Creating()
    {
        this.createTimer += Time.fixedDeltaTime;
        if (this.createTimer < this.createDelay) return;
        this.createTimer = 0;

        if(!this.IsRequireEnough()) return;

        foreach(Resource res in this.resCreate)
        {
            ResHoder resHoder = this.resHoders.Find((holder) => holder.Name() == res.name); 
            resHoder.Add(res.number);
        }
    }

    protected virtual bool IsRequireEnough()
    {
        if(this.resRequire.Count < 1) return true;

        // TODO: this is not done yet
        return false;
    }
}
