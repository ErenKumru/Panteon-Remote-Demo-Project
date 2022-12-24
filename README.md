# Panteon Remote Demo Project
Welcome to my Panteon Remote job interview demo project.
You can download the playable Windows build and Android build from: https://drive.google.com/file/d/1jbRG7An29eZYs7m-dsa3CsU3DL95D3jh/view?usp=sharing

https://user-images.githubusercontent.com/44412775/209444179-de767211-538c-41ea-8701-63e76d8213c0.mp4

## Working Dates (in 2021)
- 10 August - 12 August

- 19 August - 26 August

Note: The due date was agreed to be 26 August or earlier as it was known that I was going to participate in the "Udo Next Jam #1" game jam from 13 August to 17 August.
- Also, I would like to let you know that we are very happy and proud to announce that our team's game "TRINITY" won the "Udo Next Jam #1". You can reach the game from: https://erenkumru.itch.io/trinity

## Known Bugs and Issues
- Starting painting from outside of the wall to the surface of the wall causes line renderer to draw a line from origin to the edge of the wall.
- Player character Idle <-> Run transitions might happen more than intended.
- Painting the wall runtime percentage might not always work as intended.

## Missing Mechanics
- Rotating platform does not affect the characters moving on the platform.

## Added Aspects
- Constant music
- Menu that stops the game. In menu you can mute/unmute and adjust the volume of the music
- A working ranking list. The ranking is not only calculated for the player but all the characters are ranked (only player character ranking shown in the UI purposely)
- Camera transition between the racing and painting parts of the game joined with the paintable wall rising animation
- Bounding box when touched spawns the character from the starting point

## Thoughts & What I Learned
- Panteon Remote Demo Project was a different challenge for me as I never implemented AI characters nor drawing mechanics before. Half of my working time, maybe more, was spent researching.
I learned a lot from this challenge and will continue my learning journey as I always do.
- I learned one of many methods for drawing lines using Line Renderer component, and I also learned that it has some issues and there are better methods.
- I already knew NavMesh, how to create AI characters and pathfinding algorithms (like A* and Dijkstra's) but never used any of them in games before. Thanks to this project, now I have some practice with NavMesh. I also learned a lot more about pathfinding algorithms and how they are used in various games.
- Also learned to reach meshes from the code and use its properties like vertices and triangles. I already knew basics of computer graphics, shaders and how meshes created but I only had practice on the topic using webGL2.0.
- Might and should have learned a lot more fantastic information, again, thanks to Panteon Remote Demo Project

Thanks for reading! Be my guest. Don't hesitate to contact me for anything. You can download/clone and examine/study the project freely for personal use.
### For personal use ONLY! Do NOT use/clone this project otherwise!
