using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Add this line to the top of your script so you can
// use custom events:
using UnityEngine.Events;

public class CustomButton : MonoBehaviour {
  
  // This line will create a public UnityEvent slot in the
  // inspector. This is EXACTLY what the UI Button uses:
  public UnityEvent doThis;



  private void OnTriggerEnter(Collider other) {

    // When we call the Invoke() method of a UnityEvent, it will
    // execute all of the functions that we have added to it in
    // the inspector:
    doThis.Invoke();

    // This line changes the button to RED:
    gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
  }



  private void OnTriggerExit(Collider other) {

    // This line changes the button back to WHITE:
    gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
  }
}
