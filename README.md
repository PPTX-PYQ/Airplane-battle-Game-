# 2D Plane‑Battle Game
This endless‑survival shooting game is developed on Unity with C# scripts. Players control the fighter plane to eliminate continuously‑spawning enemies, collect props and gain scores in an infinite‑run gameplay.

## Core Game Features
1. Player Control
- Drag‑based plane movement by mouse, movement boundary limited within the screen.
2. Enemies System
- Three types of enemy aircraft: scout plane, medium fighter and big boss plane, with different speed, size and score values.
3. Prop‑pickup System
- Twin‑bullet prop: temporary double‑shot firing mode for 6 seconds.
- Bomb prop: clear all enemies on screen by right‑mouse‑click, with explosion visual effects.
4. Game UI
- In‑game UI showing bomb‑count.
- Game‑over popup displaying current score and high‑score record.
- Restart and quit buttons available on the end‑game panel.
5. Animation & Audio
- Looping star‑sky background animation.
- Multi‑frame explosion sprite animation for player aircraft and enemies.
- Sound effects for shooting and enemy explosions.
6. Game Rules
- The game ends after the player plane collides with enemies three times. Scores are accumulated continuously for endless challenge.

## Technical Implementation
- C# object‑oriented programming for game logic
- Collision detection and trigger‑event system
- Sprite‑sheet frame animation
- Player‑prefab and enemy‑prefab management
- UI interaction and persistent high‑score storage
