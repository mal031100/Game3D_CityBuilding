using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class ResGenerator : WareHouse
{
    [SerializeField] protected List<Resource> resCreate; // item tao ra
    [SerializeField] protected List<Resource> resRequire; // item can
    [SerializeField] protected float createTimer = 0f;
    [SerializeField] protected float createDelay = 2f;

    protected override void FixedUpdate()
    {
        this.Creating();
    }

    protected virtual void Creating()
    {
        this.createTimer += Time.fixedDeltaTime;
        if (this.createTimer < this.createDelay) return;
        this.createTimer = 0;

        if(!this.IsRequireEnough()) return;

        foreach(Resource res in this.resCreate)
        {
            ResHoder resHoder = this.GetHoder(res.name);
            resHoder.Add(res.number);
        }
    }

    protected virtual bool IsRequireEnough()
    {
        if(this.resRequire.Count < 1) return true;

        // TODO: this is not done yet
        return false;
    }

    public virtual float GetCreateDelay()
    {
        return this.createDelay;
    }
}
