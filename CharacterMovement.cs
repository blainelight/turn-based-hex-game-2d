using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float threshold = 0.5f;
    private GameObject selectedObject;

     public void HandleSelection(GameObject detectedObject)
    {
        this.selectedObject = detectedObject;
    }

    public void HandleMovement(Vector3 endPosition) //drag mouse and let go of button//determine if we can select object or not
    {
        if(selectedObject == null)
            return;

        if (Vector2.Distance(endPosition, selectedObject.transform.position) > threshold) //if the distance b/n these 2 potins is great than threshold which is .5, then that means it was delivered via a drag of the mouse
        {
            Vector2 direction = (endPosition - selectedObject.transform.position); // this is movement on any psotion, but want ot limit to carndial directions - udlr
            
            if (Mathf.Abs(direction.x)> Mathf.Abs(direction.y)) //if abs value of x > abs of y, this means we will move up or down, left or right depending on which is greater
            {
                float sign = Mathf.Sign(direction.x); // turns the direction that the mouse was released into -1, 0, or +1
                direction = Vector2.right * sign;
            }
            else
            {
                float sign = Mathf.Sign(direction.y);
                direction = Vector2.up * sign;
            }
            selectedObject.transform.position += (Vector3)direction; //casts director as a Vector3 to make it compatible with the transform and I think unity is 3D by default so maybe gameobjets have to be 3D. 
        }
    }
}
