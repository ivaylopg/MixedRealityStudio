using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTeleport : MonoBehaviour {

  // These two lines are required so you can have an easy-to-use
  // 'Controller' variable to use in your script.
  private SteamVR_TrackedObject trackedObj;
  private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

  // These public variables are where you will drop-in your prefabs
  // and SteamVR objects.
  // You will need to provide prefabs for the laser beam and the floor marker!
  public Transform cameraRigTransform;
  public Transform headTransform;
  public Vector3 teleportReticleOffset;
  public LayerMask teleportMask;
  public GameObject teleportReticlePrefab;
  public GameObject laserPrefab;

  // Private Variables:
  private GameObject laser;
  private Transform laserTransform;
  private Vector3 hitPoint;
  private bool shouldTeleport;
  private GameObject reticle;
  private Transform teleportReticleTransform;


  // The 'Awake()' function is similar to 'Start()' but it gets
  // called even sooner. This ensures that the 'Controller' variable
  // is good to go.
  void Awake() {
    trackedObj = GetComponent<SteamVR_TrackedObject>();
  }

  void Start() {
    laser = Instantiate(laserPrefab);
    laserTransform = laser.transform;
    reticle = Instantiate(teleportReticlePrefab);
    teleportReticleTransform = reticle.transform;
    laser.SetActive(false);
    reticle.SetActive(false);
  }

  void Update() {
    if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
      RaycastHit hit;
      if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, teleportMask)) {
        hitPoint = hit.point;
        ShowLaser(hit);

        reticle.SetActive(true);
        teleportReticleTransform.position = hitPoint + teleportReticleOffset;
        shouldTeleport = true;


      } else {
        shouldTeleport = false;
        laser.SetActive(false);
        reticle.SetActive(false);
      }
    } else {
      //shouldTeleport = false;
      laser.SetActive(false);
      reticle.SetActive(false);
    }

    if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) && shouldTeleport) {
      Teleport();
    }
  }

  private void ShowLaser(RaycastHit hit) {
    laser.SetActive(true);
    laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
    laserTransform.LookAt(hitPoint);
    laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
  }

  private void Teleport() {
    shouldTeleport = false;
    reticle.SetActive(false);
    Vector3 difference = cameraRigTransform.position - headTransform.position;
    difference.y = 0;
    cameraRigTransform.position = hitPoint + difference;
  }
}
