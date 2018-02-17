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

  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    if (Controller.GetHairTriggerDown()) {
      if(collidingObject) {
        Grab();
      }
    }

    if (Controller.GetHairTrigger()) {
      UpdateObjectPos();
    }

    if (Controller.GetHairTriggerUp()) {
      Release();
    }
  }


  public void OnTriggerEnter(Collider other) {
    Debug.Log("Trigger entered " + other.gameObject.name);
    collidingObject = other.gameObject;
    Controller.TriggerHapticPulse();
  }

  public void OnTriggerStay(Collider other) {
    collidingObject = other.gameObject;
  }

  public void OnTriggerExit(Collider other) {
    Debug.Log("Trigger exited " + other.gameObject.name);
    collidingObject = null;
    Controller.TriggerHapticPulse();
  }

  void Grab() {
    if (objectInHand) {
      return;
    }

    objectInHand = collidingObject;
    collidingObject = null;

    UpdateObjectPos();
  }

  void Release() {
    if (objectInHand == null) {
      return;
    }

    objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
    objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;

    objectInHand = null;
  }

  void UpdateObjectPos() {
    if (objectInHand == null) {
      return;
    }

    objectInHand.transform.rotation = gameObject.transform.rotation;
    objectInHand.transform.position = gameObject.transform.position + gameObject.transform.forward * .1f;
  }


}
