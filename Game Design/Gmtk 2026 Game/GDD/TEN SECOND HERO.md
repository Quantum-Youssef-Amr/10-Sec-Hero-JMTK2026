## Game Design Document

---

### 1. Overview

**Ten Second Hero** is a fast-paced action game where time is your only resource. You play as a desperate hero defending a doorway from waves of enemies, with a timer that counts down from 10 seconds. Every enemy you defeat adds time to the clock, but the door you're protecting takes damage with every enemy that slips through.

**Core Loop:** Dash into enemies to kill them, farm time to unlock the door, and survive across 3 escalating levels. Timer hits zero? You die. Door breaks? You die. Reach the timer target? Door opens. Complete all 3 levels? You win.

---

### 2. Theme Integration: "COUNT DOWN"

The theme is woven into every mechanic:

- **The Timer** counts down from 10, creating constant urgency.
    
- **Killing enemies** reverses the countdown (adds time), rewarding aggression.
    
- **The Door** requires you to "count up" by farming time to unlock it.
    
- **Each level** resets the countdown, creating a rhythm of tension and release.
    

The entire game is built around the player's relationship with a ticking number.

---

### 3. Key Mechanics

you could see [[MOVEMENT SYSTEM — GDD]] for more details 

| Mechanic          | Description                                                                                  |
| ----------------- | -------------------------------------------------------------------------------------------- |
| **Movement**      | WASD / Arrow Keys. Smooth walking for positioning.                                           |
| **Dash Attack**   | Space / Shift. 0.4s cooldown. Kills enemies on contact. The only offensive action.           |
| **Timer**         | Starts at 10. Counts down 1 per second. Hit 0 = Game Over.                                   |
| **Kill Reward**   | Each enemy killed adds +2 seconds to the timer.                                              |
| **Door Health**   | 10 HP. Each enemy touch = -1 HP. Hit 0 = Game Over.                                          |
| **Level Goal**    | Reach the required timer value. Door unlocks. Walk through.                                  |
| **Enemy Scaling** | Enemy types unlock dynamically based on current timer value. Higher timer = tougher enemies. |

---

### 4. Visual & Audio Direction

**Art Style:** Minimalist, geometric shapes with expressive features. The player is a triangle . Enemies are simple geometric shape with different colors and behaviors. Backgrounds shift colors per level (Green → Yellow → Red).

**Audio:** Simple, punchy sound effects (death pops, door damage thuds, timer warning beeps). Music speeds up as timer drops below 3 seconds.

**Juice:** Screen shake on door hits and enemy deaths. Particle bursts on kills. Red screen flash when timer is low. Timer text grows and pulses at 3 seconds.

---

### 5. Development Priorities

| Priority         | System                                                                           |
| ---------------- | -------------------------------------------------------------------------------- |
| **Must Have**    | Player movement, dash attack, timer, enemy spawn, door health, level progression |
| **Should Have**  | Screen shake, particles, sound effects, UI polish                                |
| **Nice to Have** | Music, leaderboard, visual enemy variety                                         |
|                  |                                                                                  |

---

### 6. Scope Commitment

3 levels. 3 enemy types. One room per level. One core mechanic (dash to kill). Polish over features.

**Finish > Perfect.**

---

### 7. Enemies

wanna know the enemies ?? see this gdd [[Enemies GDD]]

---

### 8. Levels
see this gdd [[Levels GDD]]
