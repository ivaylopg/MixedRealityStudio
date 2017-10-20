using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is an example script to trigger a function
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
// IInputClickHandler class, so we add that after 'MonoBehavior'

public class GlobalTap : MonoBehaviour, IInputClickHandler {

  void Start() {
    // This line registers the GameObject as the listener
    // for all taps not bound to another object
    InputManager.Instance.PushFallbackInputHandler(gameObject);
  }

  void Update() {
    // This gets called 60x per second
  }

  // To listen for events, we MUST have a version in our script
  // of all of the functions that go with that event. If you
  // look in: Assets/HoloToolkit/Input/Scripts/InputEvents/IInputClickHandler.cs
  // you will see one function defined as the interface: OnInputClicked(InputClickedEventData eventData).
  // We MUST create a public version of this function in our script
  // to listen for this event.

  public void OnInputClicked(InputClickedEventData eventData) {
    // This gets called if the user performs an air-tap while the
    // gaze cursor is over the GameObject that this script is attached to.
    Debug.Log("I was tapped globally!");
  }
}
