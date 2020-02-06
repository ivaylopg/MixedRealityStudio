/*
 * This script creates a copy of a PREFAB and launches it forward with physics.
 *
 * This will create the object relative to whatever THIS SCRIPT is attached to.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLauncher : MonoBehaviour {

  // PUBLIC variables will show up in the inspector in unity, which mean
  // you can change their value without having to go into your code editor

  // The multiplier of the force applied to the object
  public float force = 50f;

  // A variable pointing to the Prefab. Set this by draging a prefab onto this
  // slot in the inspector. This prefab MUST HAVE a RigidBody component as part of it
  public GameObject projectile;



  // Start is called before the first frame update
  void Start() {
    // Nothing needs to happen here!
  }

  // Update is called once per frame
  void Update() {

    // Every frame, check if the user has pressed the SPACE bar
    if (Input.GetKeyDown(KeyCode.Space)) {

      // IF the condition was true, then create a new instance of the prefab and
      // store a reference to it in the variable "g"
      GameObject g = Instantiate(projectile);

      // Set the position of this new prefab to the exat position of whatever
      // object this script is attached to.
      g.transform.position = gameObject.transform.position;


      // Using the "GetComponent<>()" function, we find the RigidBody attached to "g".
      // Then we add a force along the direction of the FORWARD VECTOR of our
      // launcher (whatever this script is attached to) and  make sure this force is an IMPULSE
      // (a.k.a. a push)
      //
      // If your PREFAB does not have a RIGIDBODY attached to it, this line will make unity very sad
      g.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * force, ForceMode.Impulse);
    }

  }
}
