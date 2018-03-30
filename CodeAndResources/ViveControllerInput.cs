using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInput : MonoBehaviour {

  // To work with the steam controllers we need to store references to them.
  // These two lines need to be at the top of every script you want to use
  // with the SteamVR controllers.
  private SteamVR_TrackedObject trackedObj;
  private SteamVR_Controller.Device Controller {get { return SteamVR_Controller.Input((int)trackedObj.index); }}


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
