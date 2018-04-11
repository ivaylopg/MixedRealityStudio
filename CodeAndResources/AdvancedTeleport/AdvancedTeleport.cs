using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedTeleport : MonoBehaviour {

  // To work with the steam controllers we need to store references to them.
  // These two lines need to be at the top of every script you want to use
  // with the SteamVR controllers.
  private SteamVR_TrackedObject trackedObj;
  private SteamVR_Controller.Device Controller {
    get {
      return SteamVR_Controller.Input((int) trackedObj.index);
    }
  }

  // Arc logic:
  public float velocity = 10.0f;                     // The speed of our imaginary projectile
  [Range(0.1f, 1f)] public float resolution = 0.5f;  // The resolution step size of our indicators along our arc
  public float maxDistance = 50f;                    // The maximum (linear) distance that we can teleport to
  public int maxNumberOfPoints = 1000;               // The maximum number of indicators along our arc
  private float g;                                   // variable to hold our gravity constant
  private List<Vector3> arcPoints;                   // List of Vector3 coords that make up our arc
  private List<GameObject> indicators;               // List of GameObjects that we use to show our arc
  private GameObject hitLocation;                    // private variable to hold instance of our collision indicator

  // Teleportation logic:
  private Vector3 destination;                       // Variable to store the point we will teleport to
  private bool shouldTeleport;                       // A boolean variable to store the state of whether or not
                                                     // we should teleport (i.e. that our destination is valid)
  public LayerMask teleportLayers = ~0;              // Layermask of valid teleport locations
                                                     // (extra credit if you can tell me what the default value of ~0 means!)


  // Public variables for transforms:
  public Transform headTransform;                    // Reference to where the user's head is
  public Transform cameraRigTransform;               // Reference to the center of the SteamVR area so
                                                     // we can compute an offset

  // Public variables so we can drop-in prefabs for 
  // the indicator dots and the collision indicator:
  public GameObject indicatorPrefab;
  public GameObject collisionPrefab;


  void Awake() {
    // Sets the our trackedObj variable as a reference to the controller:
    trackedObj = GetComponent<SteamVR_TrackedObject>();

    // These two lines create new empty lists and assign them to 
    // the appropriate variables
    arcPoints = new List<Vector3>();
    indicators = new List<GameObject>();

    // We get our gravity constant from Unity's physics engine, 
    // but we have to make sure it's a POSITIVE number, so we 
    // use Mathf.Abs()
    g = Mathf.Abs(Physics.gravity.y);

    // Create an instance of the collision indicator prefab
    // nested under this gameObject, and make it invisible:
    hitLocation = Instantiate(collisionPrefab, transform);
    hitLocation.SetActive(false);
  }


  void Update() {
    if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
    //if (Input.GetMouseButton(0)) {

      float speedSelect = (Controller.GetAxis().y + 1f) / 2f;
      velocity = 5f + (speedSelect * 10f);

      RenderArc();
    } else {
      HideArcPoints();
    }

    if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) && shouldTeleport) {
    //if (Input.GetMouseButtonUp(0) && shouldTeleport) {
      Teleport(destination);
    }
  }

  private void Teleport(Vector3 destination) {
    // Before we teleport, set shouldTeleport back to false:
    shouldTeleport = false;

    // Hide our rendered arc and destination indicator:
    HideArcPoints();
    hitLocation.SetActive(false);

    // Compute the offset between the SteamVR camera rig and the 
    // player's actual position:
    Vector3 difference = cameraRigTransform.position - headTransform.position;
    difference.y = 0;

    // Move the camerarig to our teleport destination + the offset:
    cameraRigTransform.position = destination + difference;
  }



  void RenderArc() {

    // Hide the indicators from last frame:
    HideArcPoints();

    // Calculate an updated trajectory arc:
    CalculateArcPoints();

    // Make sure we have enough instances of our indicator prefab:
    CreateArcPoints();

    // Draw our indicators in the scene:
    DrawArcPoints();
  }

  void HideArcPoints() {
    // Loop through each instance of our indicator and make it invisible:
    foreach (GameObject point in indicators) {
      point.SetActive(false);
    }
  }

  void CalculateArcPoints() {
    // Clear whatever is in the arcPoints list so we can start from 
    // scratch (since we've probably moved since last frame)
    arcPoints.Clear();

    // Keep taking steps of increments equal to our `resolution` value
    // until we hit max distance:
    for (float i = 0f; i < maxDistance; i += resolution) {
      // if we have reached our maxNumberOfPoints before we reach the 
      // maxDistance, then stop looping:
      if (arcPoints.Count > maxNumberOfPoints) {
        // "return" breaks out of the whole function:
        return;
      }

      // Calculate the position of a point at distance `i` and add
      // it to our List:
      Vector3 arcPoint = CalculatePoint(i);
      arcPoints.Add(arcPoint);
    }
  }

  // This function returns a Vector3 and takes a float as input:
  Vector3 CalculatePoint(float horizPosition) {

    // We need to figure out which way we're facing along the XZ plane
    // (aka perpendicular to gravity). We can take our forward transform
    // and zero-out its Y component:
    Vector3 direction = transform.forward;
    direction.y = 0f;

    // Normalizing this vector sets the magnitutde to 1.0. This let's us
    // scale it later:
    direction.Normalize();

    // To get the angle in degrees, we use Vector3.Angle to find the angle between
    // our forward vector and our diretion vector.
    float degreeAngle = Vector3.Angle(direction, transform.forward);

    // To get the angle in radians, we multiply our degreeAngle by the Mathf.Deg2Rad constant.
    float radianAngle = Mathf.Deg2Rad * degreeAngle;

    // Because Vector3.Angle will always return a positive number in this case, we want
    // to account for pointing down by checking our forward vector again:
    if (transform.forward.y < 0f) {
      radianAngle *= -1f;
    }

    // Vertical displacement equation given horizontal position
    // Equation from: https://en.wikipedia.org/wiki/Projectile_motion
    float vertPosition = horizPosition * Mathf.Tan(radianAngle) - ((g * horizPosition * horizPosition) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));

    // This equation gives us the shape of our arc in an x/y graph.
    // Now we have to use this to come up with a point RELATIVE TO OUR POSITION AND ROTATION

    // The direction vector is already pointing in the correct orientation, so we can 
    // just scale it by the horizontal position (horizPosition) we are cusing for this 
    // pass through the function:
    direction *= horizPosition;

    // And the height is just going to be the y-component of that vector:
    direction.y = vertPosition;

    // Now we displace the whole thing by our position and return the Vector3:
    return transform.position + direction;
  }


  void CreateArcPoints() {

    // If we have fewer indicators than points to draw...
    if (indicators.Count < arcPoints.Count) {

      // ... clear our indicator objects...
      indicators.Clear();

      // ...and repopulate our List with the correct amount.
      foreach (var pt in arcPoints) {
        GameObject point = Instantiate(indicatorPrefab, transform);
        point.SetActive(false);
        indicators.Add(point);
      }
    }

    // Note: This is definitely innefecient, just here for the sake of
    // logical clarity. Extra credit if you want to create a more 
    // efficient object pool.
  }

  void DrawArcPoints() {

    // We want to loop through our arcPoints, but we need to keep track of
    // the order they're in, so we use `for` instead of `forearch`. We set
    // `arcPoints.Count - 1` as the upper bound of our loop so we can look at
    // `i+1` in each loop without going out of bounds.
    for (int i = 0; i < arcPoints.Count - 1; i++) {

      // We are going to draw indicators along our arc until we collide with
      // something. We use a RaycastHit variable to hold collision info:

      RaycastHit hit;

      // The syntax of Physics.Linecast is almost identical to Physics.Raycast.
      // In this case, instead of looking at a Ray, we are drawing a line between
      // two points and checking if something is in that space.
      if (Physics.Linecast(arcPoints[i], arcPoints[i + 1], out hit, teleportLayers)) {

        // If we have hit something, move the hitLocation indicator to that point:
        hitLocation.transform.position = hit.point;

        // Also, let's align the indicator to the direction of the hit surface:
        hitLocation.transform.up = hit.normal;

        // Make the indicator active so we can see it:
        hitLocation.SetActive(true);

        // Set our teleport logic:
        shouldTeleport = true;
        destination = hit.point;

        // And finally break out of our function because we don't want to keep
        // drawing dots AFTER we have collided with something:
        return;

      } else {

        // If we HAVE NOT hit anything, then grab the next indicator object instance
        // in our pool, move it to the next coordinate in our List, and make it active:
        indicators[i].transform.position = arcPoints[i];
        indicators[i].SetActive(true);

        // Set our teleport logic:
        shouldTeleport = false;
      }
    }
  }
}