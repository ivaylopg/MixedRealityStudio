# Session 05 - 09/05/17

## Recap
* User interaction and setting up expectations
    * Example of baby trying to zoom/pinch on magazine after using iPad
* We need code as **Triggers** in what we make
* Designing for interaction
    * What? (what is the actual input and output)
    * How do we cue that interaction?
    * The technology enables interactions       
    * **Skeuomorphism** as a design approach
* Screens vs Space
    * Scale really matters
        * 1:1 relationship with space
        * AR apps can measure real world units
* Two major concepts today:
    * **Manipulation**
        * 2D (we take this for granted but it was not always this way)
        * 3D examples:
            * LEAP sensor
            * Oculus/Vive handles
    * **Exploration**
        * Natural, but limited by available space.
        * JPL - 1:1 models of rovers for designers to walk around
        * Exploration can be a manipulation too: content can react to your position

    

## AR/VR design principles continued
### UI and UX
* User Interfaces and User Experience
* UX is the design of how the user interacts with your program and UI is the visual manifestation of the design
* **Diegetic** and **Non-Diegetic**
    * Diegetic elements are part of the fictional world ("part of the story"), as opposed to non-diegetic elements which are stylistic elements of how the narrator tells the story ("part of the storytelling”).
    * In movies, subtitles and voiceover are non diegetic. The music coming out of John Cusack’s boom box in Say Anything is diegetic…
    * …but the music playing in the scenes of Tom Hardy in Dunkirk is non-diegetic (We would not hear it if we were in the cockpit with him)…
    * …and the music playing in the scenes of Tom Hardy in Mad Max is a grey area (Some music is in the scene, some is a score in the movie).
* Examples:
    * Heads-Up-Display (Terminator)
        * **Non-Diegetic**
        * Not attached to or part of anything in the scene - serves as a “narrator” describing things in the scene.
    * Menu Attached to In-scene Objects (Tiltbrush menu and MIT AR interface prototype)
        * Diegetic
        * Menu attached to an object you can manipulate in the scene - feels like it some thing in the scene.
    * Flat Panes Floating in Space
        * Diegetic
        * A convenient bridge between screens and space
        * Still can use principles of 2D (pixel-based) design where appropriate.
        * A good argument for doing this: _The less realist the shape is, the easier the user can understand it’s a foreign element, and be enticed to start interacting with it._ (It's obviously not something in the scene just meant to be looked at)
    * Moving-Around/Exploring
        * Diegetic
        * Discover new info about scene by moving around and actually looking from different points of view.
        * Interaction can be built around this - not just passive “looking”
* Neither is "right" or "wrong" but both approaches have implications for how you lead a user through your project

### Design Process
* **Double Diamond** is the name of a design process model developed by the British Design Council in 2005
    * _Different designers manage the process of design in different ways. But when we studied the design process in eleven leading companies, we found striking similarities and shared approaches among the designers we talked to._
        * Alessi, BSkyB, BT, LEGO, Microsoft, Sony, Starbucks, Virgin Atlantic Airways, Whirlpool, Xerox, Yahoo!
    * **Very useful to structure development of ideas when otherwise so open ended**
* Phases of this process are either diverging or converging. During a **diverging** phase, you try to open up as much as possible without limiting yourself, whereas a **converging** phase focuses on condensing and narrowing your findings or ideas.
* Each phase isn't necessarily equal in time, it is **equal in weight/importance**
    * **Discover** - The first quarter of the Double Diamond model covers the **start of the project**. Designers try to **look at the world in a fresh way, notice new things and gather insights**.
    * **Define** - The second quarter represents the definition stage, in which designers try to **make sense of all the possibilities** identified in the Discover phase. **Which matters most? Which should we act on first? What is feasible?** The goal here is to develop a clear creative brief that frames the fundamental design challenge.
    * **Develop** - The third quarter marks a period of development where **solutions or concepts are created, prototyped, tested and iterated**. This process of trial and error helps designers to improve and refine their ideas.
    * **Delivery** - The final quarter of the double diamond model is the delivery stage, where the **resulting project (a product, service or environment, for example) is finalized, produced and launched**.

### In-Class project
* Back in our teams, we will continue to undergo this design process around the same concept: **A Laser-Trap Avoidance Game**
* This will be our "product" - let’s go through the rest of the process with it
    * We already did **Discover**
    * Now let's do **Define**
* Break down into small, bite-sized pieces
    * Recap of tools available to us:
        * Voice
        * Look
        * "AirTap"
        * Movement
* **Minimum Viable Product**
    * _The Lean Startup_ - by Eric Ries
    * _"Maximum amount of validated learning about customers with least effort."_
    * Basically, identify the most important core of the idea and build that first before you incrementally improve and add to it.
* Also can think about it as **Riskiest Assumption Test** 
    * There is no need to build more than what’s required to test your largest unknown. 
    * No expectation of perfect code or design. No danger it will prematurely become a product.
* A way to very quickly get to something usable that gets you “from point A to point B”.

## Exercise Questions
* So, What is our MVP?
* Non-Obvious user interactions
    * Once we have MVP, but how do we get the user there? 
    * What scaffolding do we need around it to make it a final product?
* Instructions
    * Narrative vs Utilitarian
        * Option A: _“Hello Special Agent X. I see you’ve arrived at our training facility…”_
        * Option B: _“Walk to destination without touching the lasers”_
    * Neither is "correct" but one may be more appropriate for the kind of idea you are making.
* Do we have multiple levels? Do they increase in difficulty? How do we define how a level has ended?
* Does our experience have an end?
    * What is our endgame? 
        * Go until you die? Time limit? Reach specific "last" level?
* What info do we need to present to user?
     What level are we on?
        - Levels get more complicated as we move along.
        - How?
            - More obstacles
            - Moving obstacles  - What score?
    - Have you finished level?
What info do we need to keep track of?
    - States?
        - Level Finished/Building new level
        - Game over
    - Health/Lives?
* **Feature Creep** - Beware of adding too much incrementally
* **Pseudocode**
    * An informal high-level description of the operating principle of a computer program or other algorithm.
    * Use to plan out the logic of how to implement some of these defined components.
        * **All of you need to know enough logic about how the code works to write pseudocode.**

## Assignments for next week
* [Designing for Mixed Reality - Chapter 5](http://www.oreilly.com/design/free/designing-for-mixed-reality.csp)
* [Design For Humanity - Parts 4,5](https://medium.com/swlh/how-to-design-a-cui-59f1fb3f35fc)

## Extra reading
**This is not required!** Just some additional resources you might find interesting/relevant/funny.    
[A Study of the Design Process](http://www.designcouncil.org.uk/sites/default/files/asset/document/ElevenLessons_Design_Council%20(2).pdf) - This is the British Design Council report on the 11 companies that all had the Double Diamond in common.    
[IDEO's "Human Centered Design Kit"](https://www.ideo.com/post/design-kit)    
[MIT "Smarter Objects" Video](https://www.youtube.com/watch?v=UA_HZVmmY84)    
[The Lean Startup](https://www.amazon.com/Lean-Startup-Entrepreneurs-Continuous-Innovation/dp/0307887898/ref=sr_1_1?ie=UTF8&qid=1504743268&sr=8-1&keywords=Lean+Startup) - This is an amazon link but I would be surprised if the school library didn't have this.    
[Building the Terminator Vision HUD in HoloLens](https://blogs.windows.com/buildingapps/2017/03/06/building-terminator-vision-hud-hololens/#ftUSQbkgue6cugvQ.97)    
[4 Things I learned Designing User Interfaces for VR at Disney](https://medium.com/startup-grind/4-things-i-learned-designing-user-interfaces-for-vr-cc08cac9e7ec)    
[Core Principles of UI Design](https://www.invisionapp.com/blog/core-principles-of-ui-design/)    
[Psychological approach to Design](https://uxplanet.org/psychological-approach-to-design-3e955196bd19)
