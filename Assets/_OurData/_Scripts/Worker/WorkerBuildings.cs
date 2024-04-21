using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerBuildings : LoadBehaviour
{
    [SerializeField] protected BuildingCtrl workBuilding;
    [SerializeField] protected BuildingCtrl homeBuilding;
    [SerializeField] protected List<BuildingCtrl> innBuilding;
    [SerializeField] protected List<BuildingCtrl> relaxBuilding;

    public virtual void AssignWork(BuildingCtrl buildingCtrl)
    {
        this.workBuilding = buildingCtrl;
    }

    public virtual BuildingCtrl GetWork()
    {
        return this.workBuilding;
    }
}
