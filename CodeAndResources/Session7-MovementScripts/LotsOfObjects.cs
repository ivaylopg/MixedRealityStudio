/*
 * This script instatiates (creates) a large number of primitive spheres into
 * your scene, and then updates their position every frame by looping over
 * the created objects and adding a random transformation
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LotsOfObjects : MonoBehaviour {


  // PUBLIC variables will show up in the inspector in unity, which mean
  // you can change their value without having to go into your code editor

  // The number of objects that will be created on the first frame
  public int numberOfObjects = 100;

  // The range of the objects' random positions on creation
  public int range = 50;

  // The range of the random wiggle that will be applied every frame
  public float xWiggle = .2f;
  public float yWiggle = .2f;

  ///////////////////////////////////

  // PRIVATE variables are NOT accessible outside of this script, and
  // therefore will NOT be visible in the Unity inspector

  // A dynamic list to store variables of all of the created objects
  List<GameObject> spheres = new List<GameObject>();

  ///////////////////////////////////


  // Start is called before the first frame update
  void Start() {

    // a FOR LOOP will do something multiple times. In this case,
    // it will repeat 'numberOfObjects' times
    for (int i = 0; i < numberOfObjects; i++) {

      // Create a new primitive object and store it to the LOCAL variable called "g"
      GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);

      // Create a new Vector3 variable and set it to a random position in X, Y, and Z
      // "Random.Range(A,B)" is a function that will give you a random float
      // in the range between A and B
      Vector3 newPosition = new Vector3( Random.Range(-range, range),
                            Random.Range(0,range),
                            Random.Range(-range, range));

      // Set the position of the GameObject that is stored in the "g" variable
      // to the value of the "newPosition" vector
      g.transform.position = newPosition;

      // Add "g" to our List
      spheres.Add(g);
    }
  }

  // Update is called once per frame
  void Update() {

    // Instead of a FOR loop, here we can use a FOREACH loop.
    // The difference is that instead of counting up to a NUMBER, we can now look
    // at a collection (i.e. a LIST) and do something for every member.

    // Each time we go through the loop, we are acting on a new member of the List,
    // which is temporarirly stored in a new variable called "g". THIS IS NOT THE SAME
    // VARIABLE as the Start() function

    foreach(GameObject g in spheres) {
      // Store the current position of this object into a Vector3 variable called "currentPos"
      Vector3 currentPos = g.transform.position;

      // Modify the X and Z components of this Vector with another application of Random.Range
      currentPos.x += Random.Range(-xWiggle, xWiggle);
      currentPos.z += Random.Range(-yWiggle, yWiggle);

      // Set the position of "g" to the NEW value of "currentPos"
      g.transform.position = currentPos;
    }
  }
}
