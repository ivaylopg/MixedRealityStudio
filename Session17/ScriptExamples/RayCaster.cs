using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

  // Public variable to store a GameObject to show
  // the point where the Raycast hit. I would suggest
  // something like a Circle or an X.
  // MAKE SURE THIS OBJECT DOES NOT HAVE A COLLIDER!
  public GameObject hitMarker;

  void Start() {

  }

  void Update() {

    // Physics.Raycast() just returns true or false to
    // answer “did this Ray hit anything?”
    //
    // To store information about what was hit, we need
    // to create a variable of type RaycastHit
    RaycastHit hit;

    // Since Physics.Raycast() just returns 'true' or 'false',
    // we can wrap the whole thing in an if-statement:
    if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit)) {

      // Do this stuff if the Raycast hit something:

      // Show our hitMarker gameObject
      hitMarker.SetActive(true);

      // Move hitMarker to the point in space that was hit:
      hitMarker.transform.position = hit.point;

      // Orient hitMarker to lie perpendicular to the hit surface
      hitMarker.transform.up = hit.normal;

      // These visual Debug functions help you see what’s going on.
      // They will draw lines in your Editor, but never in the actual Game view:
      Debug.DrawLine(gameObject.transform.position, hit.point, Color.red);
      Debug.DrawRay(hit.point, hit.normal, Color.green);
    } else {

      // Do this stuff if the Raycast didn't hit anything this frame:

      // Hide our hitMarker gameObject
      hitMarker.SetActive(false);
    }
  }
}
