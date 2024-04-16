using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class BuildLevel : LoadBehaviour
{
    [SerializeField] protected List<Transform> levels;
    [SerializeField] protected int currentLevel;

    private void OnEnable()
    {
        this.ShowBuilding();
        //InvokeRepeating("ShowNextBuild", 3, 2);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevels();
    }

    protected virtual void LoadLevels()
    {
        if (this.levels.Count > 0) return;
        Transform buildTran = transform.Find("Buildings");
        foreach(Transform child in buildTran)
        {
            this.levels.Add(child);
            child.gameObject.SetActive(false);
        }

        Debug.Log(transform.name + ": LoadBuildings");
    }

    /// <summary>
    /// Call from InvokeRepeating
    /// </summary>
    protected virtual void ShowNextBuild()
    {
        if(this.currentLevel >= this.levels.Count - 2) return;
        //if (this.currentLevel >= this.levels.Count - 1) this.currentLevel = 0;

        this.currentLevel++;
        this.ShowBuilding();
    }

    public virtual void ShowBuilding()
    {
        this.HideLastBuild();
        Transform currentBuild = this.levels[this.currentLevel];
        currentBuild.gameObject.SetActive(true);
    }

    protected virtual void HideLastBuild()
    {
        int lastBuildIndex = this.currentLevel - 1;
        if (lastBuildIndex < 0) return;

        Transform lastBuild = this.levels[lastBuildIndex];
        lastBuild.gameObject.SetActive(false);
    }
}
