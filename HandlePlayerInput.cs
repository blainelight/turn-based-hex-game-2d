using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandlePlayerInput : MonoBehaviour
{
    public Camera currentCamera;
    public LayerMask layerMask;
    public UnityEvent<GameObject> OnHandleMouseClick; // takes in or runs? both the CharacterMovement.HandleSelection and the SelectionManager.HandleSection from the PlayerInput game object in the unity player.
        public UnityEvent<Vector3> HandleMouseFinishDragging;


 // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //left mouse button
        {
            HandleMouseClick();
        }

        if (Input.GetMouseButtonUp(0)) //left mouse up
        {
            HandleMouseUp();
        }
    }

    private void HandleMouseUp()
    {
        Vector3 mouseInput = GetMousePosition();
        HandleMouseFinishDragging?.Invoke(mouseInput);
    }    

    private void HandleMouseClick()
    {
        Vector3 mouseInput = GetMousePosition();
        Collider2D collider = Physics2D.OverlapPoint(mouseInput, layerMask); //This checks if there's any 2D object (with a Collider2D component) at the point where the mouse clicked, considering only objects on layers specified by layerMask. Here, the layermask is Agent, and the object clicked is the FarmerObject with a 2D colider set on it. 
        GameObject selectedObject = collider == null ? null : collider.gameObject; //collider can be null or referencing the agent. if colider = null, it will be null, else get collider.getobject - so if we click on nothing, it's null, and if we click on the FarmerUnit, the selectedObject becomes the FarmerUnit GameObject.
        OnHandleMouseClick?.Invoke(selectedObject); //listen to event and pass eitehr game object selected or null value; here it runs both the CharacterMovement.Handle Selection and the SelectionManager.HandleSelection, most likely in that order.
    }

    private Vector3 GetMousePosition()
    {
    Vector3 mouseInput = currentCamera.ScreenToWorldPoint(Input.mousePosition); //This takes the mouse's position on the screen and converts it into a point in the game world.
    mouseInput.z = 0f; //This sets the z-coordinate of that point to 0, effectively making sure we're working in a 2D plane.
    return mouseInput;
    }
}


