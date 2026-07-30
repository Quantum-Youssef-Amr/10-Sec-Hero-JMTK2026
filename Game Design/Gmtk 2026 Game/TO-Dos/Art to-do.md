Here's your **complete Art To-Do List** organized by category. All assets are minimalist geometric shapes with expressive features, matching the GDD specs.

---

## 🎨 ART TO-DO LIST: TEN SECOND HERO

---

## 1. PLAYER ART (1 Asset)

| Asset               | Description                                             | Specs                                                |
| ------------------- | ------------------------------------------------------- | ---------------------------------------------------- |
| **Player Sprite**   | Triangle shape with worried expression. White color.    | Triangle, White, 2 tiny eyes (worried), size ~1 unit |
| **Player Variants** | Optional: Different expressions (panic, focused, happy) | Same shape, different eyes                           |


**Implementation Notes:**
- Create using Unity Sprite Editor or external tool (Aseprite, Photoshop).
- Triangle points upward (facing direction).
- Eyes are two small dots/circles.
- Worried expression: eyebrows angled inward, slightly open mouth (optional).
- Rotates to face movement direction via script.

---

## 2. ENEMY ART (9 Assets)

### Level 1 Enemies (Green Background)

| #   | Name        | Shape  | Color                 | Size      | Expression/Visual Cue                  | Priority      |
| --- | ----------- | ------ | --------------------- | --------- | -------------------------------------- | ------------- |
| 1   | **Slime**   | Circle | Light Green (#7BCF7B) | 0.8 units | Bouncy idle animation (squash/stretch) | **Must Have** |
| 2   | **Wobbler** | Circle | Teal (#4DB8A8)        | 0.8 units | Sways side to side                     | **Must Have** |
| 3   | **Grunt**   | Square | Orange (#F5A623)      | 0.8 units | Angry eyes (angled eyebrows)           | **Must Have** |

### Level 2 Enemies (Yellow Background)

| #   | Name        | Shape    | Color            | Size      | Expression/Visual Cue          | Priority      |
| --- | ----------- | -------- | ---------------- | --------- | ------------------------------ | ------------- |
| 4   | **Runner**  | Triangle | Yellow (#F8E71C) | 0.8 units | Lean forward (speed pose)      | **Must Have** |
| 5   | **Jumper**  | Diamond  | Purple (#9B59B6) | 0.8 units | Pulsing glow (teleport charge) | **Must Have** |
| 6   | **Spinner** | Hexagon  | Pink (#FF6B9D)   | 0.8 units | Rotating constantly            | **Must Have** |

### Level 3 Enemies (Red Background)

| #   | Name        | Shape    | Color                            | Size      | Expression/Visual Cue                              | Priority      |
| --- | ----------- | -------- | -------------------------------- | --------- | -------------------------------------------------- | ------------- |
| 7   | **Tank**    | Square   | Dark Red (#C0392B)               | 1.2 units | Heavy, cracks on sprite. Flash white on first hit. | **Must Have** |
| 8   | **Blitzer** | Triangle | Bright Red (#E74C3C)             | 0.8 units | Motion lines trailing behind                       | **Must Have** |
| 9   | **Bomber**  | Circle   | Black/Orange (#2C3E50 + #E67E22) | 0.8 units | Flickering glow (pulsing)                          | **Must Have** |

**Implementation Notes:**
- All enemies created from Unity primitives (Sprite.Create from simple shapes).
- Add eyes/expressions using child GameObjects or sprite layering.
- Colors match the level backgrounds for cohesion.
- Tank is 1.5x larger than other enemies to signal "tank" status.

---

## 3. DOOR ART (1 Asset with Variants)

| Asset | Description | Specs | Priority |
|-------|-------------|-------|----------|
| **Door Base** | Rectangle with glowing border | Rectangle, size ~2x3 units | **Must Have** |
| **Door Lock Icon** | Simple lock icon on door | Lock shape, white/color | **Must Have** |
| **Door Unlock Effect** | Particles burst when unlocked | Colorful sparkles | Should Have |
| **Door Glow Variants** | Changes color per level | Green → Yellow → Red | **Must Have** |
| **Door Open Animation** | Slides up/down or fades open | Smooth transition | **Must Have** |

**Implementation Notes:**
- Door is centered at bottom of screen.
- Glow color matches level (Level 1: Green, Level 2: Yellow, Level 3: Red).
- Lock icon changes to unlocked state when target reached.
- Unlock animation: particles burst, door slides up, glow intensifies.

---

## 4. UI ART (Multiple Assets)

| Asset | Description | Specs | Priority |
|-------|-------------|-------|----------|
| **Timer Text** | Large number, top-center | Font: Bold, size ~60, White/Red | **Must Have** |
| **Timer Background** | Semi-transparent panel behind timer | Dark panel with rounded corners | Should Have |
| **Door Health UI** | 10 small squares or health bar | 10 squares, Green → Red as HP drops | **Must Have** |
| **Door Health Background** | Dark panel behind health | Rounded corners, semi-transparent | Should Have |
| **Level Indicator** | "Level 1/3" text | Font: Medium, top-left or bottom | **Must Have** |
| **Enemy Count UI** | "Enemies: X" (optional) | Font: Small, bottom | Nice to Have |
| **Game Over Overlay** | Dark overlay + text | Dark panel, 50% opacity | **Must Have** |
| **Game Over Text** | "GAME OVER" + reason | Font: Large, Red | **Must Have** |
| **Level Complete Overlay** | Dark overlay + text | Dark panel, 50% opacity | **Must Have** |
| **Level Complete Text** | "LEVEL COMPLETE!" | Font: Large, Gold/Yellow | **Must Have** |
| **Victory Overlay** | Dark overlay + text + confetti | Dark panel, 50% opacity + particles | **Must Have** |
| **Victory Text** | "YOU SURVIVED THE COUNTDOWN!" | Font: Large, Gold | **Must Have** |
| **Stat Display** | Total Time, Kills, Door HP | Font: Medium, White | **Must Have** |
| **Buttons** | Restart, Play Again, Exit | Rounded rectangles, hover effect | **Must Have** |
| **Button Text** | "RESTART", "PLAY AGAIN", "EXIT" | Font: Medium, White | **Must Have** |

---

## 5. BACKGROUND ART (3 Assets)

| Asset | Description | Specs | Priority |
|-------|-------------|-------|----------|
| **Level 1 Background** | Solid Green + faint grid | #2E7D32 (dark green) + faint lines | **Must Have** |
| **Level 2 Background** | Solid Yellow + faint grid | #F9A825 (dark yellow) + faint lines | **Must Have** |
| **Level 3 Background** | Solid Red + faint grid + dark vignette | #C62828 (dark red) + vignette edges | **Must Have** |
| **Grid Pattern** | Faint grid overlay | Thin lines, 10% opacity | Should Have |
| **Vignette (Level 3)** | Dark edges fading to center | Radial gradient, black, 30% opacity | Should Have |

**Implementation Notes:**
- Use Camera.backgroundColor for solid colors.
- Grid pattern as a separate GameObject or shader.
- Vignette as a UI overlay or separate sprite.

---

## 6. PARTICLE EFFECTS (Multiple)

| Effect | Description | Specs | Priority |
|--------|-------------|-------|----------|
| **Enemy Death Particles** | Colored burst matching enemy color | 10-20 small shapes, explode outward | **Must Have** |
| **Dash Trail** | White ghost trail | 3-5 transparent white shapes, fade out | **Must Have** |
| **Door Unlock Particles** | Sparkles/glow burst | Gold/yellow sparkles | Should Have |
| **Door Damage Particles** | Red spark burst | Red/orange sparks | Should Have |
| **Timer Warning Pulse** | Red screen edge pulse | Red glow, pulsing opacity | Should Have |
| **Victory Confetti** | Colorful falling shapes | Multiple colors, falling down | Nice to Have |
| **Enemy Spawn Effect** | Pop from ground | Dust particles or fade-in | Nice to Have |
| **Bomber Explosion** | Explosion burst | Orange/red circle expanding | Should Have |
| **Tank Damage Flash** | White flash on first hit | White overlay, brief flash | **Must Have** |

**Implementation Notes:**
- Use Unity Particle System or simple GameObject instantiation.
- Keep particles lightweight for WebGL.
- Colors match enemy/level themes.

---

## 7. AUDIO ASSETS (Optional, Free SFX)

| Sound | Description | Priority |
|-------|-------------|----------|
| **Dash Sound** | "Whoosh" / fast swoosh | Should Have |
| **Kill Sound** | "Pop" / "Ding" | Should Have |
| **Door Hit** | Heavy "Thud" | Should Have |
| **Timer Tick** | Click each second (speeds up under 3s) | Should Have |
| **Game Over** | Explosion / fail sound | Should Have |
| **Victory Jingle** | Triumphant melody | Should Have |
| **Enemy Spawn** | Subtle "whoosh" | Nice to Have |
| **Bomber Explosion** | "Boom" sound | Nice to Have |
| **Music Loop** | Simple loop; tempo changes per level (80/120/160 BPM) | Nice to Have |

**Source Recommendations:**
- **Free SFX:** [Freesound.org](https://freesound.org), [ZapSplat](https://www.zapsplat.com), [OpenGameArt](https://opengameart.org).
- **Music:** [Pixabay Music](https://pixabay.com/music/), [Incompetech](https://incompetech.com).
- **Generate your own:** [SFXR](https://sfxr.me/) for retro-style sounds.

---

## 8. SPRITE CREATION QUICK REFERENCE

### Unity Primitive Method (No External Tools)
1. Create a new Sprite in Unity via `Assets > Create > Sprites > Square/Circle`.
2. Or create a Texture2D via code:
```csharp
Texture2D texture = new Texture2D(64, 64);
// Set pixels to color
// Apply texture
// Create sprite from texture
```

### External Tool Method (Recommended for Polished Art)
- **Aseprite** – Pixel art editor ($20, but worth it).
- **Photoshop/GIMP** – For raster graphics.
- **Inkscape** – For vector shapes (export as PNG).

### Quick Asset Generation (Code-Based)
For jam speed, you can generate all enemy sprites procedurally in Unity using `Texture2D.SetPixel()` and `Sprite.Create()`. This saves hours of manual sprite creation.

---

## 9. ART PRIORITY SUMMARY

### Must Have (Finish or Game is Broken)
- [ ] Player Triangle Sprite (with worried eyes)
- [ ] 9 Enemy Sprites (shapes + colors + expressions)
- [ ] Door Sprite (with glow + lock)
- [ ] Door Health UI (10 squares)
- [ ] Timer UI (large text)
- [ ] Level Backgrounds (3 colors)
- [ ] Game Over / Victory / Level Complete Overlays
- [ ] Buttons (Restart, Play Again, Exit)

### Should Have (Makes Game Feel Polished)
- [ ] Dash Trail (white ghost)
- [ ] Enemy Death Particles (colored bursts)
- [ ] Door Unlock Particles
- [ ] Screen Edge Pulse (low timer)
- [ ] Level Intro Text (with level name)
- [ ] SFX (Dash, Kill, Door Hit, Timer Tick)
- [ ] Vignette (Level 3)

### Nice to Have (Extra Polish)
- [ ] Victory Confetti
- [ ] Background Grid Pattern
- [ ] Enemy Spawn Animation
- [ ] Music (3 tempos)
- [ ] Bomber Explosion Effect
- [ ] Tank Health Bar (2 segments)

---

## 10. ART SPECS SUMMARY TABLE

| Category | Count | Total Assets | Priority |
|----------|-------|--------------|----------|
| Player | 1 | 1 | Must Have |
| Enemies | 9 | 9 | Must Have |
| Door | 1 (+ variants) | 4 | Must Have |
| UI Elements | 10+ | 10+ | Must Have |
| Backgrounds | 3 | 3 | Must Have |
| Particles | 8 | 8 | Should Have |
| Audio | 8 | 8 | Should Have |
| **Total** | **~43** | **~43** | **All** |

---

## ✅ ART CHECKLIST (Quick Reference)

### Player
- [ ] Triangle sprite with worried eyes

### Enemies (9)
- [ ] Slime (Circle, Light Green)
- [ ] Wobbler (Circle, Teal)
- [ ] Grunt (Square, Orange, angry)
- [ ] Runner (Triangle, Yellow, lean)
- [ ] Jumper (Diamond, Purple, glow)
- [ ] Spinner (Hexagon, Pink, rotate)
- [ ] Tank (Square, Dark Red, cracks)
- [ ] Blitzer (Triangle, Bright Red, motion lines)
- [ ] Bomber (Circle, Black/Orange, flicker)

### Door
- [ ] Rectangle with glow (3 colors)
- [ ] Lock icon (locked/unlocked states)
- [ ] Open animation

### UI
- [ ] Timer text
- [ ] Door HP (10 squares)
- [ ] Level indicator
- [ ] Game Over screen
- [ ] Level Complete screen
- [ ] Victory screen
- [ ] Buttons (3 types)

### Backgrounds
- [ ] Level 1 (Green + grid)
- [ ] Level 2 (Yellow + grid)
- [ ] Level 3 (Red + grid + vignette)

### Particles
- [ ] Enemy death (9 colors)
- [ ] Dash trail
- [ ] Door unlock
- [ ] Low timer pulse
- [ ] Victory confetti

### Audio
- [ ] Dash SFX
- [ ] Kill SFX
- [ ] Door hit SFX
- [ ] Timer tick SFX
- [ ] Game Over SFX
- [ ] Victory SFX
- [ ] Music (3 tempos)

---

**That's the complete Art To-Do List.** Let me know which assets you want me to generate code for, or if you want me to write Unity scripts that procedurally create these sprites! 🎨