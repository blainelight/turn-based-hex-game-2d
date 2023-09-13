using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Camera currentCamera;
    public LayerMask layerMask;
    public float threshold = 0.5f;

    private GameObject selectedObject;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //left mouse button
        {
            HandleSelection();
        }

        if (Input.GetMouseButtonUp(0)) //left mouse up
        {
            HandleMovement();
        }
    }
     private void HandleSelection()
    {
        Vector3 mouseInput = currentCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseInput.z = 0f;
        Collider2D collider = Physics2D.OverlapPoint(mouseInput, layerMask);
        selectedObject = collider == null ? null : collider.gameObject; //collider can be null or referencing the agent. if colider = null, it will be null, else get collider.getobject.
    }

    private void HandleMovement() //drag mouse and let go of button//determine if we can select object or not
    {
        if(selectedObject == null)
            return;
        
        Vector3 endPosition = currentCamera.ScreenToWorldPoint(Input.mousePosition);
        endPosition.z = 0f; //for staftey of calc correct position

        if (Vector2.Distance(endPosition, selectedObject.transform.position) > threshold) //if the distance b/n these 2 potins is great than threshold which is .5, then that means it was delivered via a drag of the mouse
        {
            Vector2 direction = (endPosition - selectedObject.transform.position); // this is movement on any psotion, but want ot limit to carndial directions - udlr
            
            if (Mathf.Abs(direction.x)> Mathf.Abs(direction.y)) //if abs value of x > abs of y, this means we will move up or down, left or right depending on which is greater
            {
                float sign = Mathf.Sign(direction.x);
                direction = Vector2.right * sign;
            }
            else
            {
                float sign = Mathf.Sign(direction.y);
                direction = Vector2.up * sign;
            }
            selectedObject.transform.position += (Vector3)direction;
        }
    }
}
