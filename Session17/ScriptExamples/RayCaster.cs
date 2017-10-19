using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

  public GameObject hitMarker;

  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    RaycastHit hit;
    if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit)) {
      hitMarker.SetActive(true);
      hitMarker.transform.position = hit.point;
      hitMarker.transform.up = hit.normal;
      Debug.DrawLine(gameObject.transform.position, hit.point, Color.red);
      Debug.DrawRay(hit.point, hit.normal, Color.green);
    } else {
      hitMarker.SetActive(false);
    }
  }
}
