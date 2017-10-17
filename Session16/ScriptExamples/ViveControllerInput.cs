using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInput : MonoBehaviour {

  // These two lines are required so you can have an easy-to-use
  // 'Controller' variable to use in your script.
  private SteamVR_TrackedObject trackedObj;
  private SteamVR_Controller.Device Controller {get { return SteamVR_Controller.Input((int)trackedObj.index); }}


  // The 'Awake()' function is similar to 'Start()' but it gets
  // called even sooner. This ensures that the 'Controller' variable
  // is good to go.
  void Awake() {
    trackedObj = GetComponent<SteamVR_TrackedObject>();
  }


  void Update () {
    if (Controller.GetAxis() != Vector2.zero) {
      Debug.Log(gameObject.name + Controller.GetAxis());
    }

    if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
      Debug.Log(gameObject.name + " Touchpad Press");
    }

    if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
      Debug.Log(gameObject.name + " Touchpad Release");
    }

    if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
      Debug.Log(gameObject.name + " Grip Press");
    }

    if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
      Debug.Log(gameObject.name + " Grip Release");
    }

    if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
      Debug.Log(gameObject.name + " Menu Press");
      Controller.TriggerHapticPulse();
    }

    if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
      Debug.Log(gameObject.name + " Menu Release");
      Controller.TriggerHapticPulse();
    }

    if (Controller.GetHairTriggerDown()) {
      Debug.Log(gameObject.name + " Trigger Press");
    }

    if (Controller.GetHairTriggerUp()) {
      Debug.Log(gameObject.name + " Trigger Release");
    }
  }
}
