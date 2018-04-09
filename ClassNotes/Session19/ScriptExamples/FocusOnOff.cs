using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is an example script to trigger functions
// when your HoloLens cursor moves onto or off of
// a GameObject in your scene.
//
// It is an example of how to listen for events 
// defined by HoloToolkit inside our own scripts.

// Make sure to tell Unity that you will be using code
// defined in Holotoolkit by adding this line before your
// class definition.
using HoloToolkit.Unity.InputModule;


// In this example, we will be listening for events defined in the
// IFocusable class, so we add that after 'MonoBehavior'

public class FocusOnOff : MonoBehaviour, IFocusable {

  void Start() {
	  // This gets called once when the script loads
  }

  void Update() {
	  // This gets called 60x per second
  }


  // To listen for events, we MUST have a version in our script
  // of all of the functions that go with that event. If you 
  // look in: Assets/HoloToolkit/Input/Scripts/InputEvents/IFocusable.cs
  // you will see two functions defined as the interface: OnFocusEnter() and OnFocusExit().
  // We MUST create public versions of these functions in our script 
  // to listen for this event.

  public void OnFocusEnter() {
    // This gets called when the HoloLens gaze cursor moves onto the
    // GameObject that this script is attached to.
    Debug.Log("Cursor On!");
  }

  public void OnFocusExit() {
    // This gets called when the HoloLens gaze cursor moves off of the
    // GameObject that this script is attached to.
    Debug.Log("Cursor Off!");
  }
}
