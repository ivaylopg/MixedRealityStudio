using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrab : MonoBehaviour {

  // These two lines are required so you can have an easy-to-use
  // 'Controller' variable to use in your script.
  private SteamVR_TrackedObject trackedObj;
  private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

  private GameObject collidingObject;
  private GameObject objectInHand;


  // The 'Awake()' function is similar to 'Start()' but it gets
  // called even sooner. This ensures that the 'Controller' variable
  // is good to go.
  void Awake() {
    trackedObj = GetComponent<SteamVR_TrackedObject>();
  }

  void Update () {
    if (Controller.GetHairTriggerDown()) {
      if (collidingObject) {
        GrabObject();
      }
    }

    if (Controller.GetHairTriggerUp()) {
      if (objectInHand) {
        ReleaseObject();
      }
    }
  }

  public void OnTriggerEnter(Collider other) {
    Debug.Log("Trigger Enter");
    Controller.TriggerHapticPulse();
    SetCollidingObject(other);
  }

  public void OnTriggerStay(Collider other) {
    SetCollidingObject(other);
  }

  public void OnTriggerExit(Collider other) {
    Debug.Log("Trigger Leave");
    Controller.TriggerHapticPulse();
    if (!collidingObject) {
      return;
    }
    collidingObject = null;
  }

  private void SetCollidingObject(Collider col) {
    if (collidingObject || !col.GetComponent<Rigidbody>()) {
      return;
    }
    collidingObject = col.gameObject;
  }

  private void GrabObject() {
    Debug.Log("Grab Object");
    objectInHand = collidingObject;
    collidingObject = null;

    // These lines reposition the grabbed object to snap to the top of your controller
    objectInHand.transform.rotation = gameObject.transform.rotation;
    objectInHand.transform.position = gameObject.transform.position;
    objectInHand.transform.localPosition += ( transform.forward.normalized * .1f );
    /////////////

    var joint = AddFixedJoint();
    joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
  }

  private FixedJoint AddFixedJoint() {
    FixedJoint fx = gameObject.AddComponent<FixedJoint>();
    fx.breakForce = 20000;
    fx.breakTorque = 20000;
    return fx;
  }

  private void ReleaseObject() {
    Debug.Log("Release Object");
    if (GetComponent<FixedJoint>()) {
      GetComponent<FixedJoint>().connectedBody = null;
      Destroy(GetComponent<FixedJoint>());

      objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
      objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
    }

    objectInHand = null;
  }
}
