using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float threshold = 0.5f;
    private FlashFeedback flashFeedback;
    private GameObject selectedObject;

     public void HandleSelection(GameObject detectedObject)
    {
        //Vector3 mouseInput = currentCamera.ScreenToWorldPoint(Input.mousePosition); //This takes the mouse's position on the screen and converts it into a point in the game world.
        //mouseInput.z = 0f; //This sets the z-coordinate of that point to 0, effectively making sure we're working in a 2D plane.
        //Collider2D collider = Physics2D.OverlapPoint(mouseInput, layerMask); //This checks if there's any 2D object (with a Collider2D component) at the point where the mouse clicked, considering only objects on layers specified by layerMask. Here, the layermask is Agent, and the object clicked is the FarmerObject with a 2D colider set on it. 
        //selectedObject = collider == null ? null : collider.gameObject; //collider can be null or referencing the agent. if colider = null, it will be null, else get collider.getobject.

        if(detectedObject!= null)
            this.selectedObject = detectedObject;
            flashFeedback = selectedObject.GetComponent<FlashFeedback>(); //this grabs the FlashFeedback compentent from the selectedObject
            flashFeedback.PlayFeedback(); //this calls the PlayFeedback method we wrote which will make the thing flash
    }

    public void HandleMovement(Vector3 endPosition) //drag mouse and let go of button//determine if we can select object or not
    {
        if(selectedObject == null)
            return;
        
        flashFeedback.StopFeedback();

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
