# multimodal
Project for DT2140  Multimodal Interaction and Interfaces
Using this as a shared notepad for now

### Ball
Basically done. 
We might want to add a change of speed or angle depending on where on the paddle we hit the ball.
We might want to add curve to the ball depending on velocity of the paddle when collision with ball occurs.

### Player control
Versions with touch interaction with the paddle are complete.
We want to add a version where we remove the visible paddle and give the camera a rigidbody, using it as the player paddle.

### Computer control
Done.
Unless we want to add some unpredicatable behaviour?

### Board
Done. 
Some design and recolouring perhaps?

### UI
Very basic.
Do we want to add a menu?

### Game rules
Should we add a win condition? (e.g. first to 5 points)
Should score be displayed in augumented reality, projected in the real world - or as currently implemented?

### SFX
Done.
Sound effects for winning, losing and game soundtrack are already in the game if we want to add those.


---------

## Whats needed sketch:

### Scripts
* Ball logic: Ball behaviour, collision handling, curve?, alternating speed?
* Game logic: Keeping track of and incrementing score, win condition, updates UI
* Player paddle control: User input -> motion of paddle, raycast (from touch or constant ray from screen?)
* Computer paddle control: Basic AI, chasing ball coordinates

### Objects
* ARKit stuff: Camera, ARcameramanager and so on
* Ball: Texture? Glow? Basic colour?
* Boundaries: Walls basically. Collision handling
* Paddles: Smaller moving walls

### UI
* Scoreboard
* Ruleset?
* Winner announcement 

### Other
* Sound- scripts and object

