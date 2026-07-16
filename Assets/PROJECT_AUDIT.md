# Survival Island — Project Audit

## Project Information

- Unity version: 6000.3.4f1
- Render Pipeline: HDRP
- Platform: Windows
- Project type: First-person survival game
- Development status: In development
- Target version: Portfolio MVP 1.0

## Current Gameplay Systems

| System             | Status | Notes   |
|--------------------|---|---------|
| Player movement    | Working |         |
| Camera movement    | Working |         |
| Sprint             | Working |         |
| Stamina            | Working |         |
| Jump               | Working |         |
| Swimming           | Not working | Player falls underwater and does not stay near the water surface |
| Health             | Partially working |    Health decreases correctly, but health recovery is not implemented     |
| Hunger             | Partially working |  Hunger decreases, but hunger recovery through food is not implemented       |
| Temperature        | Partially working |  Temperature exists, but it does not change depending on the environment       |
| Damage             | Partially working |  Damage reduces health, but the damage feedback and complete damage flow require additional work       |
| Death              | Partially working |  Death is triggered, but the death animation and complete death sequence are unfinished       |
| Item pickup        | Partially working | Items can be added to the inventory and the world object is destroyed, but quantity support, validation and visual or audio feedback are missing        |
| Inventory          | Partially working |  Items are stored in stacks and displayed in the UI, but input blocking, item details, capacity rules and additional validation are not implemented       |
| Item usage         | Partially working |  The code for applying item effects already exists, but consumable items, effect values and usage feedback still need to be configured and tested       |
| Resource gathering | Partially working |   Chopping and digging can reward an item and remove the resource object, but tool requirements, animations, sound effects and resource feedback are missing      |
| Chest interaction  | Partially working |   A chest can give one configured reward only once, but opening animation, visible opened state, multiple rewards and feedback are not implemented      |
| Hand crafting      | Partially working|  Basic recipes can be displayed and crafted without a station, but ingredient validation, missing-resource feedback and UI polishing still require work       |
| Workbench crafting | Partially working |   Workbench recipes and station types exist, but opening the crafting panel for a specific station and filtering recipes by the active workbench need to be completed      |
| Building placement | Partially working | A placement preview and placement checks exist, but the ghost object, collision validation, resource consumption and cancellation flow require additional testing        |
| Day/night cycle    | Partially working | Time and light rotation are implemented, but HDRP sky, exposure transitions and complete visual changes between day and night are unfinished        |
| Pause menu         | Missing |  The game cannot currently be paused through a dedicated menu       |
| Game restart       | Partially working |    The game can restart or reload the scene, but the complete restart flow after death and victory has not been fully tested     |
| Victory condition  | Missing |   The game does not yet have a final objective, rescue interaction or win screen      |
| Weather            | Missing |   Dynamic weather is not implemented and is not required for MVP 1.0      |
## Audit Summary

### Fully Working Systems — 5

* Player movement
* Camera movement
* Sprint
* Stamina
* Jump

### Partially Working Systems — 14

* Health
* Hunger
* Temperature
* Damage
* Death
* Item pickup
* Inventory
* Resource gathering
* Chest interaction
* Hand crafting
* Workbench crafting
* Building placement
* Day/night cycle
* Game restart

### Not Working Systems — 1

* Swimming

### Missing Systems — 3

* Pause menu
* Victory condition
* Dynamic weather

## Current Project State

The basic first-person controller is complete and stable.

Most gameplay systems have already been created, but they require additional integration, testing and UI feedback before they can be considered complete.

The project currently does not have a complete gameplay loop because the player cannot use inventory items, pause the game or reach a victory condition.

Swimming is the only existing major system that is currently not working.

## Main Development Priorities

1. Fix the swimming system.
2. Complete health, damage, death and restart flow.
3. Complete inventory and item usage.
4. Complete resource gathering and chest interaction.
5. Complete hand crafting and workbench crafting.
6. Complete building placement.
7. Fix the day/night cycle.
8. Add the pause menu.
9. Add the final objective and victory condition.
10. Connect all systems into one complete gameplay loop.

## Completion Criteria

### Swimming

Current status: **Not working**

The swimming system will be considered complete when:

* The player correctly detects entering a water volume.
* The movement state changes from `Grounded` or `Airborne` to `Swimming`.
* The player does not continuously fall to the bottom.
* The player stays near the water surface when no vertical input is provided.
* The player can swim forward, backward and sideways.
* The player can move upward and downward in the water.
* The player can leave the water and return to the grounded movement state.
* Entering and leaving the water does not produce Console errors.
* Repeatedly entering and leaving the water works correctly.
* Swimming works in the Windows build.

### Health

Current status: **Partially working**

The health system will be considered complete when:

* Health decreases after receiving damage.
* Health cannot fall below zero.
* Health cannot increase above its maximum value.
* The player can restore health by using a healing item.
* A healing item is removed from the inventory after use.
* The health UI updates immediately after taking damage or healing.
* Receiving damage produces visual or audio feedback.
* Health reaching zero starts the death sequence.
* The system works correctly after restarting the game.

### Hunger

Current status: **Partially working**

The hunger system will be considered complete when:

* Hunger gradually decreases over time.
* Hunger cannot fall below zero.
* Hunger cannot increase above its maximum value.
* Food restores the configured amount of hunger.
* Food is removed from the inventory after use.
* The hunger UI updates immediately.
* The player receives damage when hunger remains at zero.
* Hunger settings are balanced for a 15–25 minute playthrough.
* The player does not die from hunger during the first few minutes of the game.

### Temperature

Current status: **Partially working**

The temperature system will be considered complete when:

* The player has a normal temperature range.
* Temperature changes depending on the environment.
* Hot areas increase the player’s temperature.
* Cold areas decrease the player’s temperature.
* Returning to a normal area gradually restores temperature.
* The UI clearly shows whether the player is cold, comfortable or hot.
* Extreme temperature causes damage only after a reasonable delay.
* Temperature values are reset correctly after restarting the game.

For MVP 1.0, this system may be temporarily disabled if it does not contribute to the short gameplay loop.

### Damage

Current status: **Partially working**

The damage system will be considered complete when:

* Damage correctly reduces the player’s health.
* Damage cannot be applied after the player has died.
* Repeated damage does not trigger duplicate death events.
* Damage sources provide the correct damage amount.
* Damage feedback includes a screen effect, sound or camera shake.
* The player has a short damage cooldown when required.
* Damage works correctly from hunger, temperature and world hazards.
* Damage does not produce Console errors.

### Death

Current status: **Partially working**

The death system will be considered complete when:

* Death starts when health reaches zero.
* Player movement is disabled after death.
* Camera control is disabled after death.
* Inventory and crafting interactions are disabled.
* A death animation or visual death effect is played.
* The Game Over screen appears.
* The player can restart the game.
* The player can return to the main menu.
* Restarting restores health and all survival values.
* Death cannot be triggered more than once.
* The complete sequence works in the Windows build.

### Weather

Current status: **Missing — Optional**

Dynamic weather is not required for MVP 1.0.

Possible future features:

* Rain
* Wind
* Storms
* Weather transitions
* Temperature influence
* Wet surface effects
* Ambient weather sounds

Weather development must begin only after the core gameplay loop, victory condition and portfolio build are complete.
### Item Pickup

Current status: **Partially working**

The item pickup system will be considered complete when:

* The player can detect a pickup item within interaction range.
* The interaction prompt displays the item name and pickup action.
* Pressing the interaction button adds the correct item to the inventory.
* The correct item quantity is added.
* The world object is removed only after the item is successfully added.
* The item cannot be picked up more than once.
* Pickup works for different item types.
* Pickup produces visual or audio feedback.
* Inventory UI updates immediately after pickup.
* Missing item data does not produce a Console error.
* Pickup works correctly after restarting the game.
* Pickup works in the Windows build.

### Inventory

Current status: **Partially working**

The inventory system will be considered complete when:

* New items are added to the inventory.
* Existing item stacks increase correctly.
* Items can be removed by a specified quantity.
* An item entry is removed when its quantity reaches zero.
* Item quantities cannot become negative.
* Null items cannot be added.
* Inventory UI displays the correct icon, name and quantity.
* Inventory UI updates immediately after every change.
* The player can open and close the inventory.
* Player movement is disabled while the inventory is open.
* Camera rotation is disabled while the inventory is open.
* The cursor becomes visible and unlocked while the inventory is open.
* Controls are restored after closing the inventory.
* The inventory closes correctly when the player dies.
* The inventory works after restarting the game.
* The inventory works in the Windows build.

### Item Usage

Current status: **Partially working**

The item usage system will be considered complete when:

* The player can select a usable item in the inventory.
* Only items with configured effects can be used.
* Healing items restore the configured amount of health.
* Food restores the configured amount of hunger.
* Stamina items restore the configured amount of stamina.
* Temperature items correctly affect temperature when this system is enabled.
* An item is removed only after its effect is successfully applied.
* One item is removed per use.
* An item cannot be used when its quantity is zero.
* Health cannot be restored above its maximum value.
* Hunger cannot be restored above its maximum value.
* The UI updates immediately after item usage.
* Item usage produces visual or audio feedback.
* The player receives a clear message when an item cannot be used.
* Item usage works correctly after restarting the game.
* Item usage works in the Windows build.

### Resource Gathering

Current status: **Partially working**

The resource gathering system will be considered complete when:

* The player can detect a gatherable resource.
* The interaction prompt displays the correct gathering action.
* Trees use the chopping interaction.
* Ground resources use the digging or gathering interaction.
* Gathering requires the correct tool when necessary.
* The player receives the correct item and quantity.
* The resource object is removed or changes state after gathering.
* A resource cannot reward the player more than intended.
* Leaving the interaction range cancels the gathering process.
* Releasing the interaction button resets the progress.
* Gathering produces animation, sound or particle feedback.
* Inventory UI updates immediately after gathering.
* Missing resource data does not produce Console errors.
* Gathering works in the Windows build.

### Chest Interaction

Current status: **Partially working**

The chest system will be considered complete when:

* The player can detect and interact with a chest.
* The interaction prompt displays the correct action.
* The chest gives the configured reward.
* The reward can contain more than one item type if required.
* Item quantities are added correctly.
* The chest cannot give the same reward repeatedly.
* The chest visually changes to an opened state.
* An opening animation or simple visual transition is played.
* Opening the chest produces sound feedback.
* The inventory UI updates immediately.
* Empty or incorrectly configured chests do not cause Console errors.
* The chest remains opened after the interaction.
* Chest interaction works in the Windows build.

### Interaction System

Current status: **Partially working**

The interaction system will be considered complete when:

* The player detects the nearest valid interaction target.
* The interaction prompt appears only for valid targets.
* The prompt disappears when the player looks away.
* The prompt disappears when the player leaves interaction range.
* Click interactions work correctly.
* Hold interactions show progress.
* Hold progress resets after cancellation.
* Destroying a focused object does not cause errors.
* Rapidly switching between targets works correctly.
* Interaction is disabled while inventory, crafting or pause UI is open.
* Interaction is disabled after player death.
* Interaction does not detect placement ghost objects.
* The system works correctly in the Windows build.
### Hand Crafting

Current status: **Partially working**

The hand crafting system will be considered complete when:

* The player can open the hand crafting panel without using a crafting station.
* Only recipes with `StationKind.None` are displayed.
* Every recipe displays its output item.
* Every recipe displays all required ingredients.
* The UI shows how many ingredients the player currently has.
* Missing ingredients are clearly highlighted.
* The craft button is disabled when resources are insufficient.
* Crafting removes the correct ingredient quantities.
* Crafting adds the correct output quantity.
* Duplicate ingredients in one recipe are calculated correctly.
* The player cannot craft an item by pressing the button repeatedly without resources.
* The inventory UI updates immediately after crafting.
* The crafting UI updates immediately after inventory changes.
* A successful craft produces sound or visual feedback.
* Crafting does not produce Console errors.
* Hand crafting works in the Windows build.

### Workbench Crafting

Current status: **Partially working**

The workbench crafting system will be considered complete when:

* The player can detect and interact with a placed workbench.
* The interaction prompt displays the correct action.
* Interacting with the workbench opens the crafting panel.
* The crafting panel receives `StationKind.Workbench`.
* Only workbench recipes are displayed.
* Hand crafting recipes are hidden while using the workbench.
* The panel title clearly indicates that the player is using a workbench.
* The player can select and craft a workbench recipe.
* Ingredients are removed correctly.
* The output item is added correctly.
* The panel closes when the player moves too far from the workbench.
* The panel closes when the player presses Escape.
* Movement and camera input are disabled while the panel is open.
* Input is restored after closing the panel.
* Destroying or disabling the workbench does not cause errors.
* Multiple placed workbenches work correctly.
* Workbench crafting works in the Windows build.

### Crafting Data

Current status: **Partially working**

The crafting data system will be considered complete when:

* Every recipe has at least one valid input.
* Every recipe has a valid output item.
* Every item quantity is greater than zero.
* Every recipe has the correct required station.
* Recipes do not contain unintended duplicate ingredients.
* Recipe names and output names are clear.
* Recipe icons are assigned.
* All required items can be obtained during normal gameplay.
* The player has enough available resources to complete the game.
* Invalid recipes are reported through validation instead of causing runtime errors.
* Unused test recipes are removed before release.

### Building Placement

Current status: **Partially working**

The building placement system will be considered complete when:

* A buildable inventory item can start placement mode.
* Starting placement creates a visual preview.
* The preview follows the player’s aim position.
* The player can rotate the preview.
* The preview displays a valid placement material.
* The preview displays an invalid placement material.
* The preview does not block player movement.
* The preview does not interact with gameplay systems.
* Preview colliders do not interfere with placement checks.
* Placement is blocked when another object overlaps the building.
* Placement is blocked under the player.
* Placement is blocked inside water.
* Placement is blocked on excessively steep surfaces.
* Placement succeeds on valid ground.
* The real prefab is created only after confirmation.
* The buildable item is removed only after successful placement.
* Cancelling placement does not remove the item.
* Placement mode can be cancelled with Escape or the secondary input.
* Placement mode ends after successful placement.
* Player interaction is disabled while placement mode is active.
* The system works with prefabs containing multiple colliders.
* Missing prefabs or colliders do not cause Console errors.
* Building placement works in the Windows build.

### Workbench Placement

Current status: **Partially working**

The workbench placement flow will be considered complete when:

* The player can craft or obtain a workbench item.
* Using the workbench item starts placement mode.
* The player can select a valid location.
* The placed workbench remains in the world.
* The placed workbench has the correct collider.
* The placed workbench has an interaction component.
* The placed workbench opens workbench crafting.
* The workbench item is removed after successful placement.
* Cancelling placement keeps the item in the inventory.
* The player cannot place the workbench inside another object.
* The player cannot place the workbench in water.
* The workbench can be approached and used from a comfortable distance.
* The complete loop works after restarting the scene.

### Day/Night Cycle

Current status: **Partially working**

The day/night system will be considered complete when:

* Game time advances continuously.
* The sun rotates according to the current time.
* The moon is visible or active during the night when required.
* Directional light intensity changes smoothly.
* Light temperature changes smoothly.
* HDRP sky settings are connected to the Volume Profile.
* HDRP exposure settings are connected to the Volume Profile.
* The sky does not change abruptly.
* The scene does not become completely black at night.
* The scene is not overexposed during the day.
* The time UI displays the correct time.
* Day count increases correctly.
* Time values reset correctly after restarting the game.
* The cycle duration is appropriate for a 15–25 minute playthrough.
* The complete cycle does not create noticeable frame drops.
* The system works in the Windows build.

For MVP 1.0, the cycle may be simplified to one controlled transition if a full day/night cycle does not improve the short gameplay experience.

### Pause Menu

Current status: **Missing**

The pause system will be considered complete when:

* Pressing Escape opens the pause menu during gameplay.
* The game time stops while the pause menu is open.
* Player movement is disabled.
* Camera movement is disabled.
* Interaction is disabled.
* The cursor becomes visible and unlocked.
* The pause menu contains a Resume button.
* The pause menu contains a Restart button.
* The pause menu contains a Main Menu button.
* The pause menu contains a Quit button.
* Resume restores the previous game state.
* Escape closes the pause menu.
* The pause menu cannot open over the Game Over screen.
* The pause menu cannot open over the Win Screen.
* Inventory and crafting panels close or are blocked before pausing.
* The system works correctly in the Windows build.

### Game Restart

Current status: **Partially working**

The restart system will be considered complete when:

* The player can restart after death.
* The player can restart from the pause menu.
* The player can restart after victory.
* The active gameplay scene reloads correctly.
* Health returns to its starting value.
* Hunger returns to its starting value.
* Stamina returns to its starting value.
* Temperature returns to its starting value when enabled.
* Inventory returns to its intended starting state.
* Objectives return to their starting state.
* Opened UI panels are closed.
* The cursor returns to the correct state.
* `Time.timeScale` returns to `1`.
* Static and singleton values do not keep data from the previous run.
* No duplicate player or manager objects appear.
* The restart flow works repeatedly.
* Restart works in the Windows build.

### Victory Condition

Current status: **Missing**

The victory system will be considered complete when:

* The game has one clearly defined final objective.
* The player can obtain all required final components.
* The final item can be crafted or assembled.
* The player can interact with the final rescue device.
* The final interaction cannot happen before the required progression.
* Activating the device completes the last objective.
* Player movement is disabled after victory.
* Player interaction is disabled after victory.
* A final sound or visual effect is played.
* The Win Screen appears.
* The Win Screen displays the completion time.
* The player can restart the game.
* The player can return to the main menu.
* The player can quit the game.
* Victory cannot be triggered more than once.
* The complete gameplay loop can be finished without developer tools.
* The complete victory sequence works in the Windows build.
## MVP Priority Matrix

### Priority 1 — Critical for a Playable Build

These systems must work before the project can be considered playable:

* Swimming
* Health recovery
* Hunger recovery
* Damage flow
* Death sequence
* Game restart
* Inventory input blocking
* Item usage
* Resource gathering
* Hand crafting
* Workbench crafting
* Building placement
* Pause menu
* Victory condition

The project cannot be released while any of these systems are completely broken.

### Priority 2 — Required for a Complete Gameplay Loop

These systems connect the existing mechanics into a finished game:

* Final item progression
* Workbench placement
* Blocked area progression
* Objective system
* Final rescue device
* Win Screen
* Game Over screen
* Main menu
* Complete restart flow
* Resource distribution
* Recipe balance
* Player guidance
* Interaction prompts

These systems must be completed before portfolio publication.

### Priority 3 — Gameplay Feedback and Quality

These tasks improve clarity and game feel:

* Damage screen effect
* Camera shake
* Pickup sound
* Gathering sound
* Crafting sound
* Placement sound
* Swimming sound
* Objective completion effect
* Gathering particles
* Placement particles
* Selected inventory slot state
* Missing-resource feedback
* Valid and invalid placement materials
* Chest opening state
* Death animation
* UI transitions

The game can technically work without some of these features, but the final portfolio video will look unfinished.

### Priority 4 — Visual Polish

These tasks should begin only after the complete game loop works:

* UI visual consistency
* Final lighting
* Day/night transition polish
* Environment decoration
* Fog and atmosphere
* Scene composition
* Final materials
* Final animations
* Additional sound ambience
* Screenshot preparation
* Trailer preparation

Visual polish must not delay critical gameplay work.

### Priority 5 — Optional After MVP 1.0

These systems are not required for the first portfolio release:

* Dynamic weather
* Rain
* Storms
* Advanced temperature zones
* Multiple islands
* Large cave system
* Enemy AI
* Combat
* Advanced base building
* Multiple crafting stations
* Farming
* Vehicles
* Procedural generation
* Multiplayer
* Full world saving
* Skill tree
* NPC dialogue
* Complex quest system

Optional features may be developed only after version 1.0 has been released.

## Priority Rules

1. A Priority 1 task always comes before visual polish.
2. A broken gameplay loop always comes before adding new content.
3. No optional system may be added while the victory condition is missing.
4. No new item should be added unless it is required by the final progression.
5. No new recipe should be added unless it supports the main gameplay loop.
6. A system is not complete until it works in a Windows build.
7. Every major system must be tested after scene restart.
8. Every completed task should be committed separately when possible.

## Current Highest-Priority Tasks

Based on the current audit, the immediate development order is:

1. Fix swimming.
2. Complete health and hunger recovery.
3. Complete item usage.
4. Complete damage and death flow.
5. Complete restart after death.
6. Complete inventory input blocking.
7. Complete hand crafting.
8. Complete workbench crafting.
9. Complete workbench placement.
10. Add pause menu.
11. Add final objective.
12. Add victory condition.
## Release Readiness

### Gameplay

* [ ] The player can start a new game.
* [ ] Player movement works correctly.
* [ ] Sprint and stamina work correctly.
* [ ] Jumping works correctly.
* [ ] Swimming works correctly.
* [ ] The player can leave the water without getting stuck.
* [ ] Health decreases after receiving damage.
* [ ] Health can be restored.
* [ ] Hunger decreases over time.
* [ ] Hunger can be restored with food.
* [ ] Item effects work correctly.
* [ ] The player can die.
* [ ] The Game Over screen appears after death.
* [ ] The player can restart after death.
* [ ] The game has a complete victory condition.

### Interaction

* [ ] Interaction targets are detected correctly.
* [ ] The interaction prompt appears near valid objects.
* [ ] The prompt disappears when the target is lost.
* [ ] Item pickup works correctly.
* [ ] Resource gathering works correctly.
* [ ] Chest interaction works correctly.
* [ ] Hold interactions reset after cancellation.
* [ ] Interaction is blocked while menus are open.
* [ ] Interaction is blocked after death and victory.

### Inventory and Items

* [ ] Items are added with the correct quantity.
* [ ] Existing item stacks increase correctly.
* [ ] Item quantities cannot become negative.
* [ ] Empty stacks are removed.
* [ ] Inventory UI updates immediately.
* [ ] The player can use consumable items.
* [ ] Used items are removed correctly.
* [ ] Player movement is blocked while the inventory is open.
* [ ] Camera movement is blocked while the inventory is open.
* [ ] The cursor state changes correctly.
* [ ] Inventory works after restarting the scene.

### Crafting

* [ ] Hand crafting displays only hand crafting recipes.
* [ ] Workbench crafting displays only workbench recipes.
* [ ] Recipes display all required ingredients.
* [ ] Available and required quantities are displayed.
* [ ] Missing ingredients are highlighted.
* [ ] Crafting is blocked when resources are insufficient.
* [ ] Ingredients are removed correctly.
* [ ] Output items are added correctly.
* [ ] Duplicate ingredients are calculated correctly.
* [ ] Crafting UI updates after every craft.
* [ ] Crafting works in the Windows build.

### Building Placement

* [ ] A buildable item starts placement mode.
* [ ] The placement preview follows the target position.
* [ ] The preview can be rotated.
* [ ] Valid placement is clearly displayed.
* [ ] Invalid placement is clearly displayed.
* [ ] Placement is blocked inside other objects.
* [ ] Placement is blocked inside water.
* [ ] Placement is blocked under the player.
* [ ] Cancelling placement does not consume the item.
* [ ] Successful placement consumes one item.
* [ ] The placed workbench can be used.
* [ ] Placement works correctly after restarting the scene.

### Progression

* [ ] The game has a clear starting objective.
* [ ] The player can gather all required resources.
* [ ] The player can craft the first tool.
* [ ] The player can gather advanced resources.
* [ ] The player can craft and place a workbench.
* [ ] A new area is unlocked through progression.
* [ ] The player can obtain the final component.
* [ ] The player can craft the rescue device.
* [ ] The final device can be activated.
* [ ] The Win Screen appears.
* [ ] Victory cannot be triggered multiple times.
* [ ] The complete game can be finished without developer tools.

### User Interface

* [ ] HUD values update correctly.
* [ ] Inventory UI is readable.
* [ ] Crafting UI is readable.
* [ ] Interaction prompts are readable.
* [ ] Objectives are displayed clearly.
* [ ] Pause menu works.
* [ ] Game Over screen works.
* [ ] Win Screen works.
* [ ] All buttons have consistent styling.
* [ ] UI scales correctly at 1920×1080.
* [ ] UI remains usable at another common resolution.
* [ ] Long item names do not break the layout.

### Audio and Visual Feedback

* [ ] Pickup has feedback.
* [ ] Resource gathering has feedback.
* [ ] Crafting has feedback.
* [ ] Placement has feedback.
* [ ] Damage has feedback.
* [ ] Death has feedback.
* [ ] Objective completion has feedback.
* [ ] Victory has feedback.
* [ ] Audio volume is balanced.
* [ ] Particle effects do not significantly reduce performance.
* [ ] No materials appear pink or missing.

### Stability

* [ ] There are no compiler errors.
* [ ] There are no runtime exceptions during a complete playthrough.
* [ ] There are no repeating warnings in the Console.
* [ ] The player cannot fall through the main level.
* [ ] The player cannot become permanently stuck.
* [ ] UI panels do not remain open after restart.
* [ ] `Time.timeScale` returns to `1` after restart.
* [ ] Events are unsubscribed correctly.
* [ ] Restarting does not create duplicate managers.
* [ ] The complete game has been finished at least three times.

### Performance

* [ ] The game maintains an acceptable frame rate.
* [ ] There are no major frame drops during interaction.
* [ ] There are no major frame drops during crafting.
* [ ] There are no major frame drops during placement.
* [ ] There are no major frame drops during day/night transitions.
* [ ] Memory usage does not continuously increase.
* [ ] Repeated gameplay actions do not create excessive garbage collection.
* [ ] The final build has been checked with the Unity Profiler.

### Windows Build

* [ ] The correct scene is included in Build Profiles.
* [ ] The game starts without Unity Editor.
* [ ] The main menu works.
* [ ] Keyboard and mouse input work.
* [ ] The cursor locks and unlocks correctly.
* [ ] Pause works.
* [ ] Restart works.
* [ ] Game Over works.
* [ ] Victory works.
* [ ] Quit works.
* [ ] All required assets are included.
* [ ] The build has been tested after downloading or copying it to another folder.

### GitHub Portfolio

* [ ] The repository has a clear description.
* [ ] Repository topics are added.
* [ ] The README is written in English.
* [ ] The README contains a gameplay description.
* [ ] The README explains the main systems.
* [ ] The README explains the architecture.
* [ ] The README contains controls.
* [ ] The README contains the Unity version.
* [ ] The README contains screenshots.
* [ ] The README contains a gameplay video or GIF.
* [ ] Third-party assets are credited.
* [ ] Generated IDE files are not tracked.
* [ ] Test files and unused code are removed.
* [ ] A public release is available.
* [ ] The final build can be downloaded.

## Release Decision

The project is ready for version `1.0` when:

1. All Priority 1 systems are complete.
2. The full gameplay loop can be completed.
3. No critical bugs remain.
4. The game can be completed three times in the Windows build.
5. The GitHub repository clearly explains the project.
6. A downloadable build and gameplay video are available.

Optional systems such as dynamic weather are not required for the first release.
