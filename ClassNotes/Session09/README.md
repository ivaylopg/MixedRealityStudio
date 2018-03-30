# Session 09 - 02/14/18

## Finish Individual VR Exercises
* Recap controller velocity problem
* Rigid-bodies attached to controllers don't have velocity data updated.
* We can compute this by storing the position from last frame and doing the math ourselves
    * `Velocity = Distance ÷ Time`

```csharp
Vector3 vel = (controller.pos - lastPos) / Time.deltaTime;
lastPos = controller.pos;
```

* However it turns out that SteamVR is doing this for us already:

```csharp
// These lines at the top of our script create a reference to the Controller...
SteamVR_TrackedObject trackedObj; 
SteamVR_Controller.Device Controller = SteamVR_Controller.Input((int)trackedObj.index);

//...which has velocity data computed by SteamVR
Vector3 vel = Controller.velocity;
```

## Colliders and Triggers
* The second element required for Unity's physics engine that we haven't talked about much is the `Collider`
* Colliders describe the shape and boundaries _that will be used for physics_
    * **This can be different than the actual shape and boundaries of a GameObject**
* For two objects to interact in Unity's physics engine:
    * Both objects need a `Collider` component (there are several tyes: `Box`, `Sphere`, `Capsule`, etc.)
* _At least_ one object needs a `RigidBody` component
    * Why have RB on both? Because only objects with RigidBodies can _exert_ force. 
* We can listen for collisions using the MonoBehaviour methods
    * `void OnCollisionEnter(Collision collision)`
    * `void OnCollisionStay(Collision collision)`
    * `void OnCollisionExit(Collision collision)`
* BOTH objects involved receive the event that triggers this function
    * It is actually quite hard to say which object is "responsible" for the action and which is merely "receiving" the action, so both objects get the event and it is up to you to decide how to use it.
* `Collider.isTrigger`
    * If the `isTrigger` property is enabled on a collider, it is no longer **solid**
    * Objects with trigger colliders can pass through other objects, and vice versa.
* We can listen for triggers with similar methods as regular colliders 
    * **Note the different input parameters** `Collider` vs `Collision`
        * Use auto complete in Visual Studio or Unity documentation to examine the differences
    * `void OnTriggerEnter(Collider other)`
    * `void OnTriggerStay(Collider other)`
    * `void OnTriggerExit(Collider other)`

## Create "Grab" script
* See attached script `ControllerGrab.cs`
* Pseudocode for controller grab
    * Add `Collider` component to Steam controllers (Should it have `isTrigger`?)
    * OnTriggerEnter and OnTriggerStay
        * store that object in a `collidingObject` var
    * OnTriggerExit
        * clear that object
    * listen for button press
        * Press = grab()
        * Hold = updatePosition();
        * Release = letGo()
    * Grab()
        * Check if we have a collidingObject.
            * NO? - Don't do anything else.
            * YES? - Store that object in an `objectInHand` variable and clear (set to `null` the `collidingObject` variable)
        * updatePosition()
    * updatePosition()
        * If we have `objectInHand`, set `objectInHand` position to controller position
            * Add offsets to move held object position to front of hand
    * letGo()
        * Set velocity of object to velocity of controller
        * set `objectInHand` = null
