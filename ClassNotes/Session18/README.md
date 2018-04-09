# Session 18 - 04/02/18

## Layers & Tags
* A GameObject can have one of _each_
* Both can be used for identity
    * layers are **int** - `if (gameObject.layer == 2)`
    * vs
    * tags are **string** - `if (gameObject.layer == "someTag")`
* However, `Layers` are meant to organize things _in a way that Unity cares about_ while tags are _just for the developer_
    * Layers are understood by physics, camera, lighting, etc. and can be selectively ignored
    * Tags are a good alternative for searching for objects by name
    * [Unity Reference: Layers](https://docs.unity3d.com/Manual/Layers.html)

## Demo Arrays and Lists
* CubeScript
* ManyCubes

## Building our Arc-based Teleporter
* This is a good example of leveling up our logic skills a bit, as well as working with groups of objects we've instantiated
* Using the [trajectory of a projectile](https://en.wikipedia.org/wiki/Projectile_motion) as our logic
* We built our arc renderer in class
    * take a look at [the final script](https://github.com/ivaylopg/MixedRealityStudio/blob/master/CodeAndResources/ArcRenderer.unitypackage) in the github repo

## Homework##
* By next week, combine our [ArcMaker](https://github.com/ivaylopg/MixedRealityStudio/blob/master/CodeAndResources/ArcMaker.cs) script with our [LaserTeleport](https://github.com/ivaylopg/MixedRealityStudio/blob/master/CodeAndResources/LaserTeleport.cs) script to make an _AdvancedTeleport_ script that uses an arc instead of a straight/laser line.
