### when enemies take damage they will flash there color but white-ish
## 🔥 COMPLETE ENEMY DESIGN (9 TOTAL)

### Level 1 Enemies (Green Background)

| # | Name | Hits | Speed | Reward | Behavior |
|---|------|------|-------|--------|----------|
| 1 | **Slime** | 1 | Slow (1.5) | +2s | Straight toward door |
| 2 | **Wobbler** | 1 | Slow (1.5) | +2s | Zig-zag toward door |
| 3 | **Grunt** | 1 | Medium (2.5) | +2s | Straight toward door |

**Level 1 Feel:** Low pressure. Learn the dash mechanic. Door should take minimal damage.

---

### Level 2 Enemies (Yellow Background)

| # | Name | Hits | Speed | Reward | Behavior |
|---|------|------|-------|--------|----------|
| 4 | **Runner** | 1 | Fast (4.0) | +2s | Straight toward door |
| 5 | **Jumper** | 1 | Fast (3.5) | +2s | Teleports every 2 seconds toward door |
| 6 | **Spinner** | 1 | Medium (2.5) | +2s | Moves in circular path toward door |

**Level 2 Feel:** Pressure increases. Enemies are faster and less predictable. Door health becomes a real concern.

---

### Level 3 Enemies (Red Background)

| # | Name | Hits | Speed | Reward | Behavior |
|---|------|------|-------|--------|----------|
| 7 | **Tank** | **2** | Slow (1.5) | +4s | Straight toward door. Sprite flashes after first hit. |
| 8 | **Blitzer** | 1 | Very Fast (5.0) | +2s | Straight toward door. Must predict its path. |
| 9 | **Bomber** | 1 | Medium (2.5) | +3s | Moves toward door. Explodes on death, damaging nearby enemies. |

**Level 3 Feel:** Chaos. Tank demands commitment. Blitzer requires precision. Bomber adds crowd control. Perfect climax.

---

## 📊 ENEMY UNLOCK & SPAWN RATES

| Timer Value | Enemy Types Active | Spawn Rate | Max Enemies |
|-------------|-------------------|------------|-------------|
| 10-14s | Slime, Wobbler, Grunt | Every 3s | 2 |
| 15-19s | Slime, Wobbler, Grunt, Runner | Every 2.5s | 3 |
| 20-24s | All Level 1 + Runner, Jumper | Every 2s | 3 |
| 25-29s | All Level 1 + Jumper, Spinner | Every 1.8s | 4 |
| 30-34s | All Level 1 + Level 2 (except Spinner) | Every 1.5s | 4 |
| 35-39s | All Level 1 + All Level 2 | Every 1.3s | 5 |
| 40s+ | **All enemies (including Level 3)** | Every 1s | 6 |

**Level Unlocks:**
- Level 1: Timer target = 20s. Enemies 1-3 active.
- Level 2: Timer target = 30s. Enemies 1-6 active.
- Level 3: Timer target = 40s. **All 9 enemies active.**

---

## 🎨 VISUAL ENEMY IDENTIFICATION

Players need to know what they're fighting at a glance.

| Enemy | Shape | Color | Visual Cue |
|-------|-------|-------|------------|
| Slime | Circle | Light Green | Bouncy idle animation |
| Wobbler | Circle | Teal | Sways side to side |
| Grunt | Square | Orange | Angry eyes |
| Runner | Triangle | Yellow | Lean forward (speed pose) |
| Jumper | Diamond | Purple | Pulsing glow (teleport charge) |
| Spinner | Hexagon | Pink | Rotating constantly |
| Tank | Square | Dark Red | Heavy, cracks on sprite |
| Blitzer | Triangle | Bright Red | Motion lines trailing |
| Bomber | Circle | Black/Orange | Flickering glow |

**Art Time:** ~2 hours total. All shapes + simple expressions.

---

## ✅ FINAL ENEMY SYSTEM SPECS

| System | Specification |
|--------|---------------|
| Enemy Count | 9 total (3 per level) |
| Enemy HP | Slimes/Runners/Bombers = 1 hit. Tank = 2 hits. |
| Enemy Speed | 1.5 - 5.0 units/sec (scales with type) |
| Reward | +2s (standard), +3s (Bomber), +4s (Tank) |
| Spawn Rate | 1-3 seconds, scales with timer value |
| Max Enemies | 2-6, scales with timer value |
| Behavior | Move toward door (with variations) |
| Unlock | Based on timer value, not level |

---

## 🔍 CRITICAL QUESTIONS BEFORE LOCKING

**1. Does the Tank's 2-hit HP feel good with a 0.4s dash cooldown?**

- First hit: Tank flashes red, slows down slightly.
- Second hit: Tank dies, +4s reward.
- Time to kill: ~0.8-1.2 seconds. This is acceptable for Level 3.

**2. How does the player know an enemy takes 2 hits?**

- Visual: Tank is visually larger and darker.
- Feedback: First hit makes it flash red and crack.
- UI: Optional health bar above Tank (could add polish time).

**3. What if a Bomber explodes and kills the door?**

- Bomber damages enemies, not the door.
- Explosion radius = 2 units. Door is safe.
- This rewards smart play: kill Bomber near other enemies to clear the field.
