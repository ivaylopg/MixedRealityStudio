/*
 * This is a simple script that demonstrates how a GameObject's position can
 * be modified from your code.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdater : MonoBehaviour {


  void Start() {

  }

  // Update is called once per frame
  void Update() {

    // Create a Vector3 variable and store the position of
    // whatever object this script is attached to.
    Vector3 currentPosition = gameObject.transform.position;

    // Modify the X and Z component of this stored Vector
    // Here we are using Mathf, which is Unity's math library, and Time which is
    // Unity's timekeeping library. Look these up in the online reference if you
    // would like to know some other features built into these libraries.
    currentPosition.x = Mathf.Sin(Time.time);
    currentPosition.z = Mathf.Sin(Time.time);

    // Set the object's current position to this new modified Vector.
    gameObject.transform.position = currentPosition;
  }
}
