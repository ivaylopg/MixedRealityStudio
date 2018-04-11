using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcMaker : MonoBehaviour {

  /**************************************************
    Make sure to download:

      ArcRenderer.unitypackage

    from the github! Otherwise you will need to
    provide your own prefabs for `indicatorPrefab`
    and `collisionPrefab`

    Get it here:
      https://github.com/ivaylopg/MixedRealityStudio/raw/master/CodeAndResources/ArcRenderer.unitypackage

   **************************************************/


  public float velocity = 10.0f;
  [Range(0.1f, 1f)] public float resolution = 0.5f;
  public float maxDistance = 50f;
  public int maxNumberOfPoints = 1000;
  public LayerMask teleportLayers = ~0;

  // public variables so we can drop-in prefabs for the indicator dots and
  // the collision indicator
  public GameObject indicatorPrefab;
  public GameObject collisionPrefab;

  private float g;                          // variable to hold our gravity constant
  private List<Vector3> arcPoints;          // List of Vector3 coords that make up our arc
  private List<GameObject> indicators;      // List of GameObjects that we use to show our arc
  private GameObject hitLocation;           // private variable to hold instance of our collision indicator

  private void Awake() {

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

	void Update () {
    RenderArc();
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
      if (Physics.Linecast(arcPoints[i], arcPoints[i+1], out hit, teleportLayers)) {

        // If we have hit something, move the hitLocation indicator to that point:
        hitLocation.transform.position = hit.point;

        // Also, let's align the indicator to the direction of the hit surface:
        hitLocation.transform.up = hit.normal;

        // Make the indicator active so we can see it:
        hitLocation.SetActive(true);

        // And finally break out of our function because we don't want to keep
        // drawing dots AFTER we have collided with something:
        return;

      } else {

        // If we HAVE NOT hit anything, then grab the next indicator object instance
        // in our pool, move it to the next coordinate in our List, and make it active:
        indicators[i].transform.position = arcPoints[i];
        indicators[i].SetActive(true);
      }
    }
  }
}
