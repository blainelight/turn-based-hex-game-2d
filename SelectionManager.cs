using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    FlashFeedback flashFeedback;

    public void HandleSelection(GameObject detectedCollider)
    {
        DeselectOldObject();
        if(detectedCollider == null)
            return;
        
        Unit unit = detectedCollider.GetComponent<Unit>(); //this is our script that is on agents
        if(unit != null)
        {
            if(unit.CanStillMove() == false) //if unit is done moving
                return;
        }

        flashFeedback = detectedCollider.GetComponent<FlashFeedback>(); //the FarmerUnit has a compentent FlashFeedback on it, and it users the workers_2 as the sprite renderer, and invisible time .3 and visible time .07
        flashFeedback.PlayFeedback();
    }

    private void DeselectOldObject()
    {
        if(flashFeedback == null)
            return;
        flashFeedback.StopFeedback();
        flashFeedback = null;
    }
}
