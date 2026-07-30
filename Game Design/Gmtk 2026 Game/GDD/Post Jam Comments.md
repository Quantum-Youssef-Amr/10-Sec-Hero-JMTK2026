
## Jam comments

> For how simple it is this game is super fun. Theres a really cool push and pull between having to defend the square in the middle but also needing to kill enemies fast enough to increase your timer. Also theres a lot of polish in the animations and art. Maybe would be nice to have the camera zoomed out a bit more but thats a nitpick really.

>Very simple but intuitive and fun. I could see this being a really good mobile game

>this was so satisfying to play! music, sound design, and the minimalistic visuals were all great, and if this were expanded into a roguelike it would be unstoppable! amazing work

>not a mobile gamer, but this game would go nuts on mobile . swiping would be sick as hell. Really nice polish of the movement

>The fast paced nature of it was done pretty well. but dying by the timer only really matters within the first 10 seconds. after that its just survival.  wish the countdown mechanic could be expanded a Bit more tho.

dev note: could make the enemies collision with the door take time away from the counter with the enemy value

>This game was really fun! It felt very satisfying to play. The one thing I would add is some kind of indicator as to where your base is, or limit the size of the arena or something, because there was  one point when I got lost and didn't know where my base was. Great work!

>I really loved the music! Gameplay was very enjoyable once you get the hang of it. Think it would be interesting if there was some sort of power-up mechanic if you took out multiple enemies quickly enough. Great game and great work!

>i like it alot got confused by protecting the squarer but its supper fun

dev note: could add a reason to protect the door like a small introduction to the game

dev note: instead of detecting the player with it's hitbox to transition the scene make the player click on the door to advance into the next level

dev note: game need an endless mode
dev note: some players got annoyed with the small yellow enemy in the second level

---

### 1. The Door Arrow

> *"I'll make an arrow that overlays on the screen edge pointing to the door when the player moves away."*

| Why                       | Why It Solves The Problem                                         |
| ------------------------- | ----------------------------------------------------------------- |
| **Subtle but clear**      | Players won't get lost, but it's not a giant intrusive UI element |
| **Screen-edge overlay**   | Always visible, but fades when you're close to the door           |
| **Matches your UI style** | Minimalist geometric arrow — fits the art style                   |

| How Players Will Experience It | What They'll Feel |
|--------------------------------|-------------------|
| They move away from the door | Small arrow appears on the edge of the screen |
| They turn toward the door | Arrow fades or points correctly |
| They get close to the door | Arrow disappears completely |

**Implementation Note:** Check the angle between the player and the door. If the player is facing away or the door is behind them, show the arrow on the edge of the screen in the direction of the door.

---

### 2. Mobile Controls (Joystick + Dash)

> *"for mobile, I'll make a joystick that the player can move with. in the same time, if the joystick delta was high like 4 or something, I will call it a dash."*

| Why                          | Why It Solves The Problem                              |
| ---------------------------- | ------------------------------------------------------ |
| **One input, two actions**   | Move AND dash from the same control — no extra buttons |
| **Joystick delta detection** | Drag fast = dash, drag slow = move. Simple, intuitive. |
| **Fits the game's speed**    | The game is fast, so fast drag = dash feels natural    |
| **Perfect for mobile**       | No clutter, one thumb controls everything              |

| Player Action | Result |
|---------------|--------|
| Slow drag on joystick | Normal movement |
| Fast drag (delta > 4) | Dash in that direction |
| Tap anywhere | Could also dash (optional) |

**Implementation Note:** Track `joystick.delta.magnitude`. If it exceeds a threshold (e.g., 4 units per frame), trigger a dash in the joystick's direction.

---

### 3. No-Spawn Bug Fix

> *"I'll move the level begin trigger from the level intro animation to a coroutine that waits until the animation stops playing to activate the level."*

| Why                      | Why It Solves The Problem                                                             |
| ------------------------ | ------------------------------------------------------------------------------------- |
| **Timing is everything** | The bug likely happens because the spawner activates BEFORE the scene is fully loaded |
| **Coroutine waits**      | It ensures the intro animation finishes AND the scene is ready BEFORE enemies spawn   |
| **Clean fix**            | No hacky delays or frame skips — just a proper coroutine                              |

---

# Rogue like Design

30 upgrades, 4 power tiers, color-coded, showing 3 at a time between waves.
---

##  THE SYSTEM AT A GLANCE

| Component            | Specification                                                           |
| -------------------- | ----------------------------------------------------------------------- |
| **Total Upgrades**   | 30                                                                      |
| **Power Tiers**      | 4 (Tier 1–4)                                                            |
| **Colors**           | Tier 1: 🟢 Green / Tier 2: 🔵 Blue / Tier 3: 🟡 Yellow / Tier 4: 🔴 Red |
| **Shown Per Wave**   | 3 random upgrades (different tiers)                                     |
| **Unlock Condition** | Must have at least 1 upgrade from previous tier                         |
| **Rarity Scaling**   | Higher tiers appear less often early on                                 |

---

## THE 4 POWER TIERS

| Tier | Color | Rarity | Power Level | Example Upgrade |
|------|-------|--------|-------------|-----------------|
| **1** | 🟢 Green | Common | Small boost | Dash Range +0.5 |
| **2** | 🔵 Blue | Uncommon | Medium boost | Dash Range +1.0 |
| **3** | 🟡 Yellow | Rare | Big boost | Dash Range +1.5 |
| **4** | 🔴 Red | Epic | Game-changer | Dash Range +2.0 + cooldown reduction |

---

## 📋 THE 30 UPGRADES

### TIER 1 — Green (8 Upgrades)

| # | Name | Effect | Description |
|---|------|--------|-------------|
| 1 | **Sharp Dash** | Dash Range +0.5 | Dash goes a bit further |
| 2 | **Quick Feet** | Movement Speed +0.5 | Move slightly faster |
| 3 | **Time Keeper** | Kill Reward +0.5s | Enemies give a bit more time |
| 4 | **Tough Door** | Door HP +1 | Door takes one more hit |
| 5 | **Combo Start** | Combo timer +0.5s | Easier to maintain combo |
| 6 | **Slow Start** | Enemies move 5% slower | More time to react |
| 7 | **Starter Boost** | Timer starts +2s | Start with extra time |
| 8 | **Heal Touch** | Door heals 1 HP per 5 kills | Slow door recovery |

---

### TIER 2 — Blue (8 Upgrades)

| # | Name | Effect | Description |
|---|------|--------|-------------|
| 9 | **Long Dash** | Dash Range +1.0 | Dash goes much further |
| 10 | **Swift Steps** | Movement Speed +1.0 | Move noticeably faster |
| 11 | **Time Master** | Kill Reward +1.0s | Enemies give more time |
| 12 | **Reinforced Door** | Door HP +2 | Door takes two more hits |
| 13 | **Combo Pro** | Combo timer +1.0s | Maintain combo longer |
| 14 | **Slow Aura** | Enemies move 10% slower | More control in fights |
| 15 | **Lucky Start** | Timer starts +4s | Start with a solid buffer |
| 16 | **Auto Heal** | Door heals 1 HP per 3 kills | Faster door recovery |

---

### TIER 3 — Yellow (7 Upgrades)

| # | Name | Effect | Description |
|---|------|--------|-------------|
| 17 | **Mega Dash** | Dash Range +1.5 | Dash goes very far |
| 18 | **Lightning Speed** | Movement Speed +1.5 | Move very fast |
| 19 | **Time Lord** | Kill Reward +1.5s | Enemies give lots of time |
| 20 | **Fortified Door** | Door HP +3 | Door takes three more hits |
| 21 | **Combo King** | Combo timer +1.5s | Easy to keep combo going |
| 22 | **Slow Zone** | Enemies move 15% slower | Enemies crawl toward you |
| 23 | **Power Start** | Timer starts +6s | Huge starting time |

---

### TIER 4 — Red (7 Upgrades)

| # | Name | Effect | Description |
|---|------|--------|-------------|
| 24 | **Phantom Dash** | Dash Range +2.0 + Cooldown -0.1s | Dash is insane |
| 25 | **Flash Speed** | Movement Speed +2.0 | You are lightning |
| 26 | **Time God** | Kill Reward +2.0s | Enemies give massive time |
| 27 | **Indestructible** | Door HP +5 | Door is incredibly tough |
| 28 | **Combo Legend** | Combo timer +2.0s | Combo never drops |
| 29 | **Slow World** | Enemies move 20% slower | Enemies barely move |
| 30 | **Godly Start** | Timer starts +10s | Start with 10 extra seconds |

---

## 🎨 UI DESIGN: UPGRADE SCREEN

```
┌─────────────────────────────────────────────────┐
│                                                 │
│          🔥  WAVE COMPLETE!                    │
│                                                 │
│          Choose Your Upgrade:                   │
│                                                 │
│  ┌──────────────────────────────────────────┐   │
│  │  🟢 Time Keeper (Tier 1)                │   │
│  │  Kill Reward +0.5s                      │   │
│  │  (Common)                               │   │
│  └──────────────────────────────────────────┘   │
│                                                 │
│  ┌──────────────────────────────────────────┐   │
│  │  🔵 Time Master (Tier 2)                │   │
│  │  Kill Reward +1.0s                      │   │
│  │  (Uncommon)                             │   │
│  └──────────────────────────────────────────┘   │
│                                                 │
│  ┌──────────────────────────────────────────┐   │
│  │  🟡 Time Lord (Tier 3)                  │   │
│  │  Kill Reward +1.5s                      │   │
│  │  (Rare)                                 │   │
│  └──────────────────────────────────────────┘   │
│                                                 │
│  [ CONTINUE ]                                   │
│                                                 │
└─────────────────────────────────────────────────┘
```

---

## 📱 MOBILE-FRIENDLY UPGRADE CARDS

| Element | Specification |
|---------|---------------|
| **Size** | Large enough to tap with thumb |
| **Color** | Tier color (Green/Blue/Yellow/Red) |
| **Icon** | Simple emoji or geometric shape |
| **Name** | Short, punchy |
| **Description** | One line of text |
| **Tier Badge** | "Common / Uncommon / Rare / Epic" |
| **Rarity Glow** | Subtle glow based on tier |

---

## 🎯 SPAWNING LOGIC

### How Upgrades Are Chosen

| Rule | Description |
|------|-------------|
| **Random Selection** | 3 random upgrades from your unlocked pool |
| **Tier Mix** | At least 1 common, can include higher tiers |
| **Weighted Rarity** | Tier 1: 50%, Tier 2: 30%, Tier 3: 15%, Tier 4: 5% |
| **No Duplicates** | You can't get the same upgrade twice in one run |

### Example Selection

```
Wave 1:
  - [Tier 1] Sharp Dash
  - [Tier 1] Tough Door
  - [Tier 1] Quick Feet

Wave 5:
  - [Tier 1] Time Keeper
  - [Tier 2] Long Dash
  - [Tier 2] Reinforced Door

Wave 10:
  - [Tier 2] Time Master
  - [Tier 3] Mega Dash
  - [Tier 3] Slow Zone

Wave 15:
  - [Tier 3] Time Lord
  - [Tier 3] Fortified Door
  - [Tier 4] Time God
```

---

## 📊 UPGRADE STATS SUMMARY

| Tier | Color     | Rarity   | Count | Power Level                   |
| ---- | --------- | -------- | ----- | ----------------------------- |
| 1    | 🟢 Green  | Common   | 8     | +0.5 / +1 HP / +2s            |
| 2    | 🔵 Blue   | Uncommon | 8     | +1.0 / +2 HP / +4s            |
| 3    | 🟡 Yellow | Rare     | 7     | +1.5 / +3 HP / +6s            |
| 4    | 🔴 Red    | Epic     | 7     | +2.0 / +5 HP / +10s / Special |


# more upgrades ideas

## 🧠 THE NEW UPGRADE PHILOSOPHY

| Tier | Role | What It Feels Like |
|------|------|---------------------|
| 🟢 Tier 1 | **Foundation** | Small, helpful, "nice to have" |
| 🔵 Tier 2 | **Enhancement** | Makes something *feel* better |
| 🟡 Tier 3 | **Transformation** | Changes how you play |

---

### 🟢 TIER 1 — Foundation (Common)
*Simple, helpful upgrades that smooth out the early game.*

| # | Name | Effect |
|---|------|--------|
| 1 | **Quick Start** | Start each wave with +3 seconds on the timer |
| 2 | **Light Feet** | Move 10% faster |
| 3 | **Long Reach** | Dash range +20% |
| 4 | **Second Wind** | Door regenerates 1 HP every 10 kills |
| 5 | **Combo Buffer** | Combo timer lasts 1 second longer |
| 6 | **Early Bird** | Enemies spawn 10% slower for the first wave |
| 7 | **Sturdy Frame** | Door takes 1 less damage from enemies |
| 8 | **Bonus Time** | First kill of each wave gives +2 extra seconds |

---

### 🔵 TIER 2 — Enhancement (Uncommon)
*Upgrades that make your abilities feel noticeably better.*

| # | Name | Effect |
|---|------|--------|
| 9 | **Dash Burst** | Dashing creates a small shockwave that pushes enemies back |
| 10 | **Life Steal** | Every 5 kills restores 1 HP to the door |
| 11 | **Quick Reflexes** | Dash cooldown reduced by 0.15 seconds |
| 12 | **Momentum** | Moving faster increases your dash range (up to +50%) |
| 13 | **Tough Skin** | Enemies deal 1 less damage to you (door HP loss reduced) |
| 14 | **Scavenger** | Enemies drop small time orbs (+0.5s) when killed |
| 15 | **Focused Strike** | Combo kills give +1 extra second |
| 16 | **Vampire Dash** | Dashing through enemies heals the door by 1 HP per enemy hit |

---

### 🟡 TIER 3 — Transformation (Rare)
*Upgrades that change how you approach the game.*

| # | Name | Effect |
|---|------|--------|
| 17 | **Time Freeze** | Timer pauses for 2 seconds when you kill an enemy |
| 18 | **Chain Reaction** | Killing an enemy damages nearby enemies (small explosion) |
| 19 | **Overdrive** | When timer is below 5 seconds, dash range and speed double |
| 20 | **Guardian Shield** | Door has a shield that absorbs 1 hit, regenerates every 15 kills |
| 21 | **Rampage** | Every 5 kills in a row = next wave has 1 less enemy |
| 22 | **Phantom Dash** | Dash leaves behind a decoy that distracts enemies for 2 seconds |
| 23 | **Time Bank** | Unused time from a wave carries over to the next wave as bonus time |

---

### 🔴 TIER 4 — Game-Breaker (Epic)
*Upgrades that make you feel unstoppable (but are rare).*

| # | Name | Effect |
|---|------|--------|
| 24 | **Infinite Dash** | Dash cooldown is removed — dash whenever you want |
| 25 | **Time Storm** | Killing an enemy freezes the timer for 3 seconds |
| 26 | **Door Fortress** | Door becomes invincible for 5 seconds after taking damage |
| 27 | **Double Trouble** | Every enemy killed counts as 2 kills for wave progression |
| 28 | **Eternal Combo** | Combo never resets — it only grows |
| 29 | **Dark Aura** | Enemies near the door move 30% slower |
| 30 | **God Mode** | Timer cannot drop below 3 seconds for the next 3 waves |
