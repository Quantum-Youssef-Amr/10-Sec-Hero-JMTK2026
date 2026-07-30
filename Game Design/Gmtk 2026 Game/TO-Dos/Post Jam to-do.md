
---

**Game:** 10 Sec Hero  
**Status:** Planning Phase  
**Goal:** Transform jam game into a polished, endless mobile experience  

---

## ⚡ PHASE 0: CRITICAL BUG FIXES (2-3 hours)

**Goal:** Make the game stable and playable for everyone.

- [ ] **Fix no-spawn bug (WebGL)**
  - [ ] Move level start trigger from animation to coroutine
  - [ ] Add fallback: if no enemies spawn in 3 seconds, force-respawn
  - [ ] Reset spawner state on level restart
- [ ] **Fix WebGL input sticking**
  - [ ] Add `OnApplicationFocus(false)` check to release velocity
  - [ ] Ensure keys don't stick when tab loses focus
- [ ] **Fix door HP visual glitch**
  - [ ] Ensure all 10 segments update correctly on damage
  - [ ] Test with multiple hits in quick succession

**Checklist:**
- [ ] All bugs fixed and verified
- [ ] Tested on WebGL build
- [ ] Tested on Windows build

---

## 📱 PHASE 1: MOBILE CONTROLS (5-6 hours)

**Goal:** Make the game playable and fun on touch devices.

- [ ] **Add touch joystick**
  - [ ] Left side of screen for movement
  - [ ] Visual joystick with thumb tracking
  - [ ] Smooth, responsive movement
- [ ] **Implement dash via joystick**
  - [ ] Fast flick on joystick = dash
  - [ ] Set delta threshold (~4 units per frame)
  - [ ] Visual feedback for dash activation
- [ ] **Alternative dash controls**
  - [ ] Optional tap on right side = dash
  - [ ] Double-tap for dash (if needed)
- [ ] **Mobile UI scaling**
  - [ ] Scale all UI elements for phone screens
  - [ ] Test on different screen sizes (portrait/landscape)

**Checklist:**
- [ ] Joystick works smoothly
- [ ] Dash triggers correctly
- [ ] UI scales properly
- [ ] Tested on Android (real device/emulator)

---

## 🏗️ PHASE 2: NEW ENDLESS GAME LOOP (10-12 hours)

**Goal:** Replace 3-level system with an infinite survival mode.

- [ ] **Remove level system**
  - [ ] Remove 3-level logic and transitions
  - [ ] Remove level-specific colors/targets
  - [ ] Keep halftone shader (it stays)
- [ ] **Add wave system**
  - [ ] Waves progress: 5 enemies → 6 → 8 → 10 → 12 → scales up
  - [ ] Progress bar showing wave completion
  - [ ] Wave number display ("Wave 7")
- [ ] **Add endless survival logic**
  - [ ] No level end — infinite waves
  - [ ] Enemies spawn faster as waves progress
  - [ ] More enemies per wave as you advance
- [ ] **Timer carries between waves**
  - [ ] Timer pauses on upgrade screen
  - [ ] Timer resumes when new wave starts
  - [ ] No timer reset between waves
- [ ] **Game Over conditions**
  - [ ] Timer hits 0 = game over
  - [ ] Door HP hits 0 = game over
  - [ ] Show wave reached and score

**Checklist:**
- [ ] Waves progress correctly
- [ ] Timer carries between waves
- [ ] Enemies scale with difficulty
- [ ] Game Over triggers correctly
- [ ] Tested on WebGL + Android

---

## 🌟 PHASE 3: UPGRADE SYSTEM (8-10 hours)

**Goal:** Add 30 upgrades in 4 power tiers, shown between waves.

- [ ] **Create upgrade data structure**
  - [ ] ScriptableObject for each upgrade
  - [ ] Fields: Name, Description, Tier, Color, Icon, Effect
- [ ] **Design 30 upgrades** [[Post Jam Comments]]
  - [ ] Tier 1 🟢: 16 upgrades (common)
  - [ ] Tier 2 🔵: 16 upgrades (uncommon)
  - [ ] Tier 3 🟡: 14 upgrades (rare)
  - [ ] Tier 4 🔴: 14 upgrades (epic)
- [ ] **Build upgrade selection UI**
  - [ ] 3 cards shown per wave
  - [ ] Color-coded by tier
  - [ ] Tap to select
- [ ] **Implement spawn logic**
  - [ ] Weighted random: 50/30/15/5%
  - [ ] No duplicates in same run
  - [ ] Ensure at least 1 common per wave
- [ ] **Apply upgrades to gameplay**
  - [ ] Dash range, speed, cooldown
  - [ ] Kill reward, timer start
  - [ ] Door HP, door heal
  - [ ] Combo timer, enemy slow

**Checklist:**
- [ ] All 60 upgrades defined and coded
- [ ] UI displays 3 options between waves
- [ ] Upgrades apply correctly to gameplay
- [ ] Balance feels fun (not too easy/hard)

---

## 🎨 PHASE 4: UI & POLISH (6-8 hours)

**Goal:** Add visual clarity, feedback, and quality-of-life improvements.

- [ ] **Arrow indicator for door**
  - [ ] Screen-edge arrow pointing to door
  - [ ] Fades when player is close
  - [ ] Matches game's minimal art style
- [ ] **Tutorial / Intro**
  - [ ] Quick explanation: "Protect the door! Dash into enemies to add time!"
  - [ ] Show once on first play
- [ ] **Score system**
  - [ ] Points per kill
  - [ ] Combo bonuses
  - [ ] Wave completion bonus
  - [ ] Display score during run
- [ ] **High score tracking**
  - [ ] Best wave reached
  - [ ] Best score
  - [ ] Save locally (PlayerPrefs)
- [ ] **Visual feedback**
  - [ ] Timer "tick" animation (subtle pulse)
  - [ ] Combo counter visual pop
  - [ ] Door unlock glow wave effect
- [ ] **Audio improvements**
  - [ ] More percussive variety (3-4 sounds)
  - [ ] Kill sound variation
  - [ ] Master volume sliders

**Checklist:**
- [ ] All UI elements added and polished
- [ ] Tutorial works correctly
- [ ] Score tracks and displays
- [ ] High score saves and loads
- [ ] Visual/audio feedback feels juicy

---

## 🧪 PHASE 5: TESTING & BALANCING (4-6 hours)

**Goal:** Ensure the game is fun, balanced, and polished.

- [ ] **Difficulty tuning**
  - [ ] Wave scaling: enemies per wave, speed, spawn rate
  - [ ] Timer rewards feel fair
  - [ ] Door HP feels balanced
- [ ] **Upgrade balance**
  - [ ] No single upgrade is overpowered
  - [ ] No upgrade is useless
  - [ ] All tiers feel worth chasing
- [ ] **Bug hunt**
  - [ ] Enemies spawning inside door
  - [ ] Timer going negative
  - [ ] Upgrades not applying
  - [ ] UI glitches
- [ ] **Playtest with friends**
  - [ ] 5-10 playtesters
  - [ ] Collect feedback
  - [ ] Iterate based on feedback
- [ ] **Build testing**
  - [ ] WebGL build (Chrome, Firefox)
  - [ ] Windows build
  - [ ] Android build (real device)

**Checklist:**
- [ ] Difficulty feels challenging but fair
- [ ] Upgrades feel balanced
- [ ] No major bugs found
- [ ] Testers enjoyed the game
- [ ] All builds work

---

## 🚀 PHASE 6: RELEASE & MARKETING (2-3 hours)

**Goal:** Share your improved game with the world.

- [ ] **Itch.io page update**
  - [ ] New screenshots (showing endless mode, upgrades, mobile)
  - [ ] Updated description
  - [ ] New trailer/gameplay video (30 sec)
  - [ ] Android APK download
- [ ] **Social media**
  - [ ] Twitter/X: "10 Sec Hero is now endless + mobile!"
  - [ ] LinkedIn: "Post-jam update: from 3 levels to endless waves"
  - [ ] TikTok: 15-second gameplay clip
- [ ] **Release notes**
  - [ ] Write patch notes
  - [ ] Thank players for feedback
  - [ ] Share the journey

**Checklist:**
- [ ] Itch.io page updated
- [ ] Social media posts scheduled
- [ ] Release notes written
- [ ] APK uploaded
