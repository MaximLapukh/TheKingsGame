using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Requaire component Rigidbody in future
public class TemplateBuildUseTrigger : MonoBehaviour, ITemplateBuild
{
    private bool canBuildHere = true;
    [Tooltip("If this build can place here")]
    [SerializeField] GameObject greenTemplate;//bad names in my opinion
    [Tooltip("If this build can't place here")]
    [SerializeField] GameObject redTemplate;
    
    public bool CanBuildHere()
    {
        return canBuildHere;        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetPosition(Vector3 vec)
    {
        //maybe use rigidbody to set position better then like that
        transform.position = vec;
    }
    private void OnTriggerStay(Collider other)
    {
        canBuildHere = false;
        SetTemplate("red");
    }   
    private void OnTriggerExit(Collider other)
    {
        canBuildHere = true;
        SetTemplate("green");
    }

    private void SetTemplate(string color)
    {
        switch (color)
        {
            case "green":
                greenTemplate.SetActive(true);
                redTemplate.SetActive(false);
                break;
            case "red":
                greenTemplate.SetActive(false);
                redTemplate.SetActive(true);
                break;
        }
      
    }
}
