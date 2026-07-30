Here's your **updated, comprehensive To-Do List** with all new edits from the GDDs integrated.

---

## 🗂️ PHASE 0: PROJECT SETUP (Day 1, Hour 1)
**Goal:** Empty project, ready to code.

- [x] **Create Unity Project** (2D Core, Unity 2022 LTS or latest stable).
- [x] **Folder Structure:** Create `Scripts/`, `Scenes/`, `Prefabs/`, `Art/`, `Audio/`, `Fonts/`.
- [x] **Build Settings:** Switch to PC/Mac Standalone (and WebGL for later).
- [x] **Input Manager:** Set up `Horizontal`/`Vertical` axis (WASD/Arrows).
- [x] **Scene Setup:** Create `Game` scene with a dark background and a Camera (set to Orthographic, Size ~5-6).
- [x] **Layer Setup:** Create layers for Player, Enemy, Door.
- [x] **Physics2D Settings:** Set up collision matrix (Player hits Enemy, Enemy hits Door).

---

## 🏗️ PHASE 1: CORE SYSTEMS (Day 1, Hour 2-6)
**Goal:** The game is "playable" (you can move, dash, see timer, and door).

### Player (Movement GDD)
- [x] **PlayerController.cs** – Combines movement + dash in one script.
  - [x] WASD/Arrow movement, constant speed (5 units/sec), normalized diagonal.
  - [x] Space/Shift dash, 0.4s cooldown, dash distance 3 units (instant teleport).
  - [x] Dash direction = move input priority; if idle, use last facing direction.
  - [x] During dash (0.1s), movement input is ignored.
  - [x] Use `Rigidbody2D.velocity` for movement, `gravityScale = 0`.
- [x] **PlayerVisuals** – Create a simple white triangle sprite (player is a triangle per GDD).
  - [x] Add two tiny eyes (worried expression).
  - [x] Rotate to face movement direction.
- [x] **Dash Trail** – Simple white ghost trail behind player when dashing.
- [x] **Dash Cooldown Indicator** – Player flashes briefly or small UI bar near feet.
- [x] **Dash Zoom** – Slight camera zoom out on dash (optional polish).

### Timer System (Timer GDD)
- [x] **TimerSystem.cs** – Counts down from start value, 1 second per tick.
  - [x] Level 1: Start 10s, Target 30s.
  - [x] Level 2: Start 10s, Target 60s.
  - [x] Level 3: Start 5s, Target 80s.
- [x] **TimerUI** – Display timer as large text at the top-center.
- [x] **Kill Reward Logic** – +2s (standard), +3s (Bomber), +4s (Tank) on enemy death.
- [x] **Low Timer Warning** – Text turns Red and scales up when timer <= 3 seconds.
- [x] **Timer Reset** – Reset to level-specific start value on level load.
- [x] **Timer Tick Sound** – Subtle click each second (speeds up under 3s).
- [x] **Red Screen Flash** – Screen edge pulses red when timer < 3s.

### Door System (Door GDD)
- [x] **DoorSystem.cs** – 10 HP. Each enemy touch = -1 HP.
  - [x] Door HP resets to 10 each level.
  - [x] Door unlocks when timer reaches target (30s, 60s, 80s).
- [x] **DoorVisual** – Create a glowing rectangle in the center.
  - [x] Glow color changes per level (Green → Yellow → Red).
  - [x] Add lock icon (changes to unlocked when target reached).
- [x] **Door Health UI** – Display as 10 small squares or health bar above door.
- [x] **DoorDamage** – Decrement HP when enemy touches it.
  - [x] Screen shakes slightly.
  - [x] Door flashes white/red.
  - [x] Play "Thud" sound.
- [x] **DoorUnlock** – Door changes color, particles burst, opens (slide up/down).
- [x] **Game Over (Door)** – If HP = 0, trigger Game Over screen ("DOOR DESTROYED!").

### Core Managers
- [x] **GameManager.cs** – Tracks game state (Playing, LevelComplete, GameOver, Victory).
  - [x] GameOver(string reason) – Trigger game over with reason.
  - [x] LevelComplete() – Trigger level complete.
  - [x] Victory() – Trigger victory screen.
  - [x] RestartGame() – Reload scene.
- [x] **LevelManager.cs** – Manages 3 levels with all data.
  - [x] Level 1: Green, Start 10s, Target 30s, 1 spawn side, 2 max enemies, spawn 2.5-3.5s.
  - [x] Level 2: Yellow, Start 10s, Target 60s, 2 spawn sides, 4 max enemies, spawn 1.8-2.5s.
  - [x] Level 3: Red, Start 5s, Target 80s, 3 spawn sides, 6 max enemies, spawn 1.0-1.8s.
  - [x] LoadLevel(int index) – Applies all level settings.
  - [x] Level Transitions – Fade to black, display "LEVEL X: NAME" text, fade in.
- [x] **UIManager.cs** – Manages all UI screens.
  - [x] ShowGameOver(string reason).
  - [x] ShowLevelComplete().
  - [x] ShowVictory().
  - [x] UpdateTimerUI(int time).
  - [x] UpdateDoorUI(int hp).

---

## 👾 PHASE 2: ENEMY SYSTEM (Day 2, Hour 1-6)
**Goal:** Enemies spawn, move, and die. The core loop is functional.

### Enemy Base (Enemy GDD)
- [x] **Enemy.cs** (Base class) – Health (int), Speed (float), Reward (int).
  - [x] MoveTowardDoor() – Moves toward door position.
  - [x] TakeDamage(int damage) – Reduces health, flashes white, checks death.
  - [x] OnDeath() – Adds time reward, spawns particles destroys self.
  - [x] plays sound on **Death**
  - [x] OnTriggerEnter2D – If enemy touches door, deal damage to door and destroy self.
- [x] **Enemy Hit Detection** – OnTriggerEnter2D with Player dash hitbox.
  - [x] If enemy is hit by dash, call TakeDamage(1).
  - [x] Tank takes 2 hits; flash white after first hit.

### Enemy Variants (9 Types) - All inherit from Enemy.cs
**Level 1 Enemies (Green Background):**
- [x] **Slime** – Circle, Light Green, 1 HP, Speed 1.5, straight to door. Reward +2s.
- [x] **Wobbler** – Circle, Teal, 1 HP, Speed 1.5, zig-zag toward door. Reward +2s.
- [x] **Grunt** – Square, Orange, 1 HP, Speed 2.5, straight to door. Reward +2s.

**Level 2 Enemies (Yellow Background):**
- [x] **Runner** – Triangle, Yellow, 1 HP, Speed 4.0, straight to door. Reward +2s.
- [x] **Jumper** – Diamond, Purple, 1 HP, Speed 3.5, teleports every 2s toward door. Reward +2s.
- [x] **Spinner** – Hexagon, Pink, 1 HP, Speed 2.5, moves in circular path toward door. Reward +2s.

**Level 3 Enemies (Red Background):**
- [x] **Tank** – Square, Dark Red, **2 HP**, Speed 1.5, straight to door. Reward +4s. Flash white after first hit.
- [x] **Blitzer** – Triangle, Bright Red, 1 HP, Speed 5.0, straight to door. Reward +2s. Motion lines trailing.
- [x] **Bomber** – Circle, Black/Orange, 1 HP, Speed 2.5, straight to door. Reward +3s. Explodes on death, damages nearby enemies (not door).

### Spawner System (Enemy GDD)
- [x] **EnemySpawner.cs** – Continuous spawn with random interval.
  - [x] Spawn rate based on current level data (Level 1: 2.5-3.5s, Level 2: 1.8-2.5s, Level 3: 1.0-1.8s).
- [x] **Dynamic Unlocking** – Activate enemy types based on current timer value.
  - [x] 10-14s: Slime, Wobbler, Grunt.
  - [x] 15-19s: + Runner.
  - [x] 20-24s: + Jumper.
  - [x] 25-29s: + Spinner.
	  - [x] 30-34s: Level 1 + Level 2 (except Spinner).
  - [x] 35-39s: All Level 1 + All Level 2.
  - [x] 40s+: **All 9 enemies active.**
- [x] **Max Enemies** – Limit active enemies based on level data (Level 1: 2, Level 2: 4, Level 3: 6).
- [x] **Spawn Directions** – Based on level data.
  - [x] Level 1: 1 side (Left).
  - [x] Level 2: 2 sides (Left + Right).
  - [x] Level 3: 3 sides (Left + Right + Top/Random).
- [x] **Enemy Spawn Animation** – Pop from ground or fade in.

---

## 🎨 PHASE 3: LEVELS & VISUALS (Day 3, Hour 1-4)
**Goal:** 3 distinct levels, proper UI, and art placeholders become final.

### Level Implementation (Level GDD)
- [x] **Level 1: "THE AWAKENING"** – Green background.
  - [x] Spawn Side: Left.
  - [x] Target: 30s, Start: 10s.
  - [x] Spawn Rate: 2.5-3.5s, Max Enemies: 2.
  - [x] Enemies Active: Slime, Wobbler, Grunt.
  - [x] Expected Door HP Lost: 1-3 HP.
- [x] **Level 2: "THE SIEGE"** – Yellow background.
  - [x] Spawn Sides: Left + Right.
  - [x] Target: 60s, Start: 10s.
  - [x] Spawn Rate: 1.8-2.5s, Max Enemies: 4.
  - [x] Enemies Active: All Level 1 + Runner, Jumper, Spinner.
  - [x] Expected Door HP Lost: 4-6 HP.
- [x] **Level 3: "THE FINAL COUNT"** – Red background.
  - [x] Spawn Sides: Left + Right + Random.
  - [x] Target: 80s, Start: **5s**.
  - [x] Spawn Rate: 1.0-1.8s, Max Enemies: 6.
  - [x] Enemies Active: **ALL 9 enemies**.
  - [x] Expected Door HP Lost: 6-8 HP.
- [x] **Level Intro Text** – Display "LEVEL 1: THE AWAKENING" briefly.
- [x] **Level Transition** – Door opens → walk through → fade out → next level → fade in.
- [x] **Victory Screen** – Triggered on Level 3 completion.
  - [x] Show stats: Total Time, Enemies Killed, Door HP Remaining.
  - [x] "PLAY AGAIN" and "EXIT" buttons.

### Art & UI Polish
- [x] **Backgrounds** – made a halftone screen shader that takes the gray scale of the game and dividing it into 4 levels and apply the halftone with different scales
  - [x] Level 1: Solid Green + faint grid.
  - [x] Level 2: Solid Yellow + faint grid.
  - [x] Level 3: Solid Red + faint grid + dark vignette.
- [x] **Player Sprite** – Finalize triangle with worried expression.
- [x] **Enemy Sprites** – Assign shape + color + expression for each of 9 enemies.
  - [x] Slime: Circle + bouncy idle.
  - [x] Wobbler: Circle + sway idle.
  - [x] Grunt: Square + angry eyes.
  - [x] Runner: Triangle + lean forward.
  - [x] Jumper: Diamond + pulsing glow.
  - [x] Spinner: Hexagon + rotating.
  - [x] Tank: Square + heavy, cracks.
  - [x] Blitzer: Triangle + motion lines.
  - [x] Bomber: Circle + flickering glow.
- [x] **Door Sprite** – Add lock icon, unlock animation with particles.
- [x] **UI Overhaul** – Door health bar, Level Indicator (e.g., "Level 1/3").
- [x] **Pulse Effect** – Subtle heartbeat background pulse for Level 2 & 3.

---

## 💥 PHASE 4: JUICE & POLISH (Day 3, Hour 5 - Day 4, Hour 8)
**Goal:** Make the game FEEL good. This is what separates a 3/5 from a 5/5.

### Visual Feedback
- [x] **Screen Shake** – On door damage, enemy death, and timer hitting 0.
- [x] **Death Particles** – Colored bursts when enemies are killed (matches enemy color).
- [x] **Dash Visuals** – White streak / motion blur during dash.
- [x] **Low Timer Pulse** – Screen edge fades to red and pulses when timer < 3s.
- [x] **Door Damage Flash** – Door flashes white/red when taking damage.
- [x] **Damage Flash (Enemies)** – Enemies flash white when taking damage.
- [x] **Tank Health Bar** – Small health bar above Tank (2 segments).
- [x] **Bomber Explosion Effect** – Explosion animation + damage to nearby enemies.
- [x] **Door Unlock Particles** – Burst of particles when door opens.
- [x] **Victory Confetti** – Confetti particles on victory screen.

### Audio (Free SFX / Simple Beeps)
- [x] **Dash Sound** – "Whoosh" on dash.
- [x] **Kill Sound** – "Pop" / "Ding" on enemy death.
- [x] **Door Hit** – Heavy "Thud" when enemy touches door.
- [x] Door Open
- [x] added time
- [x] **Timer Tick** – Subtle click each second (speeds up under 3s).
- [x] **Game Over** – Explosion / fail sound.
- [x] **Victory** – Triumphant jingle.
- [x] **Enemy Spawn** – Subtle "whoosh" when enemy spawns.
- [x] **Bomber** – "Boom" sound.
- [x] UI Clicks FeedBack
- [x] **Music** – Simple loop; speed increases as timer decreases.
  - [x] Level 1: 80 BPM.
  - [x] Level 2: 120 BPM.
  - [x] Level 3: 160 BPM.

### UI/UX Polish
- [x] **Game Over Screen** – Show reason (Time ran out / Door broken).
  - [x] "Restart Level" button.
- [x] **Level Complete Screen** – "LEVEL COMPLETE!" + Stats.
  - [x] Auto-transition to next level after 2 seconds.
- [x] **Victory Screen** – "YOU SURVIVED THE COUNTDOWN!"
  - [x] Stats: Total Time, Enemies Killed, Door HP Remaining.
  - [x] "Play Again" + "Exit" buttons.
- [x] **Pause Menu** – (Optional) ESC to pause with "Resume" + "Restart" buttons.
- [x] **Button Feedback** – Hover/Click sounds on UI buttons.

---

## 🐛 PHASE 5: TESTING & BALANCING (Day 4, Hour 4-8)
**Goal:** The game is fun and beatable.

### Difficulty Tuning
- [x] **Dash Cooldown** – Test 0.4s feels responsive but not spammy.
- [x] **Level 1 Test** – New player beats it in 1-2 tries.
  - [x] If too hard: Reduce spawn rate or enemy speed.
- [x] **Level 2 Test** – Good players clear it; new players need 2-3 attempts.
- [x] **Level 3 Test** – Brutally hard but achievable for skilled players.
- [x] **Door HP Balance** – 10 HP feels fair across all levels.

### Bug Hunt
- [x] Enemies spawning inside the door.
- [x] Dash not registering on enemy contact.
- [x] Timer going negative.
- [x] Door not unlocking when target is reached (softlock).
- [x] Level transitions not working correctly.
- [x] Player can dash through walls/out of bounds.
- [x] WebGL input sticking (OnApplicationFocus fix).

### Build Test
- [x] Build for Windows (.exe) – play through all 3 levels.
- [x] Build for WebGL – test in browser (Chrome, Firefox).
- [x] Catch missing assets or null references.

---

## 🚀 PHASE 6: SUBMISSION (Day 4, Final 4 Hours)
**Goal:** Get it on Itch.io with 0 errors.

### Build Settings
- [x] **Build for WebGL** – Compression: Gzip, Memory: 256 MB.
  - [x] Run in Background: UNCHECKED (prevents stuck inputs).
  - [x] Graphics API: WebGL 2.0.
- [x] **Build for Windows** – .exe standalone.
- [x] **Build for Mac** – (Optional) .app standalone.

### Itch.io Page
- [x] **Upload Builds** – WebGL + Windows + Mac.
- [x] **Set Price** – "Free" or "Name Your Own".
- [x] **Cover Image** – Screenshot of the game with the title.
- [x] **Description** – Paste the GitHub README.
- [x] **Tags** – GMTK, Game Jam, Action, Timed.
- [x] **Gameplay Video** – Record quick 30-second gameplay video.

### GMTK Submission
- [x] **Submit Itch Link** – To the GMTK jam page.
- [x] **Include Source Code** – (Optional) Zip of Unity project.
- [x] **Final Playthrough** – Ensure no game-breaking bugs.

---

## 🎉 CELEBRATE!
- [x] **You finished a jam game.** 🎉
- [x] Post on social media.
- [x] Play other jam games.
- [x] Rest.

---
## ✅ MINIMUM VIABLE PRODUCT (MVP) TO SUBMIT:
- [x] Player moves + dashes (Space).
- [x] Enemies spawn and walk to door.
- [x] Dash kills enemies (+2s time).
- [x] Timer counts down.
- [x] Door has 10 HP.
- [x] 3 levels with color changes + different targets (30s, 60s, 80s).
- [x] Level 3 starts at 5s.
- [x] Win/Lose screens.
- [x] Build for WebGL.
