# Session 04 - 08/31/17

# Unity Part 2

* Last time we sort of jumped right into it. Today I want to take a step back and make sure we're all on the same page regarding some important concepts, and then build out a few important interactions.
* Sorry if this is review for some of you - always good to have a refresher.

## Basic Concepts
* class/variable/function
* public private
* built-in functions
    * `Start()`
    * `Update()`
    * `FixedUpdate()`
* Debugging/Testing
    * `Debug.Log()`
* **It's a mix of knowing a few things (not as much as you think) and knowing how things work**

## Here We Go (Again)
* GameObjects are the basic building block in unity
    * Has components
    * Can be empty
    * **Scripts belong to game objects**
* Can be enabled/disabled in scene instead of deleted

## Animations
* Before we jump right into code again, let's look at animations!
* Add a new cube
    * **Add a rigid body**
* Animation editor
    * Keyframes vs Curves
    * Create new animation to prevent it from starting right away
        * **Code as trigger!**
