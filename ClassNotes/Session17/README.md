# Session 17 - 03/26/18

## Intro to AR
- With VR we could create everything!
    - In AR, we have to (get to?) work as a layer on top of the real world (this is actually _harder!_).
- Let’s take a look at our first definition again: _Inducing targeted behavior in an organism by using artificial sensory stimulation, while the organism has little or no awareness of the interference._
    - This may need to be revised a bit. AR is generally more actively engaged in that “interference”

## Sensing the "Real" World
- 3D Scanning & Modeling
    - Similar to what a Kinect does: gets a 3D model of what it can see.
    - However Hololens relates that scanned model in space to every other scan it does, and continues to build that model as you move around.
    - Having a 3D awareness of space let's us take advantage of **occlusion** - we can put virtual things _behind_ real-world obstacles.
    - Hololens does a decent job of ignoring people.
- 2D Camera & Feature-Points Detection
    - ARKit/ARCore devices that don’t have depth sensors try to lock on to details (features) in the images that they see.
    - They do complex math in-between each frame to see how those feature points have changed.
    - Think of how a flat square looks like a trapezoid when looked at from an angle - you can guess how rotated that square is based on what you know about it.
        - 2D tracking is like this, but without knowing that it's supposed to be looking at a square! (AKA - this is a hard math problem and not all devices can do it fast enough or without immediately burning through battery life)

## Developing for AR
- Let’s talk (again) about **Abstraction**.
    - Things are about to get a bit more complex.
- Allow me a bit of a tangent…
- A programming language is just a text file written according to a standard.
    - Sure, we have tools that help us by auto-completing words and colorizing the text, but you can write any language in any text editor, or even [by hand](http://www.duxburysystems.org/downloads/library/texas/apple/history/museum/computers_apple1/woz6502code.html).
    - A programming language is **not for computers**. It's for us! It is meant to be **human readable**. 
    - The computer doesn’t care if you use C# or C++ or Java or BrainFuck.
- Let’s talk about how computers actually work.
    - What do we really mean by “Computers only understand 0’s and 1’s”?
    - Numbers can be represented in _binary_ notation
        - `0001` = `1`
        - `0010` = `2`
        - `0011` = `3`
        - `0100` = `4`
    - Which makes it possible to act upon them with binary _operations_
        - See slide in notes re: multiplying two binary numbers
    - CPUs consist of _millions_ of these hardware-based operations
    - These systems know what to do because _by design they respond in specific ways to numeric instructions_ AKA ***Machine Code**
- **Compilers** are pieces of software that take the code that _you_ write, and turn it into machine code
-  Machine code does not "talk to" or "instruct" the processor. Rather, the processor knows how to "read" machine code.
    - The CPU "looks" at the next instruction (aka the next chunk of numbers). 
    - When the instructions are executed side-effects occur such as setting a control flag, putting a value in a variable, or jumping to a different index in the program, etc.
    - It is the evaluation of each instruction -- as it is encountered -- and the interaction of side-effects that results in the operation of the computer and what we see as the output
- Bringing it back home:
    - This is why we can’t just finish in Unity anymore! Because these AR devices are running on different processors than our PC, we have to go through another program that will build the final executable (machine code) for the device.
    - We can simulate how the program _should_ run, but once we want to actually use the hardware for real, we have to build to the device.
    - Some extra nerdiness:
        - PC/Mac Standalone (and VR):
            - _C# -> IL -> Bytecode -> JIT Compiler -> x86 Processor Machine Code !_
        - Using Unity's IL2CPP bridge:
            - _C# -> IL -> IL2CPP -> C++ -> Anywhere!_ & _C++ -> XCode -> iOS/Apple A9 processor Machine Code_



## Extra reading
**This is not required!** Just some additional resources you might find interesting/relevant/funny.   
[Apple II Handwritten Code](http://www.duxburysystems.org/downloads/library/texas/apple/history/museum/computers_apple1/woz6502code.html)     
[Unity IL2CPP](https://docs.unity3d.com/Manual/IL2CPP.html)    
[How Does Machine Code Communicate with CPU?](https://stackoverflow.com/questions/9753669/how-does-machine-code-communicate-with-processor)    
[Intermediate Language](https://en.wikipedia.org/wiki/Common_Intermediate_Language)    
[Just-In-Time Compilation](https://en.wikipedia.org/wiki/Just-in-time_compilation)    
[Is JS Compiled?](https://softwareengineering.stackexchange.com/questions/138521/is-javascript-interpreted-by-design)    
[JS Compiled vs Interpreted](https://softwareengineering.stackexchange.com/questions/291230/how-does-chrome-v8-work-and-why-was-javascript-not-jit-compiled-in-the-first-pl)    
[iOS Assembly Language Tutorial](https://www.raywenderlich.com/37181/ios-assembly-tutorial)    
[History of ARM Processor Architecture](https://www.telegraph.co.uk/finance/newsbysector/epic/arm/8243162/History-of-ARM-from-Acorn-to-Apple.html)    
[Differences b/w ARM and x86 Assembly](https://stackoverflow.com/questions/1732394/differences-between-arm-assembly-and-x86-assembly)    
[Principles of CPU Architecture](https://www.pctechguide.com/cpu-architecture/principles-of-cpu-architecture-logic-gates-mosfets-and-voltage)    
