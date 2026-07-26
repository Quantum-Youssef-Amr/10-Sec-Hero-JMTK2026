## 1. DESIGN PHILOSOPHY

Movement in *Ten Second Hero* is **positional, tactical, and responsive**. The player must constantly balance two priorities: chasing enemies to kill them and returning to defend the door. Movement should feel smooth and precise, never floaty or sluggish.

**Core Principles:**
- **Precision over speed.** The player needs to line up dashes accurately.
- **Responsiveness.** Inputs register instantly. No acceleration, no momentum.
- **Clarity.** The player always knows where they are and where they're going.

---

## 2. PLAYER MOVEMENT

### 2.1 Walking

| Property          | Value                       |
| ----------------- | --------------------------- |
| Input             | WASD / Arrow Keys           |
| Speed             | 5 units/second              |
| Acceleration      | Instant (no ramp-up)        |
| Deceleration      | Instant (no slide)          |
| Diagonal Movement | Allowed (normalized vector) |

**Implementation Notes:**
- Use `Rigidbody2D.velocity` for movement (not transform.position).
- Set `Rigidbody2D.gravityScale = 0` (top-down 2D).
- Clamp velocity to max speed to prevent diagonal speed boost.

**Code Snippet:**
```csharp
Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
rb.velocity = moveInput * moveSpeed;
```

---

### 2.2 Dash Attack

| Property | Value |
|----------|-------|
| Input | Space / Left Shift |
| Cooldown | 0.4 seconds |
| Dash Distance | 3 units |
| Dash Duration | 0.1 seconds (instant teleport-style) |
| Damage | Kills any enemy on contact |
| Invincibility | None (dash is not i-frames) |
| Direction | Based on current movement input |

**Implementation Notes:**
- Dash in the direction the player is currently moving.
- If no movement input, dash in the last facing direction.
- Use `Transform.Translate` or `Rigidbody2D.MovePosition` for the dash.
- During dash, movement input is ignored (brief lockout).
- Track dash cooldown with `Time.time` or a coroutine.

**Dash States:**
| State | Duration | Behavior |
| Idle | N/A | Player can walk and dash |
| Dashing | 0.1s | Player moves instantly, cannot input move |
| Cooldown | 0.4s | Player can walk, cannot dash |

**Code Snippet:**
```csharp
void Update() {
    // Dash input
    if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDashTime + dashCooldown) {
        Dash();
    }
}

void Dash() {
    lastDashTime = Time.time;
    Vector2 dashDirection = moveInput != Vector2.zero ? moveInput : lastFacingDirection;
    transform.Translate(dashDirection * dashDistance);
    // Check for enemy collision here
}
```

---

## 3. VISUAL FEEDBACK

Movement must **feel** good, not just function. These are the visual cues we add to communicate the player's state:

| State         | Visual Feedback                                               |
| ------------- | ------------------------------------------------------------- |
| Walking       | Player sprite moves smoothly. No extra effects.               |
| Dashing       | White trail, Screen slightly zooms out.                       |
| Dash Cooldown | Player flashes briefly. Small "charging" indicator near feet. |
| Kill on Dash  | Enemy pops with particles. Screen shakes slightly.            |

---

## 4. BALANCING & TUNING

### 4.1 Walk Speed vs Dash Distance

| Scenario | Walk Speed | Dash Distance | Result |
|----------|------------|---------------|--------|
| Too fast | 8+ | 5+ | Game feels chaotic, no precision |
| Too slow | 3- | 2- | Game feels sluggish, frustrating |
| **Our Target** | **5** | **3** | Balanced, responsive, tactical |

### 4.2 Dash Cooldown

| Value | Feel |
|-------|------|
| 0.2s | Too fast. Player spams dash, no strategy. |
| 0.3s | Okay. Still a bit spammy. |
| **0.4s** | **Sweet spot.** One kill per dash, need to choose targets. |
| 0.5s | Slightly slow. Feels punishing on misses. |
| 0.6s+ | Too slow. Frustrating. |

---

## 5. PLAYER GAMEPLAY FLOW

### Without Movement Input (Idle)
- Player stands still.
- No drift, no slide.
- Dashes in last facing direction.

### With Movement Input (Walking)
- Player moves at constant speed.
- Can change direction instantly.
- Can dash at any time (unless on cooldown).

### During Dash (Lockout)
- Player teleports 3 units in direction.
- Cannot move until dash completes.
- Enemies in path die instantly.
- After dash, cooldown begins.

### During Cooldown
- Player walks normally.
- Dash input is ignored.
- Visual indicator shows cooldown status.

---

## 7. INPUT MAP

| Action | Primary | Secondary | Platform |
|--------|---------|-----------|----------|
| Move Up | W | Up Arrow | Keyboard |
| Move Down | S | Down Arrow | Keyboard |
| Move Left | A | Left Arrow | Keyboard |
| Move Right | D | Right Arrow | Keyboard |
| Dash | Space | Left Shift | Keyboard |

**Controller Support:** Not planned for jam scope. Keyboard only.

---

## 8. TECH SPECS

### Scripts Required

```
Assets/Scripts/Player/
├── PlayerMovement.cs    // Walking input, velocity control
├── PlayerDash.cs        // Dash logic, cooldown, direction
└── PlayerController.cs  // Combines movement + dash (or separate)
```

### Dependencies

- `Rigidbody2D`
- `Transform`
- `Time` (for cooldown)
- `Input` (for keyboard)

### Collision Layers

| Layer | Objects |
|-------|---------|
| Player | The player character |
| Enemy | All enemies |
| Door | The doorway / goal |

Dash hit detection uses `OverlapCircle` or `OnCollisionEnter2D` with a trigger collider during dash.
