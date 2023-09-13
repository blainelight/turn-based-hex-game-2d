using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    FlashFeedback flashFeedback;

    public void HandleSelection(GameObject detectedCollider)
    {
        DeselectOldObject();
        if(detectedCollider = null)
            return;
        
        flashFeedback = detectedCollider.GetComponent<FlashFeedback>();
        flashFeedback.PlayFeedback();
    }

    private void DeselectOldObject()
    {
        if(flashFeedback = null)
            return;
        flashFeedback.StopFeedback();
        flashFeedback = null;
    }
}
