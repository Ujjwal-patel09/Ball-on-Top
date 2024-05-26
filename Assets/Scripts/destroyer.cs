using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class destroyer : MonoBehaviour
{
    public Canvas canvas;

    private void Awake() {
        canvas.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {

        //For destroying the ground//
        if(other.gameObject.CompareTag("Ground")){
            Destroy(other.gameObject);
        }
        
        //for disable canvas//
        if(other.gameObject.CompareTag("the_end")){
            canvas.enabled = true;
        }
    }
    
}
