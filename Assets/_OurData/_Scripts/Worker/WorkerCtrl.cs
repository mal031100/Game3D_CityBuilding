using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerCtrl : LoadBehaviour
{
    public WorkerBuildings workerBuildings;
    public WorkerMovement workerMovement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWorkerBuilding();
        this.LoadWorkerMovement();
    }

    protected virtual void LoadWorkerBuilding()
    {
        if (workerBuildings != null) return;
        this.workerBuildings = GetComponent<WorkerBuildings>();

        Debug.Log(transform.name + "; LoadWorkerBuilding", gameObject);
    }

    protected virtual void LoadWorkerMovement()
    {
        if (workerMovement != null) return;
        this.workerMovement = GetComponent<WorkerMovement>();

        Debug.Log(transform.name + "; LoadWorkerMovement", gameObject);
    }
}
