# SkateBoardFight
 
Skate Board Fight To-Do

Notes
	Use static for global stuff
	Use unsigned for big positive numbers
	Comment your dang code and go through it to make sure everything is alright and there is nothing unneeded
	Sort .cs files into folders

Global Sprite sheets

Think about making level editor and other state machine states static

Ray-casting
	-Returns point x, y
	-Returns object it’s intersecting
	http://afloatingpoint.blogspot.com/2011/04/2d-polygon-raycasting.html
	https://lodev.org/cgtutor/raycasting.html


Level Editor (Probably need another program for the level editor)
	->16x16 grid
	->Tile Based (Except for rails)	
	->Object picking/UI (Can be chosen by clicking)
	->Buttons highlight or something on select
	->Prevent overlapping and add in erasing tiles

	-Rails placed on top of tiles (At an angle if needed) (Use points and render lines)

	-Collision editor chose what tiles are colidable and render their colliders
	-Scrolling camera
	-Eraser button as well as right clicking
	-Outlines of the shapes you’re about to place
	-Spawn points
	-Serialize dataa

	(Do this later)
	-Props (Some might be grindable)

Add all game objects to dictionaries and loop through them for updates and stuff

Map Interactions
	-Acceleration  going down on sloped surfaces deceleration going up
	-Grind-able Rails
		-Move player along rails that are at a set angle (You’ll need to modify both the x and the y)
	-For slop collisions use y = m * x + b or consider using n sided polygon collisions
https://en.wikipedia.org/wiki/Point_in_polygon
https://en.wikipedia.org/wiki/Ray_casting

Resizable Window

Add in moves
	-Make jump build up over time (Similar to Mario)
	-Kick animation space bar
	-Different combos for the other anims
	-Grind animation
	-Ollie is the jump animation
	-Kick flip kick (Like the kick flip anim but flipped vertically so you can attack enemies from below)
	-Play gameboy colour Tony Hawk

Different Characters
	Make fighter class more modular so it’s easier to make new moves

Menu
	Implement state machines and whatnot

Multiplayer
	Get other player to move around
	Damage 
	Scrolling

UI (Nes Style)
	-Black Bars on top
	-Player Icons
	-Thing showing what buttons you have pressed for your move similar to google doodle olympic skateboard mini game
	-Health

Single Player
	Enemies
	Levels

Optional CRT filter

Done
Implement Input class
	-Get axis (Returns one or zero so it gets rid of if statements)
	-Bind buttons to input  eg(Bind A and Left Arrow to the negative of movement and D and right arrow to positive)
	-Basicly copy Unity’s old input system because I like it

Implement a time struct to store all time stuff so you don’t have to do references

Implement a global variables struct
