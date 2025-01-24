using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEat : MonoBehaviour
{

    private bool beingEaten = false;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collision detected with: " + col.gameObject.name);
        if (col.gameObject.tag == "LionSlime" && beingEaten == false)
        {
            StartCoroutine(BeingEaten() );
        }
    }

    IEnumerator BeingEaten()
    {
        Debug.Log("Being eaten...");

        beingEaten = true;

        // After 3 seconds the meat will be eaten and it will destroy itself
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        Debug.Log("Eaten?");
    }
}
