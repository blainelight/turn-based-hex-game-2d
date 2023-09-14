using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
   [SerializeField]
   private int maxMovementPoints = 20;
   private int currentMovementPoints;
   public UnityEvent FinishedMoving;

    // Start is called before the first frame update
    void Start()
    {
        currentMovementPoints = maxMovementPoints; // at the start of our game, each unit can move max range
    }
   
   public bool CanStillMove() //for any other scripts, if this is >0 then can move else not.
   {
    return currentMovementPoints > 0;
   }

   public void HandleMovement(Vector3 cardinalDirection, int movementCost)
   {
        if(currentMovementPoints - movementCost < 0)
        {
            Debug.LogError($"Not enough movement points {currentMovementPoints} to move {movementCost}.");
            return;
        }
        currentMovementPoints -= movementCost;

        if(currentMovementPoints <= 0)
            FinishedMoving?.Invoke();

        transform.position += cardinalDirection;
   }
}
