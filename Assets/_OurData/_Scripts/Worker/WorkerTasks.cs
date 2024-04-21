using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerTasks : LoadBehaviour
{
    public WorkerCtrl workerCtrl;
    [SerializeField] protected bool gotWork = false;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        this.WorkFinding();
        this.GoToWork();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadWorkerCtrl();
    }

    protected virtual void LoadWorkerCtrl()
    {
        if (this.workerCtrl != null) return;
        this.workerCtrl = GetComponent<WorkerCtrl>();

        Debug.Log(transform.name + ": loadWorketctrl", gameObject);
    }

    protected virtual void WorkFinding()
    {
        if (this.workerCtrl.workerBuildings.GetWork() != null) return;

        BuildingCtrl buldingCtrl = BuildManager.instance.FindBuilding(transform);
        if (buldingCtrl == null) return;
        this.workerCtrl.workerBuildings.AssignWork(buldingCtrl);
    }

    protected virtual void GoToWork()
    {
        if (this.gotWork == false) return;

        BuildingCtrl  workBuilding = this.workerCtrl.workerBuildings.GetWork();
        if (workBuilding == null) return;
        this.workerCtrl.workerMovement.SetTarget(workBuilding.door);

        Debug.Log(workBuilding.door);
    }
}
