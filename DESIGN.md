---
name: Expeditions Macro
description: A quiet, precise Windows control surface for dependable Roblox automation.
colors:
  dark-canvas: "#0F1010"
  dark-sidebar: "#131415"
  dark-surface: "#17181A"
  dark-raised: "#1E1F22"
  dark-hover: "#14FFFFFF"
  dark-selected: "#1FFFFFFF"
  dark-border: "#14FFFFFF"
  dark-border-strong: "#24FFFFFF"
  dark-inner-hairline: "#0FFFFFFF"
  dark-text: "#F2F3F5"
  dark-muted: "#A6A9AE"
  dark-faint: "#83868B"
  dark-accent: "#7B84FB"
  dark-accent-hover: "#8A92FC"
  dark-accent-pressed: "#6C75EE"
  dark-accent-strong: "#5A63E9"
  dark-accent-soft: "#2E7B84FB"
  dark-success: "#55B887"
  dark-warning: "#D6A84B"
  dark-error: "#E06B74"
  light-canvas: "#FAFAFB"
  light-sidebar: "#F4F5F6"
  light-surface: "#FFFFFF"
  light-raised: "#F0F1F3"
  light-hover: "#0A000000"
  light-selected: "#12000000"
  light-border: "#E4E5E8"
  light-border-strong: "#D2D4D8"
  light-inner-hairline: "#0A000000"
  light-text: "#1A1C1F"
  light-muted: "#565A60"
  light-faint: "#6A6E74"
  light-accent: "#535EE6"
  light-accent-hover: "#4750D6"
  light-accent-pressed: "#3D46C4"
  light-accent-strong: "#535EE6"
  light-accent-soft: "#1F535EE6"
  light-success: "#1E7A52"
  light-warning: "#8D6814"
  light-error: "#B13E48"
  on-accent: "#FFFFFF"
typography:
  page-title:
    fontFamily: "Segoe UI Variable Text"
    fontSize: "20px"
    fontWeight: 600
    lineHeight: 1.25
  section-title:
    fontFamily: "Segoe UI Variable Text"
    fontSize: "13px"
    fontWeight: 600
    lineHeight: 1.35
  group-label:
    fontFamily: "Segoe UI Variable Text"
    fontSize: "11px"
    fontWeight: 600
    lineHeight: 1.3
  body:
    fontFamily: "Segoe UI Variable Text"
    fontSize: "13px"
    fontWeight: 400
    lineHeight: 1.45
  caption:
    fontFamily: "Segoe UI Variable Text"
    fontSize: "12px"
    fontWeight: 400
    lineHeight: 1.4
  mono-caption:
    fontFamily: "Cascadia Mono"
    fontSize: "12px"
    fontWeight: 400
    lineHeight: 1.4
  brand-wordmark:
    fontFamily: "Fredoka"
    fontSize: "13px"
    fontWeight: 600
    lineHeight: 1.25
rounded:
  badge: "5px"
  control: "6px"
  surface: "10px"
  overlay: "12px"
spacing:
  compact: "4px"
  tight: "8px"
  group: "12px"
  card: "16px 14px"
  section: "20px"
components:
  button-primary:
    backgroundColor: "{colors.dark-accent-strong}"
    textColor: "{colors.on-accent}"
    typography: "{typography.body}"
    rounded: "{rounded.control}"
    padding: "0 12px"
    height: "36px"
  button-secondary:
    backgroundColor: "{colors.dark-raised}"
    textColor: "{colors.dark-text}"
    typography: "{typography.body}"
    rounded: "{rounded.control}"
    padding: "0 12px"
    height: "32px"
  input:
    backgroundColor: "{colors.dark-surface}"
    textColor: "{colors.dark-text}"
    typography: "{typography.body}"
    rounded: "{rounded.control}"
    padding: "0 10px"
    height: "32px"
  navigation-item:
    backgroundColor: "{colors.dark-accent-soft}"
    textColor: "{colors.dark-text}"
    typography: "{typography.body}"
    rounded: "{rounded.control}"
    padding: "0 12px"
    height: "32px"
---

# Design System: Expeditions Macro

## Overview

**Creative North Star: "The Quiet Control Surface"**

Expeditions Macro is quiet, precise, and capable. Its interface uses compact alignment, restrained density, and clear state changes so the user can configure a run once, supervise it at a glance, and intervene without studying the screen.

The visual system is flat and tool-like, with the calm hierarchy of Linear rather than the visual noise of a traditional macro utility. Primary actions are obvious but rare; advanced tuning stays secondary until requested. Every screen must make the current operation, recovery state, and stopping behavior unmistakable.

**Key Characteristics:**

- Compact 32px controls aligned to a consistent grid.
- One restrained indigo accent reserved for primary action, focus, selection, and live state.
- Alpha-based hairline borders and a second inner hairline on every raised surface instead of decorative depth.
- Equal-quality dark and light themes with native Windows typography and tabular numerals on every counter.
- Progressive disclosure for advanced tuning and diagnostics.

## Colors

The palette is neutral and low-chroma, with a restrained indigo signal and semantic colors used only for real status. Dark-theme structure comes from low-alpha white layers that compose over any surface; light-theme structure comes from near-neutral opaque hairlines.

### Primary

- **Operational Indigo:** The single action accent for primary buttons, keyboard focus, progress, selection, and live-state indicators. Interaction shades (hover, pressed) and a soft translucent tint exist for selected fills, focus halos, and informational chips.

### Neutral

- **Near-Black Canvas / Quiet Paper:** The outer working background for dark and light themes.
- **Sidebar Tone:** A subtly separated navigation rail that never competes with page content.
- **Working Surface:** The default field and content surface; pure white cards in light theme.
- **Raised Control:** A small tonal step used by buttons, read-only fields, and menus.
- **Hairline Border / Strong Border:** One-pixel structure for surfaces and dividers; the strong step is reserved for inputs and focused-adjacent chrome.
- **Inner Hairline:** A second one-pixel border just inside every raised surface — light-from-above in dark theme, resting shade below in light theme. This is the only depth vocabulary; the system has no shadows.
- **Primary Text / Muted Text / Faint Text:** Three deliberate levels for content, explanation, and tertiary metadata.

### Semantic

- **Measured Success:** Confirmed completion and healthy state only.
- **Reserved Warning:** Waiting, caution, or recoverable attention only.
- **Clear Error:** Failures, destructive actions, and stopped operations only.
- Each semantic tone has a soft translucent fill for badges and banners; the tone color itself carries the text.

**The One Voice Rule.** Operational Indigo is scarce. Never use it as decoration or as a background for entire sections.

**The Theme Parity Rule.** Every semantic role must remain legible and equivalent in both theme palettes; never solve contrast in only one theme. Light mode is reviewed side-by-side with dark before any surface is considered done.

## Typography

**UI Font:** Segoe UI Variable Text (system; falls back to Segoe UI on Windows 10)
**Brand Font:** Fredoka (embedded) — the titlebar wordmark only
**Mono Font:** Cascadia Mono, falling back to Consolas — run log, hotkey chips, coordinates, runtime counters
**Icons:** Lucide native vector geometry, inheriting the surrounding semantic color

**Character:** Neutral and operational. Dense 13px text scans best in a quiet grotesque; Fredoka survives as a single friendly signature in the titlebar. Every numeric counter uses tabular numerals so values do not jitter as they tick.

### Hierarchy

- **Page title** (Semibold, 20px, 1.25): One concise title at the top of each workspace page.
- **Section title** (Semibold, 13px, 1.35): Divides workflows and names meaningful control groups.
- **Group label** (Semibold, 11px, Faint, uppercase): Names sidebar groups and settings sections.
- **Body** (Regular, 13px, 1.45): Controls, values, status, and ordinary explanatory copy.
- **Caption** (Regular, 12px, 1.4): Secondary guidance and metadata; always wraps instead of clipping.
- **Mono caption** (Regular, 12px mono): Logs, coordinates, and keyboard hints.
- **Stat values** (Semibold, 18px / 22px, tabular): Counters on the supervision surface.

**The Native Clarity Rule.** Use weight and spacing for hierarchy. Never introduce decorative display faces beyond the wordmark, fake letter-spacing on titles, or compressed labels.

## Elevation

The system is flat and uses no shadow vocabulary. Depth comes from tonal layering between canvas, sidebar, surface, raised, hover, and selected roles, reinforced by the two-layer border: a one-pixel low-alpha outer border plus a one-pixel inner hairline at radius minus one. In dark theme the inner hairline reads as light catching the top edge; in light theme as a soft resting shade at the bottom. Apply it to cards, inputs, secondary buttons, popovers, dialogs, and toasts — never to flat or ghost elements such as navigation items, icon buttons, or checkboxes.

**The Tonal Depth Rule.** If a container needs a shadow to be understood, its hierarchy is wrong. Correct the spacing, surface role, or border first.

**The One Divider Rule.** Use a single hairline divider between major sections; never stack borders, cards, and shadows around the same content.

## Radius and Density

Corner radius communicates role: badges and chips 5px, controls 6px, cards and content surfaces 10px, overlays (dialogs, popovers, toasts) 12px. Nothing exceeds 12px except fully round pills and dots.

Control heights: 32px default (buttons, inputs, combos, navigation items), 36px primary and danger actions, 28px compact inline controls, 30px icon buttons. Spacing rhythm: 20px between major sections, 12px within control groups, 8px between a label and its control, 16px by 14px card padding.

## Components

### Buttons

- **Shape:** 6px corners; 32px default height, 36px primary; 12px horizontal padding.
- **Primary:** Operational Indigo with white text, semibold weight, an inner top hairline highlight, and at least 128px width for the main workflow action. Pressed swaps to the pressed accent shade and drops the hairline. Accent-filled controls use the deeper strong-accent shade rather than the display accent, because white on the lighter dark-theme indigo does not reach 4.5:1; the display accent remains the colour for text, icons, rails, and focus rings.
- **Secondary:** Raised neutral surface, primary text, one-pixel border, inner hairline.
- **Danger:** Outline error tone at rest, solid error fill on hover — destructive intent without shouting.
- **Ghost / Icon:** Flat, borderless, hover tone only; icon buttons are 30px square with 16px icons.
- **Hover / Pressed:** Alpha overlay tones composed over the surface; 100–150ms color transitions only, no translation or glow.
- **Focus:** A one-pixel Operational Indigo border plus a 2px soft-accent outer ring, preserving native keyboard behavior with no layout shift.
- **Disabled:** 55% opacity with an arrow cursor; the label remains readable.

### Cards / Containers

- **Corner Style:** Content cards use 10px corners with the two-layer border; overlays use 12px.
- **Background:** Canvas at the page level, working surface for cards and editable controls, and raised tone only where interaction requires separation.
- **Shadow Strategy:** None; the inner hairline is the only depth cue.
- **Internal Spacing:** 20px between major sections, 12px within control groups, 16px by 14px card padding.

### Inputs / Fields

- **Style:** 32px minimum height, 6px corners, working-surface fill, one-pixel strong border, 10px horizontal padding.
- **Focus:** Border changes to Operational Indigo with a 2px soft-accent halo and no layout shift.
- **Read-only / Disabled:** Raised neutral fill for read-only values; disabled fields retain content at 55% opacity.
- **Error:** Clear Error border with a soft error halo, reserved for a real validation failure and paired with explanatory text.

### Navigation

- **Style:** A quiet sidebar with 32px items, 6px corners, and 12px horizontal padding.
- **Default / Hover / Active:** Muted text with 60%-opacity icons at rest; hover tone with primary text and full-opacity icons; selected items use the soft accent fill, primary text, accent icon, and a 2px accent bar on the left edge. The same selection vocabulary applies to every selectable list in the app.
- **State:** The persistent status block stays separate from navigation and pairs a status dot with explicit text.
- **Workspace split:** Dashboard is the supervision surface for Roblox, run state, logs, connections, startup preparation, and controls. Macro Plan is the authoring surface for plan blocks, loops, and sharing. They share one runtime owner; navigation changes the surface, never the active operation.
- **Plan blocks:** Express ordered work as one calm connected stack. Use a clear start cap, numbered task blocks, and a visually nested loop range. Preserve explicit route, target, progress, and edit/reorder/delete actions without imitating Scratch's saturated palette or decorative puzzle shapes.

### Status and Feedback

- **Status dot:** One shared control drives run state everywhere: faint when idle or stopped, accent when running, warning when waiting or recovering, success when completed, error when failed. Live states pulse with a stepped two-second opacity cycle; the pulse stops for settled states and is skipped entirely when the system disables client-area animation.
- **Badges:** 20px chips with soft-tint semantic fills and tone-colored 11px text; zero or inactive values stay muted because color means signal, not decoration.
- **Kbd chips:** 20px mono chips on a raised fill with a hairline border replace plain-text key names.
- **Toasts:** Bottom-right overlay surfaces reserved for existing transient confirmations; errors persist until dismissed. Run-critical errors never move out of their modal or inline homes.
- **Empty states:** A centered Lucide icon in a 64px raised tile, a 14px semibold title, and a 12px muted caption. No illustrations.

### Data and Progress

- **Tables:** Open surfaces with one outer hairline and horizontal row rules; column headers use the raised neutral tone with 11px semibold labels.
- **Progress:** A restrained 3px indigo line with no decorative track treatment.
- **Scrollbars:** 6px overlay thumbs on a transparent track with a 10px hit target, visible only as structure; scrolling must remain available whenever content exceeds the viewport.

## Motion

- Color and hover transitions: 100–150ms, background and border only.
- Overlay enter: 200ms fade with a 0.98-to-1 scale; exit: 150ms fade.
- Status pulse: stepped two-second cycle with discrete keyframes so idle render cost stays near zero.
- Layout is never animated, and every storyboard is skipped when the system disables client-area animation.

## Do's and Don'ts

### Do:

- **Do** keep the primary action and current automation state visible without scrolling whenever practical.
- **Do** place explanatory copy beneath its section heading and above controls.
- **Do** use the 20px section rhythm, 32px controls, role-based corners, and one-pixel borders consistently.
- **Do** reveal advanced tuning progressively while keeping the primary workflow calm.
- **Do** preserve native keyboard focus, readable contrast (at least 4.5:1 for body text in both themes), theme parity, and uncropped text at supported Windows scaling.
- **Do** pair success, warning, and error colors with explicit text so state never relies on color alone.
- **Do** give every numeric counter tabular numerals.

### Don't:

- **Don't** recreate legacy auto-clicker or WinForms aesthetics.
- **Don't** use oversized controls, nested cards, decorative gradients, excessive borders, or generic dashboard tiles.
- **Don't** expose developer-facing implementation language in user-visible copy.
- **Don't** turn Operational Indigo into ambient decoration, large colored panels, or neon glow.
- **Don't** place long prose beside controls where it compresses inputs or causes overlap.
- **Don't** introduce ornamental type, drop shadows, glassmorphism, glow, colored section backgrounds, emoji or exclamation marks in UI copy, or motion that competes with automation state.
