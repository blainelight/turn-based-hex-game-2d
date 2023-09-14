using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashFeedback : MonoBehaviour
{

    public SpriteRenderer spriteRenderer; //to set the sprite to be either visible or invisible, to make it flash
    [SerializeField] //this pertains to the thing below
    private float invisibleTime, visibleTime; //times controlling anamation feedback

    public void PlayFeedback()
    {
        if(spriteRenderer == null)
            return;
        StopFeedback();
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine() //IEnumerators are for storting things that must go in a sequential order - great for animations.
    {
        Color spriteColor = spriteRenderer.color; //usually white
        spriteColor.a = 0; //alpha, transparency - 0 means invisible
        spriteRenderer.color = spriteColor; // again, set the sprite renderer to the color - we do this again because color is a value type - we cannot modify it on our sprite rendered; we need to assign a new one, but with the alpha = 0 this time. 
        yield return new WaitForSeconds(invisibleTime); // yield is a keyword used in the context of iterators, specifically w/in methods that are related to IEnumerable/tor. In Unity, yield return null is commonly used in coroutines to pause the execution of the coroutine until the next frame. This allows you to perform actions over time, spread out over several frames, without freezing the game.The new keyword is used to create a new instance of a class or a struct. In this case, new WaitForSeconds(invisibleTime) creates a new instance of the WaitForSeconds class, initialized with the value of invisibleTime.
        
        spriteColor.a = 1; //alpha, transparency - 1 means normal visible
        spriteRenderer.color = spriteColor; // again, set the sprite renderer to the color - we do this again because color is a value type - we cannot modify it on our sprite rendered; we need to assign a new one, but with the alpha = 0 this time. 
        yield return new WaitForSeconds(visibleTime);

        StartCoroutine(FlashCoroutine());
    }

    public void StopFeedback()
    {
        StopAllCoroutines(); //A Couroutine is a process that hands back control to the unity engine then comes back -- useful for animations
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 1; 
        spriteRenderer.color = spriteColor; 
    }

}
