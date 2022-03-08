using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildsCreator : MonoBehaviour
{
    [SerializeField] CollectorMoneyBase collectorMoney; // better use ICollectorMoney
    [SerializeField] MoneyHandler moneyHandler;

    private bool isPlacingBuild;
    private BuildData currentBuildData;
    private ITemplateBuild currentTemplate;
    
    [SerializeField] LayerMask groundMask;//i think this need to rename

    [SerializeField] float sizeCellGrid; // cannot be less or equals zero
    private MouseGridHit mouseGrid;
    private void Awake()
    {
        mouseGrid = new MouseGridHit(groundMask, sizeCellGrid);
    }
    private void Update()
    {
        if (isPlacingBuild)
        {
            currentTemplate.SetPosition(mouseGrid.GetMouseHit());
        }
    }
    //Click on buttons
    public void TryStartPlacingBuild(BuildData build_data)
    {
        if (isPlacingBuild) return;

        if (moneyHandler.CanSpend(build_data.Price))
        {
            var template_build_go = Instantiate(build_data.TemplatePref);
            currentTemplate = template_build_go.GetComponent<ITemplateBuild>();
            if (currentTemplate == null)
            {
                Debug.LogError("Not found ITemplateBuild in Template of " + build_data.Name + "!");
                return;
            }

            isPlacingBuild = true;
            currentBuildData = build_data;
        }       
    }
    //Click 0
    public void TryBuildUpCurrentBuild()
    {
        if (isPlacingBuild && currentTemplate.CanBuildHere() )
        {            
            var build_go = Instantiate(currentBuildData.BuildPref, 
                mouseGrid.GetMouseHit(),
                currentBuildData.BuildPref.transform.rotation);

            if(build_go.TryGetComponent<IBuild>(out var build))
            {
                if (moneyHandler.TrySpend(currentBuildData.Price))
                    build.BuildUp(currentBuildData, collectorMoney);
                else Destroy(build_go);
            }
            else
            {
                Destroy(build_go);
                Debug.LogError("Not found IBuild in Prefab of " + currentBuildData.Name + "!");
            }

            CancelPlacingBuild();
        } 
    }
    //Click 1
    public void CancelPlacingBuild()
    {
        if (isPlacingBuild) {
            isPlacingBuild = false;
            currentBuildData = null;
            currentTemplate.Destroy();
            currentTemplate = null;
        }
    }
   
}
