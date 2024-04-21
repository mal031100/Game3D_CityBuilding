using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : LoadBehaviour
{
    public static BuildManager instance;
    [SerializeField] protected List<BuildingCtrl> buildingCtrls;

    protected override void Awake()
    {
        base.Awake();
        if (BuildManager.instance != null) Debug.LogError("Only 1 BuildingManager ");
        BuildManager.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBuildingCtrls();
    }

    protected virtual void LoadBuildingCtrls()
    {
        if (this.buildingCtrls.Count > 0) return;
        foreach(Transform child in transform)
        {
            BuildingCtrl ctrl = child.GetComponent<BuildingCtrl>();
            if(ctrl == null) continue;
            this.buildingCtrls.Add(ctrl);
        }

        Debug.Log(transform.name + "BuildManager", gameObject);
    }

    public virtual BuildingCtrl FindBuilding(Transform worker)
    {
        BuildingCtrl buildingCtrl;
        for(int i = 0; i < this.buildingCtrls.Count; i++)
        {
            buildingCtrl = this.buildingCtrls[i];
            if (!buildingCtrl.workers.IsNeedWorker()) continue;

            buildingCtrl.workers.AddWorker(worker);
            return buildingCtrl;
        }
        return null;

        //Debug.Log("FindBulding");
    }
}
