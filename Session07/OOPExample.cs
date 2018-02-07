using UnityEngine;

// Object Oriented Programming Example


// Vehicle is our "Base" class, where we define everything that
// the individual types would have in common
public class Vehicle {
  public int numberOfWheels = 4;
  public float weight = 1.0f;

  public void Beep() {
    Debug.Log("Beep!");
  }
}

// Now we can create SUBLCASSES that inherit characteristics from this 
// base class. Use the ":" symbol in class declarations to indicate 
// that one class is deriving from another.

public class Car : Vehicle {
  // You don't HAVE to add or change anything.
  // Sometimes it's useful to juat have a different name for something
}

public class Truck : Vehicle {
  // Every class has a special function inside of it with
  // the same name as the class. This is called the CONSTRUCTOR.
  //
  // You can leave it out of your definition if you're not using
  // it. Anything that you do in the constructor happens as soon
  // as an instance of the class is created.
  Truck() {
    numberOfWheels = 6;
    weight = 3.5f;
  }
}

public class Bus : Vehicle {
  // You can add new variables that don't exist in the parent class
  public bool isStopSignDeployed = false;

  Bus() {
    numberOfWheels = 8;
    weight = 2.0f;
  }
   
  // You can add new functions that don't exist in the parent class
  public void DeployStopSign(bool b) {
    isStopSignDeployed = b;
  }

  // You can also redefine functions that DO exisit
  public void Beep() {
    Debug.Log("Beep beeeeeep!");
  }
}

//-----------------------------------------------------------------------

// Now we get to why this all matters!

// Imageine you have a "City" program:

public class City {

  // One of the things in your city is a car wash - a car wash is a
  // function that takes an an imput parameter for the type of "thing" 
  // it would work on.

  // If all the different vehicles were unrelated, we'd have to add 
  // a new car wash function for each one, and come back here after each time
  // we added a new vehicle to our fleet:
  //    public void CarWashBus(Bus b)
  //    public void CarwashTruck(Truck t)
  // etc. etc.

  // Because all our vehicles are SUBCLASSES of the Vehicle class, they 
  // all can be assigned into a Vehicle variable. That means we can have ONE
  // carwash function:

  public void CarWash(Vehicle v) {
    // Our car wash makes all the vehicles beep, for some reason...
    v.Beep();
  }

  // With this structure, you can see how we could easily add classes for 
  // Motorcycle, Train, etc. without ever having to go back to change the 
  // City program!
}