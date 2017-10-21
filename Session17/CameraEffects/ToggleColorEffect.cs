
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure to tell Unity that you will be using code
// defined in PostProcessing add-on by adding this line
// before your class definition:
using UnityEngine.PostProcessing;

public class ToggleColorEffect : MonoBehaviour {

  // This is just for the sake of example, to let us
  // toggle the effect on and off inside the Unity editor:
  public bool enableEffect = false;

  private PostProcessingProfile fxProfile;

  void Start() {

    // Find the 'prfile' element of the PostProcessingBehavior component
    // and assign it to the fxProfile variable
    fxProfile = GetComponent<PostProcessingBehaviour>().profile;
  }

  void Update() {
    if (enableEffect) {

      // This line allows you to enable the specific component that you
      // want, in this case 'color grading'
      fxProfile.colorGrading.enabled = true;

      // Remember that the dots represent that you are accessing something
      // that is a **inside** of the thing before the period. In this case
      // you are setting the variable 'enabled' of the component 'colorGrading'
      // inside of the 'fxProfile.'
    } else {
      fxProfile.colorGrading.enabled = false;
    }

  }
}


