

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimationSpeed : MonoBehaviour {

  // The square [brackets] mean that you are declaring
  // this variable as an **Array** of values (an array is like
  // a type of list in programming). This means that this one variable
  // can hold multiple Animator objects
  private Animator[] animators;

  void Start() {

    // This looks for all the Animators in your scene and
    // adds them to your array variable.
    animators = FindObjectsOfType<Animator>();
  }

  void Update() {

    // This is just for an example of a number that will
    // change over time. This will smoothly alternate between 0 and 2:
    float speedValue = Mathf.Sin(Time.time) + 1.0f;

    // This line goes through **each** item in your array, assigns
    // that single item to the variable 'a' so you can do stuff with it,
    // and then repeats for the next item until it runs out:
    foreach (Animator a in animators) {

      // You can change the speed of you animation by changing the
      // value of animator.speed:
      a.speed = speedValue;
    }

  }

}


