using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Make sure to tell Unity that you will be using code
// defined in Holotoolkit by adding this line before your
// class definition.
using HoloToolkit.Unity.SpatialMapping;

public class ChangeSpatialMapMaterial : MonoBehaviour {

  // Sometimes you might want to start by seeing the SpatialMapping
  // wireframe (maybe to make sure you have a good scan of the room)
  // and then you want to get rid of it.
  //
  // This script shows how to change the SpatialMapping material
  // while you program is running.

  // A public variable to hold the material that you will use. Most
  // of the time you probably want to use the Occlusion material here.
  public Material replaceMaterial;

	void Start () {
	}

	void Update () {
	}


  // Call this function when you want to change the material:
  public void ClearMesh() {
    SpatialMappingManager.Instance.SetSurfaceMaterial(replaceMaterial);
  }
}
