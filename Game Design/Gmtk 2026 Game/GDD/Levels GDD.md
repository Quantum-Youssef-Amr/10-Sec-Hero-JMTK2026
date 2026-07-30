
Let's lock in the **level design** with the same critical approach.

---

## 🔍 CRITICAL THINKING: Levels in a Jam Game

**The Challenge:** We have 3 levels. Each needs to feel *different* without requiring massive new assets or systems.

**The Trap:** Making levels that are just "more enemies, faster" = boring. Players will feel like they're playing the same level 3 times.

**The Solution:** Each level should introduce a **new twist** that changes how the player approaches the game, while keeping the core mechanics identical.

---

## 🎯 MY PROPOSAL: 3 LEVELS, 3 THEMES

### Level 1: "THE AWAKENING" (Green)

**Theme:** Introduction. The player learns the basics.

**Background:** Calm green. Gentle pulsating.

**Enemies Active:** Slime, Wobbler, Grunt (1-hit enemies, slow-medium speed)

**Timer Target:** 20 seconds (need +10 from kills)

**Spawn Rate:** Every 2.5 - 3.5 seconds

**Max Enemies:** 2

**Door HP:** 10

**The Twist:** None. This is the tutorial level. Players learn:
- Move with WASD
- Dash with Space to kill
- Timer goes down, kill to add time
- Door takes damage if enemies touch it

**Experience:** Low stress. Forgiving. Learning the ropes.

**Expected Door HP Lost:** 1-3 HP max.

---

### Level 2: "THE SIEGE" (Yellow)

**Theme:** Pressure. Enemies are faster and more aggressive.

**Background:** Warm yellow/orange. Slight pulsing.

**Enemies Active:** All Level 1 enemies + Runner, Jumper, Spinner

**Timer Target:** 30 seconds (need +20 from kills)

**Spawn Rate:** Every 1.8 - 2.5 seconds

**Max Enemies:** 4

**Door HP:** 10

**The Twist:** **Enemies spawn from TWO directions instead of one.**

- In Level 1, enemies spawn from one side.
- In Level 2, enemies spawn from **opposite sides** (left and right).
- The player must split attention and dash between both sides.

**Experience:** Moderate stress. Player must be strategic about positioning. Door damage becomes a real threat.

**Expected Door HP Lost:** 4-6 HP.

---

### Level 3: "THE FINAL COUNT" (Red)

**Theme:** Chaos. Everything is fast and aggressive.

**Background:** Intense red. Rapid pulsing, screen edge darkens.

**Enemies Active:** **ALL 9 enemies** including Tank, Blitzer, Bomber

**Timer Target:** 40 seconds (need +30 from kills)

**Spawn Rate:** Every 1 - 1.8 seconds

**Max Enemies:** 6

**Door HP:** 10

**The Twist:** **The timer starts at 5 seconds instead of 10.**

- Level 3 starts with 5 seconds on the clock.
- This means the player MUST kill immediately or die.
- Panic mode from second 1.
- Door is also under heavy assault.

**Experience:**
- High stress. Pure panic.
- Player feels like a hero if they survive.
- Requires mastery of dash timing and enemy prioritization.

**Expected Door HP Lost:** 6-8 HP. Victory is earned.

---

## 📊 LEVEL COMPARISON TABLE

| Aspect                    | Level 1 (Green) | Level 2 (Yellow) | Level 3 (Red)      |
| ------------------------- | --------------- | ---------------- | ------------------ |
| **Background**            | Green           | Yellow           | Red                |
| **Timer Start**           | 10s             | 10s              | 5s                 |
| **Timer Target**          | 30s             | 60s              | 8 0s               |
| **Enemies**               | 1-3 (slow)      | 1-6 (medium)     | 1-9 (fast + tanks) |
| **Spawn Rate**            | 2.5-3.5s        | 1.8-2.5s         | 1.0-1.8s           |
| **Max Enemies**           | 2               | 4                | 6                  |
| **Spawn Directions**      | One side        | Two sides        | Two sides + random |
| **Door HP**               | 10              | 10               | 10                 |
| **Twist**                 | None (tutorial) | Two spawn points | Timer starts at 5s |
| **Difficulty**            | Easy            | Medium           | Hard               |
| **Expected Door HP Lost** | 1-3             | 4-6              | 6-8                |

---

## 🎨 VISUAL LEVEL THEMING

| Element | Level 1 | Level 2 | Level 3 |
|---------|---------|---------|---------|
| **Background** | Solid Green | Solid Yellow | Solid Red |
| **Grid/Pattern** | Faint grid | Faint grid | Faint grid + dark vignette |
| **Timer Color** | White | White → Yellow (low) | White → Red (low) |
| **Door Glow** | Green | Yellow | Red |
| **Player Trail** | White | Yellow | Red/Orange |
| **Particles** | Green sparkles | Yellow sparkles | Red + Orange sparkles |
| **Music Tempo** | Calm (80 BPM) | Medium (120 BPM) | Fast (160 BPM) |
| **Pulse Effect** | None | Subtle heartbeat | Intense heartbeat |

---
## 📝 LEVEL DESIGN NOTES

### Why Level 3 Starts at 5 Seconds

- **Immediate panic.** No time to adjust. Player must react instantly.
- **Matches the theme.** "Count DOWN" is literal. The count is already almost over.
- **Creates a climax.** Level 3 feels *different* from the first frame.
- **Tests mastery.** Can you kill 2 enemies in the first 3 seconds?

### Why Door HP Never Changes

- **Consistency.** Player learns that 10 HP is always the same.
- **Skill scaling.** The challenge comes from enemies, not the door.
- **Fairness.** The same mistake (enemy touch) always has the same consequence.
- **Simplicity.** We never need to explain "door HP is different this level."

### Why Spawn Directions Change

- **Adds spatial awareness.** Level 1: players camp near the spawn. Level 2: can't camp anymore.
- **Forces movement.** Player must travel between spawn points.
- **Increases tension.** Enemies come from unexpected directions.

---

## 🏆 VICTORY SCREEN

```
┌─────────────────────────────────────────────────┐
│                                                 │
│     🎉  YOU SURVIVED THE COUNTDOWN!  🎉        │
│                                                 │
│                                                 │
│     ⏱️  Total Time:  XX seconds                │
│     💀  Enemies Killed:  XX                    │
│     🚪  Door HP Remaining:  X/10               │
│                                                 │
│                                                 │
│          [  PLAY AGAIN  ]                       │
│          [   EXIT     ]                         │
│                                                 │
└─────────────────────────────────────────────────┘
```

---

## ✅ FINAL LEVEL SYSTEM SPECS

| System | Specification |
|--------|---------------|
| Number of Levels | 3 |
| Level Goal | Reach timer target (20s, 30s, 40s) |
| Door Unlock | Door opens when timer reaches target |
| Level Transition | Walk through door → fade out → new level |
| Timer Reset | Resets to 10s (Level 1 & 2) or 5s (Level 3) |
| Door HP Reset | Resets to 10 each level |
| Background | Changes color per level (Green → Yellow → Red) |
| Enemy Unlock | Based on timer value, not level (dynamic) |
| Victory | Complete Level 3 → Victory Screen |


---

## 🔍 BALANCE CONSIDERATIONS

### Level 1 Difficulty Check
- **Slime** (slow, 1 hit, +2s)
- **2 enemies max** at a time
- **Spawn every 3 seconds**
- **Target: 20s** (needs 5 kills on average)

**Result:** Easy. Player should beat it in 1-2 attempts.

### Level 2 Difficulty Check
- **Runners** (fast, 1 hit, +2s)
- **4 enemies max** at a time
- **Spawn from two directions**
- **Target: 30s** (needs 10 kills on average)

**Result:** Moderate. Good players clear it. Newer players may need 2-3 attempts.

### Level 3 Difficulty Check
- **Tanks** (2 hits, +4s), **Blitzers** (very fast), **Bombers** (+3s)
- **6 enemies max** at a time
- **Timer starts at 5s**
- **Target: 40s** (needs 15+ kills on average)

**Result:** Hard. Players must have mastered the dash. Feels like a real victory.
