# Session 04 - 01/22/17

## Intro
* Lots to do today!
* Miscellaneous reminders:
    * Remember that lecture slides, notes, and reading will be on [github](https://github.com/ivaylopg/Tech421Tech3706)
    * First session of each week will usually be talking/discussion, second sessions will be more technical.


## Recap: Defining AR/VR/MR
* We want to come up with a working definition of AR/VR
* _Inducing targeted behavior in an organism by using artificial sensory stimulation, while the organism has little or no awareness of the interference._ - LaValle
* Think about this outside of just code: we are emphasizing “behavior” and creating a reality for user’s experience.
    1. Inducing behavior
    2. Artificial sensory stimulation
    3. Little or no awareness of the interference 
* So much out there is marketing term or people trying to be the first to coin phrases.
    * As far as this class is concerned, we’re drawing the line here:
    * **Virtual Reality** = Where everything that the user sees & hears is controlled by the created experience.
        * It is a world built from the ground up, and you (as the creators) are responsible for creating all the rules of how this world behaves and what the expectations are.
    * **Augmented Reality** = You are adding things to the real world.
        * The rules/expectations of the real world still apply, and you can leverage that to your advantage.
    * What about _Mixed Reality?_
        * In the context of this class (i.e. the name of the course), we're just using it as a shorthand for everything related to this kind of design thinking and creating virtual spaces.
        * **HOWEVER** - _Mixed Reality_ does have a specific meaning in AR:
            * You'll see this term a lot if you start looking up Hololens tutorials or example projects.
            * Mixed Reality is a *type* of augmented reality, where the physical (ie - the real world) and the virtual can interact and affect each other. More than just an overlay onto your field of view, MR knows what you are looking at.


## Creative Coding
* **Creative Coding** is a type of computer programming in which the goal is to create something expressive instead of something functional.
    * In this context we can use code to enable/empower/drive our creative and aesthetic projects. It is the other side of the same coin as Unity's graphical editor.
    * Think of this type of coding as closer to writing fiction than solving math equations - there may not be a "right" answer.
    * The emphasis on the code we write in this class is to enable prototyping quickly
* **Remember** - our definition of MR is about creating realities, not about exporting an .exe or iPhone app
    * Immanuel Kant - Dual nature of reality
        * Physical world vs perceived world.
    * Antonin Artaud  - The Theatre and Its Double
        * Attack on theatrical convention: opposing the viewer's sensual experience vs theatre as a contrived literary form
* These websites have some great projects for inspiration:
    * [creativeapplications.net](http://www.creativeapplications.net)
    * [prostheticknowledge.tumblr.com/](http://prostheticknowledge.tumblr.com/)

## Recap: Intro to Design Principles

## Fundamental Design Principles
* Designing for Space instead of Screens
    * All of a sudden we have to think about context for what we make
        * VR Deals with it by creating environments
            * Netflix web example, Netflix VR example
            * VR "Home" interfaces - need a context for the screens we use
                * Biggest criticism was that people couldn’t change this home environment to suit their personality. Oculus changed this at last year’s announcements.
    * Not constrained by available resolution, but by space in the real world
    * Interesting challenge about this is that we're moving towards unknown. There are no answers
    * Scale really matters
        * 1:1 relationship with space
        * AR apps can measure real world units
* Two concepts we will keep returning to:
    * **Manipulation**
    * **Exploration**
* **Case Study** - VR Podcast App
    * [M. Eifler, AKA Blinkpopshift](http://elevr.com/studio-metaphor-an-embodied-software-paradigm/)
    * Different scales allow different interactions. Podcast app as a space you can go inside
        * This relates to something called Modality - we will explore this in a later session
        * Modality - A particular mode in which something exists or is experienced or expressed.
            * (Basically, the way that you do something.)


## Group Exercise
* _When asked, "How could you possibly have done the first interactive graphics program, the first non-procedural programming language, the first object oriented software system, all in one year?" Ivan replied: "Well, I didn't know it was hard.”_
* **10 Minutes** - Brainstorm
    * Come up with examples of:
        * Something Digital you Wish you could touch?
        * Something big you wish you could see small?
        * Something small you wish you could see big?
        * Something invisible you wish you could see?
    * Specifically think about places where technology is a _barrier_.
* **10 Minutes** - Synthesize
    * Combine similar ideas
    * Separate complex ideas
    * Find Cause & Effect Relationships
* Great! This is our "I didn't know it was hard" baseline. (I'll include a photo of this board on the github)

---

## Intro to unity (See annotated slides for more detail)
* Intro to the Unity Interface
    * Hierarchy, Project Navigator, Inspector, Console
    * **Edit** mode vs **Play** mode
* Game Objects and Nesting hierarchy
    * [Video: Create Primitive Shape](https://vimeo.com/253172756/dc9e9733de)
    * [Video: Nesting in Hierarchy](https://vimeo.com/253172776/f5588d3c87)
* Adding **Components** to Game Objects
    * Materials
    * [Video: Create and Add Material](https://vimeo.com/253172720/0589f5768d)
    * Rigid Bodies and Colliders
* Prefabs
* Adding ready-made scripts
* Asset Store
    * First-person controller for prototyping
    * Because we only have one VR headset (much sadness)
    * Bringing in First-person controller is similar to bringing in VR Framework


## Assignments for next week
* [John Underkoffler - TED Talk and Article](https://thenextweb.com/media/2015/08/31/a-stark-future/)
* [Design For Humanity - Parts 1, 2, 3](https://medium.com/swlh/the-future-of-design-is-emotional-5789ccde17aa)


## Extra reading
**This is not required!** Just some additional resources you might find interesting/relevant/funny.    
[Core Principles of UI Design](https://www.invisionapp.com/blog/core-principles-of-ui-design/)    
[Psychological approach to Design](https://uxplanet.org/psychological-approach-to-design-3e955196bd19)
