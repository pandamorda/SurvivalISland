# Survival Island — MVP Scope

## Project Overview

**Survival Island** is a short first-person survival game created with Unity and C#.

The player survives a shipwreck and becomes stranded on an isolated island. To escape, the player must explore the environment, gather resources, craft basic tools, build a workbench and assemble an emergency communication device.

The project is being developed as a portfolio game for a Junior Unity Developer position.

## MVP Goal

The goal of version `1.0` is to create a small but complete survival experience that can be finished in approximately 15–25 minutes.

The MVP must demonstrate:

* First-person player movement
* State-based movement logic
* Swimming
* Survival parameters
* Interaction with world objects
* Inventory management
* ScriptableObject-based items
* Item effects
* Resource gathering
* Hand crafting
* Workbench crafting
* Building placement
* Gameplay progression
* Death and restart
* A complete victory condition
* UI Toolkit interfaces

The MVP does not need to contain a large open world or many hours of gameplay. The priority is a stable and complete gameplay loop.

## Player Goal

The player’s main goal is to create an emergency communication device and send a rescue signal.

To achieve this goal, the player must:

1. Explore the starting area.
2. Collect basic resources.
3. Craft a simple tool.
4. Gather advanced resources.
5. Craft a workbench.
6. Place the workbench in the world.
7. Use the workbench to craft advanced components.
8. Unlock access to another part of the island.
9. Find the final communication component.
10. Assemble the emergency device.
11. Activate the device.
12. Complete the game.

## Core Gameplay Loop

The main gameplay loop is:

**Explore → Gather → Craft → Build → Unlock → Escape**

### Explore

The player searches the island for resources, interactive objects and important locations.

### Gather

The player collects basic resources and uses tools to gather advanced materials.

### Craft

Basic items can be crafted by hand. Advanced items require a workbench.

### Build

The player crafts and places a workbench in the game world.

### Unlock

The player creates the required tool or item to access a previously blocked area.

### Escape

The player assembles and activates an emergency communication device, completing the game.

## Victory Condition

The game is completed when the player:

1. Obtains all required components.
2. Crafts the emergency communication device.
3. Places or activates the device at the final location.
4. Sends a rescue signal.
5. Reaches the Win Screen.

The victory sequence must be triggered only once.

After victory, the player must be able to:

* View the completion time
* Restart the game
* Return to the main menu
* Quit the game
## World Scope

Version `1.0` will use one compact island divided into several connected gameplay areas.

The world must feel varied, but it should remain small enough for a complete playthrough of approximately 15–25 minutes.

The MVP will not contain multiple separate islands or a large open world.

## Location Structure

### 1. Starting Beach

The player begins on the beach near the remains of a shipwreck.

Main purposes:

* Introduce movement and interaction
* Provide the first basic resources
* Establish the shipwreck story
* Show the first objective
* Give the player a clear visual landmark

Available content:

* Shipwreck remains
* Branches
* Stones
* Basic food resource
* Small containers or debris
* A safe area for learning the controls

The player should be able to understand the first objective within the first minute.

### 2. Desert Area

The desert is the first main resource area.

Main purposes:

* Teach basic exploration
* Introduce hunger and environmental danger
* Provide materials for the first tool
* Lead the player toward the workbench progression

Available resources:

* Stones
* Dry branches
* Cactus pulp
* Plant fiber
* Metal debris from the ship

The desert must not be too large. Important resources should be visible from recognizable landmarks.

### 3. Resource Rocks

The rocky area contains materials that cannot be obtained directly at the start.

Main purposes:

* Require the player to craft a basic tool
* Introduce advanced resource gathering
* Provide materials for the workbench
* Connect the starting area with the blocked route

Available resources:

* Larger stones
* Ore or metal scrap
* Tool-dependent resources
* A chest or hidden supply container

The player should reach this area after crafting the first tool.

### 4. Workbench Area

The player may place the workbench in any valid location, but the level should contain one clearly suitable area.

The recommended placement area should be:

* Flat
* Safe
* Close to the main route
* Visually recognizable
* Large enough for placement testing
* Outside the water
* Free from overlapping props

This area acts as the central point of the gameplay loop.

The player returns here to craft advanced items.

### 5. Blocked Jungle Entrance

The jungle is initially unavailable.

The entrance may be blocked by:

* Dense vegetation
* Fallen trees
* A wooden barrier
* Large roots
* Rocks

The player must create a specific tool or item before entering.

The blocked entrance must:

* Be visible before it can be opened
* Clearly communicate that progression is required
* Display an interaction prompt
* Show which item or tool is missing
* Prevent the player from bypassing it

Opening the entrance completes a major objective.

### 6. Jungle Area

The jungle is the second main gameplay zone.

Main purposes:

* Visually reward progression
* Introduce advanced resources
* Provide the final crafting components
* Contain environmental storytelling
* Lead toward the cave or final objective

Available content:

* Wood
* Vines or stronger fiber
* Rare plants
* Advanced crafting material
* Small abandoned camps
* Ruins suggesting a previous civilization

The jungle should be more visually dense than the desert but remain easy to navigate.

### 7. Cave

The cave is a small progression location rather than a large separate level.

Main purposes:

* Contain one important final component
* Create a short change of atmosphere
* Reward exploration
* Prepare the player for the final crafting stage

Possible content:

* Metal component
* Battery part
* Radio component
* Abandoned supplies
* Environmental storytelling object

The cave should take approximately two to four minutes to explore.

It should not contain:

* A large underground maze
* Multiple floors
* Complex puzzles
* A complete enemy system
* Additional crafting stations

### 8. Second Shore

The second shore is the final location.

It becomes accessible after passing through the jungle or cave.

Main purposes:

* Provide the final visual destination
* Contain the rescue signal location
* Complete the story
* Trigger the victory sequence

Possible final objects:

* Signal tower
* Emergency radio point
* High coastal rock
* Abandoned rescue equipment
* Open area for placing the final device

The final location should have a clear view of the sea or horizon.

## Final World Progression

The intended route is:

1. Start at the shipwreck.
2. Explore the beach.
3. Gather desert resources.
4. Craft a basic tool.
5. Collect advanced resources near the rocks.
6. Craft and place the workbench.
7. Craft the item required to open the jungle.
8. Open the blocked jungle entrance.
9. Explore the jungle.
10. Find the cave.
11. Obtain the final communication component.
12. Reach the second shore.
13. Craft or assemble the emergency device.
14. Activate the rescue signal.
15. Complete the game.

## Level Design Rules

* The player should always have a visible or understandable next destination.
* The island must use natural barriers instead of obvious invisible walls whenever possible.
* The player must not be able to bypass the blocked jungle entrance.
* Required resources must exist in sufficient quantities.
* The game must provide approximately 10–20% more resources than the minimum required amount.
* Important resources must not spawn in inaccessible locations.
* The player must not become permanently stuck between objects.
* Water must clearly communicate the playable boundaries.
* Landmarks must help the player return to the workbench.
* The final route must be tested without developer tools.
* The complete island must be traversable without excessive walking.
* Each location must support the main gameplay progression.

## Out-of-Scope Locations

The following locations are not required for MVP version `1.0`:

* Additional islands
* Large underground cave network
* Procedurally generated locations
* Large Aztec city
* Multiple jungle biomes
* Underwater exploration zone
* Mountain region
* Enemy settlement
* Large player-built base
* Separate tutorial level
## Item Scope

Version `1.0` should contain only the items required for the main progression.

The recommended total is approximately 10–14 item types.

Every item must have a clear gameplay purpose.

Unused test items must be removed or excluded from the final build.

## Basic Resources

### Branch

**Category:** Basic resource
**Obtained from:** Beach and desert ground pickups
**Used for:**

* Stone Tool
* Workbench
* Other simple recipes if required

Branches must be available near the starting location.

### Stone

**Category:** Basic resource
**Obtained from:**

* Ground pickups
* Small rock deposits

**Used for:**

* Stone Tool
* Workbench

The player must be able to obtain enough stone without a tool.

### Plant Fiber

**Category:** Basic resource
**Obtained from:**

* Desert plants
* Small vegetation
* Jungle plants

**Used for:**

* Rope
* Stone Tool
* Workbench

Plant Fiber may be collected directly without a tool.

### Cactus Pulp

**Category:** Consumable resource
**Obtained from:** Desert cactus plants
**Used for:**

* Restoring hunger
* Optional small health recovery

Cactus Pulp introduces the item usage system.

The item should be available early enough for the player to test consumables.

### Wood

**Category:** Advanced resource
**Obtained from:** Trees or large branches
**Required tool:** Stone Tool or equivalent chopping tool
**Used for:**

* Workbench
* Jungle access item
* Final device components

Wood should not be obtainable in large quantities before the first tool is crafted.

### Metal Scrap

**Category:** Advanced resource
**Obtained from:**

* Shipwreck debris
* Resource rocks
* Cave supplies
* Chests

**Used for:**

* Workbench
* Battery
* Emergency communication device

The map must contain more Metal Scrap than the minimum required amount.

### Vine

**Category:** Jungle resource
**Obtained from:** Jungle plants
**Used for:**

* Strong Rope
* Final progression item
* Emergency device construction

Vine becomes available after the jungle entrance is opened.

## Crafted Materials

### Rope

**Category:** Crafted material
**Crafting station:** Hand crafting
**Created from:** Plant Fiber
**Used for:**

* Stone Tool
* Workbench
* Jungle access item

Rope acts as an intermediate crafting material.

The player should understand why it is required before crafting advanced objects.

### Battery

**Category:** Advanced component
**Crafting station:** Workbench
**Created from:**

* Metal Scrap
* Battery Parts

**Used for:** Emergency Radio or Signal Device

The Battery should be crafted only after the player reaches advanced progression.

## Tools

### Stone Tool

**Category:** Tool
**Crafting station:** Hand crafting
**Created from:**

* Branch
* Stone
* Rope

**Gameplay purpose:**

* Chop trees
* Gather Wood
* Break or clear the blocked jungle entrance
* Access advanced resources

Only one basic tool is required for MVP version `1.0`.

A separate axe, pickaxe and shovel system is not required unless they are already fully implemented and stable.

## Placeable Objects

### Workbench

**Category:** Placeable crafting station
**Crafting station:** Hand crafting
**Created from:**

* Wood
* Stone
* Rope
* Metal Scrap if required

**Gameplay purpose:**

* Unlock advanced recipes
* Craft the Battery
* Craft final communication components
* Demonstrate the building placement system

The Workbench is the only required crafting station for MVP version `1.0`.

The player must:

1. Craft the Workbench item.
2. Start placement mode.
3. Select a valid location.
4. Place the Workbench.
5. Interact with the placed object.
6. Open Workbench crafting.

## Progression Items

### Jungle Access Item

**Category:** Progression item
**Possible form:**

* Cutting Tool
* Reinforced Stone Tool
* Rope Mechanism
* Repair Component

**Crafting station:** Workbench

**Gameplay purpose:**

* Open the blocked jungle entrance
* Complete a major objective
* Prevent access to advanced resources too early

Only one jungle access item should be required.

The item must not create an additional large gameplay system.

### Battery Parts

**Category:** Progression resource
**Obtained from:**

* Jungle chest
* Cave
* Abandoned camp
* Shipwreck remains

**Used for:** Battery

Battery Parts should be visually different from ordinary Metal Scrap.

### Radio Component

**Category:** Final progression resource
**Obtained from:** Cave or final jungle location
**Used for:** Emergency Radio

Only one Radio Component is required unless several components are needed for clear progression.

The player must not be able to obtain it before reaching the final area.

## Final Item

### Emergency Radio

**Category:** Final objective item
**Crafting station:** Workbench or final assembly location
**Created from:**

* Battery
* Radio Component
* Metal Scrap
* Vine or Rope

**Gameplay purpose:**

* Activate the rescue sequence
* Complete the final objective
* Trigger the Win Screen

The Emergency Radio must not be usable before all required progression steps are complete.

Using the Radio must:

1. Validate the required state.
2. Play a sound or visual signal.
3. Disable repeated activation.
4. Complete the final objective.
5. Trigger the victory sequence.

## Optional Items

The following items may be included only if they are already implemented and do not delay release:

* Healing Plant
* Bandage
* Additional Food
* Torch
* Decorative survival items
* Optional chest rewards

Optional items must not be required to complete the game.

## Removed or Deferred Items

The following item categories are outside the MVP scope:

* Multiple weapon types
* Firearms
* Armor
* Equipment durability
* Multiple tool tiers
* Large cooking system
* Building materials for a full base
* Farming items
* Fishing equipment
* Vehicle components
* Electrical network components
* Rare collectible system
* More than one advanced crafting station

## Item Design Rules

* Every required item must participate in the main gameplay loop.
* Every required item must be obtainable during a normal playthrough.
* Required items must have assigned icons.
* Required items must have clear English names.
* Required items must have short descriptions.
* Consumable items must have configured effects.
* Buildable items must have assigned placement prefabs.
* Item quantities must always be greater than zero.
* Required resources must exist in sufficient quantities.
* The player should receive approximately 10–20% more resources than the minimum required amount.
* No item should exist only to make the crafting system appear larger.
* Unused ScriptableObject assets should not appear in the final gameplay UI.
## Crafting Scope

The crafting system must support one clear progression from basic resources to the final rescue device.

Version `1.0` should contain approximately 6–8 required recipes.

The player must not be able to skip the main crafting progression.

## Crafting Stations

### Hand Crafting

Hand crafting is available without a crafting station.

It is used for:

* Rope
* Stone Tool
* Workbench
* Basic consumables if required

Only recipes with `StationKind.None` should appear in the hand crafting panel.

### Workbench Crafting

Workbench crafting becomes available after the player places and interacts with a Workbench.

It is used for:

* Jungle Access Item
* Battery
* Emergency Radio
* Advanced components

Only recipes with `StationKind.Workbench` should appear while using the Workbench.

## Required Recipes

### Recipe 1 — Rope

**Crafting station:** Hand crafting

**Ingredients:**

* Plant Fiber ×3

**Output:**

* Rope ×1

**Purpose:**

* Introduce intermediate materials
* Prepare the player for the Stone Tool
* Prepare the player for Workbench crafting

The player must be able to craft Rope during the first few minutes.

---

### Recipe 2 — Stone Tool

**Crafting station:** Hand crafting

**Ingredients:**

* Branch ×2
* Stone ×2
* Rope ×1

**Output:**

* Stone Tool ×1

**Purpose:**

* Unlock Wood gathering
* Unlock advanced resource gathering
* Introduce tool-dependent interactions

The Stone Tool should remain usable throughout the entire short playthrough.

Tool durability is not required for MVP version `1.0`.

---

### Recipe 3 — Workbench

**Crafting station:** Hand crafting

**Ingredients:**

* Wood ×5
* Stone ×4
* Rope ×2
* Metal Scrap ×1

**Output:**

* Workbench ×1

**Purpose:**

* Introduce building placement
* Unlock advanced recipes
* Create a central progression point

The Workbench item must start placement mode when used.

The item must be removed only after successful placement.

---

### Recipe 4 — Jungle Access Item

**Working name:** Cutting Tool

**Crafting station:** Workbench

**Ingredients:**

* Wood ×2
* Metal Scrap ×2
* Rope ×1

**Output:**

* Cutting Tool ×1

**Purpose:**

* Open the blocked jungle entrance
* Prevent early access to advanced areas
* Demonstrate Workbench progression

The final name and visual design may be changed, but the item should remain mechanically simple.

Possible alternatives:

* Reinforced Stone Tool
* Jungle Machete
* Cutting Hook
* Repair Tool

Only one jungle access item should exist.

---

### Recipe 5 — Battery

**Crafting station:** Workbench

**Ingredients:**

* Metal Scrap ×3
* Battery Parts ×2
* Vine ×1

**Output:**

* Battery ×1

**Purpose:**

* Create an advanced component
* Require exploration of the jungle or cave
* Prepare the final rescue recipe

Battery Parts must not be available in unlimited quantities.

The map should contain at least one additional Battery Part beyond the required amount.

---

### Recipe 6 — Emergency Radio

**Crafting station:** Workbench

**Ingredients:**

* Battery ×1
* Radio Component ×1
* Metal Scrap ×2
* Vine ×2

**Output:**

* Emergency Radio ×1

**Purpose:**

* Complete the crafting progression
* Unlock the final rescue interaction
* Trigger the final objective

The Emergency Radio must not be craftable before the player reaches the final progression area.

---

## Optional Recipes

Optional recipes may be included only if their systems already work correctly.

### Healing Item

**Crafting station:** Hand crafting

**Ingredients:**

* Healing Plant ×2
* Plant Fiber ×1

**Output:**

* Bandage ×1

**Effect:**

* Restores a configured amount of health

This recipe is optional because health recovery may also use a directly collected consumable.

### Additional Food

**Crafting station:** Hand crafting

**Ingredients:**

* Cactus Pulp ×2

**Output:**

* Prepared Food ×1

**Effect:**

* Restores more hunger than raw Cactus Pulp

This recipe must not introduce a separate cooking station.

## Required Crafting Progression

The intended crafting order is:

1. Collect Plant Fiber.
2. Craft Rope.
3. Collect Branches and Stones.
4. Craft the Stone Tool.
5. Use the Stone Tool to gather Wood.
6. Collect Metal Scrap.
7. Craft the Workbench.
8. Place the Workbench.
9. Open Workbench crafting.
10. Craft the Jungle Access Item.
11. Open the blocked jungle entrance.
12. Collect Vine and Battery Parts.
13. Find the Radio Component.
14. Craft the Battery.
15. Craft the Emergency Radio.
16. Reach the final signal location.
17. Activate the Emergency Radio.
18. Complete the game.

## Recipe Validation Rules

Every required recipe must satisfy the following conditions:

* The recipe has at least one valid input.
* The output item is assigned.
* Every input count is greater than zero.
* The output count is greater than zero.
* The required station is assigned correctly.
* Duplicate ingredients are combined during validation.
* The player cannot craft without the total required quantity.
* Ingredients are removed only after full validation.
* The output is added only after ingredients are removed successfully.
* The inventory UI updates after crafting.
* The crafting UI updates after crafting.
* Missing ingredients are clearly displayed.
* Invalid recipes do not produce runtime exceptions.

## Resource Availability Rules

The level must contain enough resources for all required recipes.

Recommended minimum available quantities:

| Resource        | Required minimum | Recommended world amount |
| --------------- | ---------------: | -----------------------: |
| Plant Fiber     |                9 |                    11–12 |
| Branch          |                2 |                      4–5 |
| Stone           |                6 |                      8–9 |
| Wood            |                7 |                     9–10 |
| Metal Scrap     |                8 |                    10–11 |
| Rope            |        4 crafted |       Enough Fiber for 5 |
| Vine            |                3 |                      4–5 |
| Battery Parts   |                2 |                        3 |
| Radio Component |                1 |                        1 |

These values must be adjusted after the first complete playthrough.

The player should have approximately 10–20% more basic resources than the exact minimum.

Final progression components may remain limited to preserve progression clarity.

## Crafting Balance Rules

* The first crafted item should be available within approximately three minutes.
* The Stone Tool should be available within approximately five minutes.
* The Workbench should be available within approximately eight to ten minutes.
* The player should not need to collect the same resource for long periods.
* No recipe should require more than four different ingredient types.
* Required resources must not depend on random spawning.
* The player must not permanently lose a unique final component.
* Crafting must support a complete 15–25 minute playthrough.
* Optional recipes must not consume resources required for the final progression unless sufficient extra resources exist.
* Recipe costs must be reduced if testing shows unnecessary repetition or grinding.

## Deferred Crafting Features

The following systems are not required for MVP version `1.0`:

* Crafting time
* Crafting queues
* Recipe discovery
* Tool durability
* Crafting skill levels
* Workbench upgrades
* Multiple Workbench tiers
* Random crafting results
* Item quality
* Item rarity
* Large cooking system
* Crafting animations for every item
* More than one advanced crafting station
## Objective System Scope

Version `1.0` will use a simple linear objective system.

The objective system must guide the player through the main gameplay loop without introducing a complex quest architecture.

Each objective should contain:

* A short title
* A clear instruction
* A completion condition
* An optional progress value
* A completion event
* The next objective

The player should always understand what to do next.

## Objective Flow

### Objective 1 — Explore the Shipwreck

**Title:** Explore the Shipwreck

**Instruction:** Search the shipwreck remains for useful supplies.

**Purpose:**

* Introduce movement
* Introduce camera controls
* Introduce interaction
* Establish the game’s story

**Completion condition:**

* The player approaches or interacts with the main shipwreck object

**Next objective:**

* Gather Basic Resources

---

### Objective 2 — Gather Basic Resources

**Title:** Gather Basic Resources

**Instruction:** Collect Branches, Stones and Plant Fiber.

**Required progress:**

* Branch: 2
* Stone: 2
* Plant Fiber: 3

**Purpose:**

* Introduce item pickup
* Introduce the inventory
* Prepare the first crafting recipe

**Completion condition:**

* The inventory contains the required quantities

**Progress display example:**

```text
Branch: 1 / 2
Stone: 2 / 2
Plant Fiber: 2 / 3
```

**Next objective:**

* Craft Rope

---

### Objective 3 — Craft Rope

**Title:** Craft Rope

**Instruction:** Open hand crafting and create Rope.

**Required output:**

* Rope ×1

**Purpose:**

* Introduce the crafting interface
* Introduce intermediate materials
* Prepare the Stone Tool recipe

**Completion condition:**

* Rope is successfully crafted

**Next objective:**

* Craft a Stone Tool

---

### Objective 4 — Craft a Stone Tool

**Title:** Craft a Stone Tool

**Instruction:** Use Branches, Stones and Rope to craft a Stone Tool.

**Required output:**

* Stone Tool ×1

**Purpose:**

* Introduce tools
* Unlock advanced resource gathering
* Prepare the player for Wood gathering

**Completion condition:**

* Stone Tool is successfully crafted

**Next objective:**

* Gather Wood and Metal Scrap

---

### Objective 5 — Gather Advanced Resources

**Title:** Gather Advanced Resources

**Instruction:** Use the Stone Tool to collect Wood and find Metal Scrap.

**Required progress:**

* Wood: 5
* Metal Scrap: 1
* Stone: 4
* Rope: 2

The exact progress values may be adjusted after testing.

**Purpose:**

* Introduce tool-dependent gathering
* Introduce chopping or mining
* Prepare the Workbench recipe

**Completion condition:**

* The inventory contains the required Workbench materials

**Next objective:**

* Craft a Workbench

---

### Objective 6 — Craft a Workbench

**Title:** Craft a Workbench

**Instruction:** Craft a Workbench using the collected resources.

**Required output:**

* Workbench ×1

**Purpose:**

* Introduce buildable items
* Prepare the placement system
* Unlock advanced crafting progression

**Completion condition:**

* Workbench item is successfully crafted

**Next objective:**

* Place the Workbench

---

### Objective 7 — Place the Workbench

**Title:** Place the Workbench

**Instruction:** Find a flat location and place the Workbench.

**Purpose:**

* Introduce placement mode
* Introduce valid and invalid placement positions
* Create the main crafting station

**Completion condition:**

* A Workbench is successfully placed in the world

The objective must not complete when placement mode starts.

The objective completes only after the real Workbench prefab is created.

**Next objective:**

* Craft the Jungle Access Item

---

### Objective 8 — Prepare for the Jungle

**Title:** Prepare for the Jungle

**Instruction:** Use the Workbench to craft a tool for clearing the blocked entrance.

**Required output:**

* Jungle Access Item ×1

**Possible final item name:**

* Cutting Tool
* Jungle Machete
* Reinforced Tool

**Purpose:**

* Introduce Workbench crafting
* Separate basic and advanced recipes
* Prepare the blocked-area progression

**Completion condition:**

* The Jungle Access Item is successfully crafted

**Next objective:**

* Open the Jungle Entrance

---

### Objective 9 — Open the Jungle Entrance

**Title:** Open the Jungle Entrance

**Instruction:** Use the new tool to clear the blocked path.

**Purpose:**

* Reward crafting progression
* Unlock the second major gameplay zone
* Introduce a world-state change

**Completion condition:**

* The blocked entrance is permanently opened

The objective must not complete merely because the player owns the required tool.

It completes after the entrance interaction finishes.

**Next objective:**

* Explore the Jungle

---

### Objective 10 — Explore the Jungle

**Title:** Explore the Jungle

**Instruction:** Search the jungle for advanced materials and abandoned supplies.

**Required progress:**

* Vine: 3
* Battery Parts: 2

**Purpose:**

* Reward access to the new zone
* Introduce jungle resources
* Prepare the Battery recipe

**Completion condition:**

* The player obtains the required Vine and Battery Parts

**Next objective:**

* Find the Radio Component

---

### Objective 11 — Find the Radio Component

**Title:** Find the Radio Component

**Instruction:** Search the cave for the missing communication component.

**Required item:**

* Radio Component ×1

**Purpose:**

* Lead the player toward the cave
* Create a short exploration goal
* Provide the unique final component

**Completion condition:**

* The Radio Component is added to the inventory

**Next objective:**

* Craft a Battery

---

### Objective 12 — Craft a Battery

**Title:** Craft a Battery

**Instruction:** Return to the Workbench and assemble a Battery.

**Required output:**

* Battery ×1

**Purpose:**

* Return the player to the main crafting station
* Complete the advanced component stage
* Prepare the final recipe

**Completion condition:**

* Battery is successfully crafted

**Next objective:**

* Build the Emergency Radio

---

### Objective 13 — Build the Emergency Radio

**Title:** Build the Emergency Radio

**Instruction:** Use the Workbench to assemble the Emergency Radio.

**Required output:**

* Emergency Radio ×1

**Purpose:**

* Complete the crafting progression
* Prepare the final journey
* Unlock the victory interaction

**Completion condition:**

* Emergency Radio is successfully crafted

**Next objective:**

* Reach the Signal Point

---

### Objective 14 — Reach the Signal Point

**Title:** Reach the Signal Point

**Instruction:** Find a clear location on the second shore to send the rescue signal.

**Purpose:**

* Lead the player to the final location
* Create a clear ending route
* Prepare the final interaction

**Completion condition:**

* The player enters the final signal area

**Next objective:**

* Send the Rescue Signal

---

### Objective 15 — Send the Rescue Signal

**Title:** Send the Rescue Signal

**Instruction:** Activate the Emergency Radio and call for help.

**Required conditions:**

* The player owns the Emergency Radio
* The player is inside the final signal area
* Victory has not already been triggered

**Purpose:**

* Complete the game
* Trigger the final feedback
* Open the Win Screen

**Completion condition:**

* The rescue device is successfully activated

**Result:**

* Final signal effect plays
* Player input is disabled
* Victory state is activated
* Win Screen appears
* Completion time is displayed

## Objective UI

The objective interface should display:

* Current objective title
* Short instruction
* Optional progress values
* Completion feedback

Recommended screen position:

* Upper-left or upper-right corner
* Away from survival bars
* Visible without blocking gameplay

Example:

```text
GATHER BASIC RESOURCES

Branch: 1 / 2
Stone: 2 / 2
Plant Fiber: 2 / 3
```

## Objective Completion Feedback

When an objective is completed:

1. The current objective receives a completed state.
2. A short sound is played.
3. A small UI animation is displayed.
4. The next objective appears after a short delay.
5. The event cannot be triggered repeatedly.

The transition should be brief and must not stop gameplay for long periods.

## Objective Progress Tracking

Objective progress may be updated through gameplay events such as:

* Inventory changed
* Item crafted
* Object placed
* Resource gathered
* Area entered
* Interaction completed
* Final device activated

The system should avoid checking every condition in `Update()`.

Event-driven progress is preferred.

## Objective System Rules

* Only one main objective should be active at a time.
* Every objective must have a clear completion condition.
* Objectives must not rely only on UI button presses.
* Progress must be based on actual gameplay state.
* Completed objectives cannot activate again.
* The next objective must not start more than once.
* Restarting the game resets the objective sequence.
* The first objective starts automatically.
* Objective UI must update immediately.
* Missing objective data must not cause runtime errors.
* The player must not become permanently blocked by losing a required unique item.
* The complete objective sequence must work in the Windows build.

## Objective Failure Prevention

The game must prevent progression blockers.

Required protections:

* Unique final components cannot be permanently destroyed.
* Required items cannot disappear without being added to the inventory.
* A failed placement does not consume the Workbench item.
* The blocked entrance cannot remain closed after successful interaction.
* Victory cannot be triggered without the Emergency Radio.
* Victory cannot trigger more than once.
* Restarting restores the initial world and objective state.

## Deferred Objective Features

The following features are not required for MVP version `1.0`:

* Optional side quests
* Multiple simultaneous quests
* Dialogue-based objectives
* Branching quest paths
* Quest rewards system
* Quest journal
* Objective markers for every resource
* Random objectives
* Daily quests
* Complex narrative choices
* Objective persistence between game sessions
  Survival System Scope

Version 1.0 will use a simplified survival system designed for a short 15–25 minute playthrough.

The survival mechanics should create light pressure and demonstrate gameplay systems without forcing the player to spend most of the game managing status bars.

Required Survival Parameters

The MVP will contain:

Health
Stamina
Hunger
Temperature, only if it can be completed without delaying the release

Dynamic thirst is not required unless it is already fully implemented and stable.

Health

Health represents the player’s ability to survive damage.

Health rules
Health has a minimum value of 0.
Health has a configurable maximum value.
Damage reduces health.
Healing effects restore health.
Health cannot exceed its maximum value.
Health cannot fall below zero.
Reaching zero starts the death sequence.
Health cannot change after death unless the game is restarted.
Health returns to its initial value after restart.
Health recovery

The player must have at least one reliable way to restore health.

Possible recovery item:

Healing Plant
Bandage
Cactus Pulp with a small healing effect

The preferred option for MVP is one simple healing consumable.

The player should not need a complex medical or injury system.

Health UI

The HUD must display:

Current health
Maximum health
Clear visual changes after damage
Clear visual changes after healing

The exact numeric value may be hidden if the bar communicates the state clearly.

Damage

Damage may be received from:

Hunger reaching zero
Extreme temperature, if enabled
Falling
Environmental hazards
Test or scripted gameplay events

Combat damage is not required for MVP version 1.0.

Damage rules
Every damage source must use the main player damage method.
Damage must not directly modify the UI.
Damage must update health through the survival system.
Damage cannot trigger death more than once.
Damage cannot continue after the player has died.
Repeated damage sources must use a reasonable interval.
Damage events must provide visual or audio feedback.
Damage feedback

At least two of the following should be used:

Camera shake
Screen flash
Damage sound
HUD animation
Character animation

The feedback must not prevent the player from seeing or controlling the game.

Stamina

Stamina limits sprinting and may optionally support swimming.

Stamina rules
Stamina decreases only while the player is performing an action that consumes stamina.
Standing still must not consume stamina.
Walking must not consume stamina.
Sprinting consumes stamina.
Stamina cannot fall below zero.
Stamina cannot exceed its maximum value.
Sprinting stops or becomes unavailable when stamina reaches zero.
Stamina begins recovering after a short delay.
Stamina recovers while the player is not sprinting.
Stamina resets correctly after restart.
Stamina balance

The player should be able to sprint long enough to make movement comfortable.

Recommended starting values:

Sprint duration: approximately 5–8 seconds
Recovery delay: approximately 1 second
Full recovery time: approximately 3–5 seconds

These values must be adjusted during playtesting.

The player should not spend long periods waiting for stamina to recover.

Hunger

Hunger creates light time pressure and demonstrates consumable item usage.

Hunger rules
Hunger gradually decreases over time.
Hunger cannot fall below zero.
Hunger cannot exceed its maximum value.
Food restores hunger.
Food is consumed after successful use.
Hunger reaching zero starts periodic health damage.
Hunger damage must not happen every frame.
Hunger returns to its starting value after restart.
Hunger recovery

The player must be able to recover hunger through at least one item.

Required food item:

Cactus Pulp

Possible optional food item:

Prepared Food

Cactus Pulp should be available in the starting or desert area.

Food must clearly display:

Item name
Hunger restoration amount
Quantity in the inventory
Hunger balance

Hunger should not become dangerous during the first few minutes.

Recommended behavior:

The player begins with full or nearly full hunger.
Hunger reaches a noticeable level after approximately 8–12 minutes.
Hunger reaches zero only during a slow or intentionally long playthrough.
The map contains enough food for the complete game.
The player is taught how to use food before hunger becomes critical.

Hunger must support the game loop rather than interrupt it.

Temperature

Temperature is a conditional MVP system.

It may remain in version 1.0 only if it can be completed and balanced without delaying the core gameplay loop.

Temperature states

The system may use three simple states:

Cold
Comfortable
Hot

Exact physical temperature simulation is not required.

Temperature rules
The player begins in the comfortable range.
Hot areas increase temperature.
Cold areas decrease temperature.
Normal areas gradually return temperature toward the comfortable range.
Temperature cannot change infinitely beyond its configured limits.
Extreme states may cause damage after a delay.
Temperature returns to its initial value after restart.
Possible environment influences
Desert increases temperature.
Water decreases temperature.
Cave decreases temperature.
Night decreases temperature.
Fire or shelter may increase temperature only if already implemented.

The system must not require clothing, shelter construction or complex equipment.

Temperature MVP decision

Temperature should be disabled for version 1.0 if any of the following are true:

Environment zones are not implemented.
The UI does not clearly communicate the temperature state.
The system causes unavoidable damage.
The system requires several new item types.
Balancing it delays the victory condition.
It does not improve the short gameplay experience.

Disabling temperature is acceptable because the portfolio already demonstrates several other survival systems.

Swimming

Swimming is required because water is part of the island boundary and player movement architecture.

Swimming rules
Entering water changes the movement state to swimming.
The player does not continuously fall to the bottom.
The player can move horizontally.
The player can move upward and downward.
The player naturally stays near the surface without vertical input.
Leaving water restores the appropriate grounded or airborne state.
Repeated water entry and exit work correctly.
Swimming cannot permanently lock player controls.
Water movement works in the Windows build.
Swimming feedback

Recommended feedback:

Water entry sound
Swimming loop sound
Underwater screen overlay
Reduced camera movement
Small splash effect

Complex underwater exploration and oxygen mechanics are not required.

Death

The death system connects survival failure to the main game flow.

Death sequence

When health reaches zero:

Death is triggered only once.
Movement is disabled.
Camera control is disabled.
Interaction is disabled.
Open gameplay panels are closed.
A death animation or visual effect is played.
The Game Over screen appears.
The player may restart or return to the main menu.
Death UI

The Game Over screen must contain:

Death message
Restart button
Main Menu button
Quit button

An explanation of the death cause is optional.

Restart after death

Restarting must reset:

Health
Stamina
Hunger
Temperature, if enabled
Inventory
Objectives
World resources
Opened chests
Placed objects
Blocked passages
Cursor state
Time.timeScale

The restart must not create duplicate manager objects.

Survival UI

The final HUD should prioritize clarity.

Required bars:

Health
Stamina
Hunger

Conditional bar:

Temperature

The HUD should not display systems that are disabled.

UI rules
Every value updates immediately after a change.
Bars use consistent sizes and visual style.
Critical values receive a noticeable state.
HUD elements do not cover interaction prompts.
UI remains readable at 1920×1080.
UI remains usable at one additional common resolution.
The HUD is hidden or disabled after victory.
Survival Balance Targets

The survival systems should support these target outcomes:

The player can finish the game without dying during a normal first playthrough.
The player may die if survival mechanics are completely ignored.
Food is useful but does not require constant consumption.
Stamina improves movement decisions but does not make exploration slow.
Environmental damage is predictable.
The player receives warning before health becomes critical.
The survival systems do not extend the game through artificial waiting.
Required Survival Events

The systems should expose or use events for:

Health changed
Damage received
Player healed
Hunger changed
Food consumed
Stamina changed
Temperature state changed
Player died

UI and feedback systems should react to these events instead of repeatedly checking values in Update() where possible.

Survival Validation Rules
All maximum values must be greater than zero.
Initial values must remain within their allowed ranges.
Increase methods must clamp values.
Decrease methods must clamp values.
Damage intervals must not be zero or negative.
Consumable effects must use the configured value directly.
One-time item effects must not multiply their value by Time.deltaTime.
Missing UI references must not stop the gameplay system.
Death events must not be invoked multiple times.
Event subscriptions must be removed correctly.
Deferred Survival Features

The following features are outside the MVP scope:

Thirst, unless already complete
Oxygen system
Diseases
Poison
Injuries to separate body parts
Bleeding
Sleep
Fatigue
Complex body temperature simulation
Clothing insulation
Wetness
Shelter protection
Cooking temperature
Food expiration
Status effect stacking
Advanced medicine
Permanent character progression
## UI and Input Scope

Version `1.0` will use UI Toolkit for all main gameplay interfaces.

The interface must remain simple, readable and consistent across all screens.

The player should always understand:

* Current survival state
* Current objective
* Available interaction
* Inventory contents
* Crafting requirements
* Whether placement is valid
* Whether the game is paused
* Whether the player has died or completed the game

## Required UI Screens

The MVP must contain:

* Main Menu
* Gameplay HUD
* Interaction Prompt
* Inventory
* Hand Crafting Panel
* Workbench Crafting Panel
* Placement Instructions
* Objective UI
* Pause Menu
* Game Over Screen
* Win Screen

Optional settings screens are not required for version `1.0`.

## Main Menu

The Main Menu is the first screen shown after launching the game.

Required buttons:

* Start Game
* Quit Game

Optional buttons:

* Settings
* Credits

### Main Menu rules

* The cursor is visible and unlocked.
* Player movement is not active.
* Camera movement is not active.
* Starting the game loads the gameplay scene.
* Quit closes the application.
* The menu works in the Windows build.
* Missing save data must not prevent starting a new game.

A save selection screen is not required.

## Gameplay HUD

The Gameplay HUD must display only information needed during normal gameplay.

Required elements:

* Health bar
* Stamina bar
* Hunger bar
* Current objective
* Crosshair
* Interaction prompt

Conditional elements:

* Temperature bar
* Objective progress
* Temporary notification messages

### HUD rules

* The HUD is visible during normal gameplay.
* The HUD does not block the center of the screen.
* Survival bars update immediately.
* The objective is readable without opening another panel.
* The HUD is hidden or dimmed after death.
* The HUD is hidden or dimmed after victory.
* The HUD remains visible when no menu is open.
* Disabled systems must not leave empty UI elements.

## Crosshair

The crosshair helps the player aim at interaction targets.

### Crosshair states

Recommended states:

* Default
* Valid interaction target
* Hold interaction in progress
* Placement mode
* Interaction unavailable

The crosshair may change:

* Size
* Opacity
* Shape
* Visual state

The crosshair should remain small and must not hide the target.

## Interaction Prompt

The Interaction Prompt appears when the player looks at a valid interactable object.

Recommended format:

```text
[E] Pick up Branch
```

Or:

```text
Hold [E] to Chop Tree
```

### Required information

* Input button
* Action
* Target name
* Optional progress bar

### Interaction Prompt rules

* It appears only for a valid target.
* It disappears when the player looks away.
* It disappears outside interaction range.
* It disappears after the target is destroyed.
* It updates when the target changes.
* Hold progress resets after cancellation.
* It is hidden while inventory is open.
* It is hidden while crafting is open.
* It is hidden while the game is paused.
* It is hidden after death and victory.

## Inventory UI

The inventory displays all currently owned items.

Required information for every item:

* Item icon
* Item name
* Quantity
* Selected state

Optional information:

* Short description
* Item category
* Item effect
* Use button

### Inventory behavior

The player opens and closes the inventory using one configured input.

Recommended input:

```text
Tab
```

Alternative input:

```text
I
```

Only one final input should be used consistently.

### Inventory rules

When the inventory opens:

* Player movement is disabled.
* Sprinting stops.
* Camera movement is disabled.
* Interaction is disabled.
* The cursor becomes visible.
* The cursor becomes unlocked.
* The inventory receives focus.

When the inventory closes:

* Movement is restored.
* Camera movement is restored.
* Interaction is restored.
* The cursor becomes hidden.
* The cursor becomes locked.

### Item selection

Selecting an item should display:

* Name
* Description
* Quantity
* Available action

Possible actions:

* Use
* Start Placement
* Close Details

Dropping items is not required for MVP version `1.0`.

## Item Usage UI

Usable items must clearly communicate their effect.

Example:

```text
Cactus Pulp
Restores 20 Hunger
```

Or:

```text
Bandage
Restores 30 Health
```

### Item Usage rules

* A Use button appears only for usable items.
* Buildable items display a Place button instead.
* Resource items do not display a Use button.
* Using an item updates the inventory immediately.
* The player receives confirmation after successful use.
* The player receives feedback when an item cannot be used.
* An item with no configured effect must not be consumed.
* One unit is removed per successful use.

## Crafting UI

Hand crafting and Workbench crafting may use the same visual panel.

The panel must receive the current crafting station type.

Required elements:

* Panel title
* Recipe list
* Selected recipe
* Ingredient slots
* Output item
* Craft button
* Close button

### Recipe card information

Every recipe card should display:

* Output icon
* Output name
* Ingredient summary
* Availability state

### Selected recipe information

The selected recipe should display:

* Ingredient icons
* Required quantity
* Current quantity
* Output icon
* Output quantity

Example:

```text
Plant Fiber
2 / 3
```

Missing quantities should be visually distinct.

### Craft button rules

The Craft button is enabled only when:

* A recipe is selected.
* Every ingredient is valid.
* The inventory contains the required total quantities.
* The output item is valid.

The button is disabled when resources are insufficient.

Pressing the button repeatedly must not create items without resources.

## Hand Crafting Panel

The title should clearly indicate hand crafting.

Recommended title:

```text
CRAFTING
```

Only recipes with:

```csharp
StationKind.None
```

should be visible.

The player should be able to open this panel without standing near a Workbench.

## Workbench Crafting Panel

The title should indicate the active station.

Recommended title:

```text
WORKBENCH
```

Only recipes with:

```csharp
StationKind.Workbench
```

should be visible.

The panel opens after interacting with a placed Workbench.

The panel closes when:

* The player presses Escape.
* The player presses the Close button.
* The player moves too far from the Workbench.
* The Workbench becomes unavailable.
* The player dies.

## Placement UI

Placement mode must display clear instructions.

Recommended format:

```text
Left Mouse Button — Place
R — Rotate
Right Mouse Button — Cancel
```

The exact buttons may be changed to match the input system.

### Placement feedback

The ghost object must clearly indicate:

* Valid position
* Invalid position

Recommended behavior:

* Valid material or tint
* Invalid material or tint
* Clear change when overlap begins

Do not rely only on small text messages.

### Placement UI rules

* Inventory and crafting panels close before placement begins.
* The cursor returns to gameplay mode.
* Interaction prompts are hidden.
* The crosshair may change to placement mode.
* Cancel returns the item to normal inventory state.
* Successful placement closes placement mode.
* Placement instructions disappear after completion or cancellation.

## Objective UI

The Objective UI displays the current main task.

Required elements:

* Objective title
* Short instruction
* Optional progress

Example:

```text
GATHER BASIC RESOURCES

Branch: 1 / 2
Stone: 2 / 2
Plant Fiber: 2 / 3
```

### Objective UI rules

* Only one main objective is displayed.
* Progress updates immediately.
* Completed objectives show short feedback.
* The next objective appears automatically.
* The objective does not cover survival bars.
* The objective remains readable during bright and dark lighting.
* The objective resets after game restart.

## Notification Messages

Short temporary messages may be used for:

* Item collected
* Item used
* Item crafted
* Inventory full, if capacity is implemented
* Missing tool
* Missing resources
* Objective completed
* Invalid placement
* New area unlocked

Example:

```text
Stone Tool crafted
```

Or:

```text
You need a Cutting Tool
```

### Notification rules

* Messages disappear automatically.
* Messages do not permanently stack.
* Repeated messages do not cover the screen.
* Critical information remains visible long enough to read.
* Notifications are not a replacement for clear UI states.

## Pause Menu

Recommended input:

```text
Escape
```

The Pause Menu must contain:

* Resume
* Restart
* Main Menu
* Quit

### Pause behavior

When the Pause Menu opens:

* `Time.timeScale` becomes `0`.
* Player movement is disabled.
* Camera movement is disabled.
* Interaction is disabled.
* The cursor becomes visible.
* The cursor becomes unlocked.
* Gameplay UI remains behind the menu or is dimmed.

When the Pause Menu closes:

* `Time.timeScale` becomes `1`.
* Gameplay input is restored.
* The cursor is hidden.
* The cursor is locked.

### Pause restrictions

The Pause Menu must not open:

* During the Game Over screen
* During the Win Screen
* During scene loading

If inventory or crafting is open, pressing Escape should first close the active panel before opening Pause.

## Game Over Screen

The Game Over screen appears after the death sequence.

Required elements:

* Game Over title
* Restart button
* Main Menu button
* Quit button

Optional elements:

* Cause of death
* Survival time
* Collected resources

### Game Over rules

* Gameplay input is disabled.
* Interaction is disabled.
* The cursor is visible and unlocked.
* The screen appears only once.
* Restart resets the complete gameplay state.
* Main Menu loads the menu scene.
* Quit closes the application.

## Win Screen

The Win Screen appears after the rescue signal is successfully activated.

Required elements:

* Victory message
* Completion time
* Restart button
* Main Menu button
* Quit button

Optional information:

* Items crafted
* Resources collected
* Objectives completed

### Win Screen rules

* Victory is triggered only once.
* Player movement is disabled.
* Camera movement is disabled.
* Interaction is disabled.
* The HUD is hidden or dimmed.
* The cursor is visible and unlocked.
* `Time.timeScale` is set to the intended value.
* Restart resets the complete game.
* Main Menu loads correctly.
* Quit works in the Windows build.

## Cursor State Rules

The project must use one centralized method for cursor control.

### Gameplay state

```csharp
Cursor.visible = false;
Cursor.lockState = CursorLockMode.Locked;
```

### Menu state

```csharp
Cursor.visible = true;
Cursor.lockState = CursorLockMode.None;
```

Cursor state must update correctly for:

* Main Menu
* Gameplay
* Inventory
* Crafting
* Pause
* Game Over
* Win Screen
* Scene restart

Multiple UI controllers should not independently fight over the cursor state.

A central UI or input controller is recommended.

## Input Blocking Rules

Only one major interaction mode should be active at a time.

Possible modes:

* Gameplay
* Inventory
* Crafting
* Placement
* Paused
* Dead
* Victory

### Gameplay

Allowed:

* Movement
* Camera
* Interaction
* Jump
* Sprint

### Inventory

Allowed:

* UI interaction
* Item selection
* Item usage

Blocked:

* Movement
* Camera
* World interaction
* Sprint
* Jump

### Crafting

Allowed:

* Recipe selection
* Crafting
* UI interaction

Blocked:

* Movement
* Camera
* World interaction
* Placement

### Placement

Allowed:

* Camera aiming
* Preview movement
* Rotation
* Placement confirmation
* Cancellation

Blocked:

* Normal interaction
* Inventory use
* Crafting

### Paused

Allowed:

* Pause menu interaction

Blocked:

* All gameplay input

### Dead or Victory

Allowed:

* Final screen buttons

Blocked:

* All gameplay input

## Required Inputs

Recommended final control scheme:

| Action               | Input              |
| -------------------- | ------------------ |
| Move                 | WASD               |
| Look                 | Mouse              |
| Jump                 | Space              |
| Sprint               | Left Shift         |
| Interact             | E                  |
| Open Inventory       | Tab                |
| Open Hand Crafting   | C                  |
| Pause or Close Panel | Escape             |
| Confirm Placement    | Left Mouse Button  |
| Rotate Placement     | R                  |
| Cancel Placement     | Right Mouse Button |

The final controls must be displayed:

* In the README
* On the itch.io page
* Optionally in the Main Menu or Pause Menu

## UI Visual Rules

All UI screens should use:

* One main font family
* One secondary font only if necessary
* Consistent button height
* Consistent spacing
* Consistent corner radius
* Consistent icon sizes
* Consistent hover states
* Consistent disabled states

The interface should use one clear accent color.

The accent color should highlight:

* Selected items
* Valid actions
* Objective progress
* Important buttons

Danger states should use a separate warning treatment.

## UI Resolution Requirements

The UI must be tested at:

* `1920×1080`
* At least one additional common resolution

Recommended additional test:

* `1600×900`
* `1366×768`
* `1920×1200`

The interface must not:

* Cut off text
* Move buttons outside the screen
* Overlap survival bars
* Break with long item names
* Make interaction prompts unreadable

## Deferred UI Features

The following UI features are not required for MVP version `1.0`:

* Full settings menu
* Key rebinding
* Controller support
* Accessibility menu
* Multiple save slots
* Minimap
* Large quest journal
* Item drag and drop
* Item sorting filters
* Multiple inventory pages
* Character equipment screen
* Skill tree
* Map screen
* Localization system
## Audio and Visual Feedback Scope

Version `1.0` must provide clear feedback for the player’s main actions.

The goal is not to create a large cinematic presentation. The goal is to make every important action understandable, responsive and satisfying.

The player should be able to recognize successful and unsuccessful actions through:

* Sound
* UI response
* Animation
* Particle effects
* Camera feedback
* Changes in the world

## Audio Scope

The final game must contain audio for the most important gameplay actions.

## Required Gameplay Sounds

### Player Movement

Required sounds:

* Walking footsteps
* Sprinting footsteps
* Jump
* Landing
* Entering water
* Swimming

### Footstep rules

* Footsteps play only while the player is moving.
* Sprint footsteps are faster than walking footsteps.
* Footsteps stop when the player stops.
* Footsteps do not play while the player is airborne.
* Footsteps do not play during swimming.
* Repeated sounds should use slight pitch or volume variation when possible.
* Footsteps must not restart every frame.

Different surface sounds are optional for MVP version `1.0`.

---

### Interaction Sounds

Required sounds:

* Item pickup
* Resource chopping
* Resource digging or breaking
* Chest opening
* Invalid interaction
* Blocked progression interaction

Examples:

* Picking up a Branch plays a short pickup sound.
* Chopping a tree plays a hit sound.
* Attempting to open the jungle without the required tool plays an unavailable sound.

### Interaction audio rules

* Audio plays only after the interaction is accepted.
* Failed interactions use different feedback from successful interactions.
* Repeated interaction must not create excessive overlapping audio.
* Destroyed objects must not continue playing looping sounds.

---

### Inventory and Item Sounds

Required sounds:

* Inventory open
* Inventory close
* Item selected
* Item used
* Item cannot be used

Optional sounds:

* Slot hover
* Item quantity changed
* Item details opened

UI sounds should remain quiet compared with gameplay sounds.

---

### Crafting Sounds

Required sounds:

* Successful craft
* Failed craft or insufficient resources
* Workbench panel open
* Workbench panel close

The successful crafting sound should play only when:

* All resources were validated.
* Ingredients were removed.
* The output item was added.

Pressing a disabled Craft button must not play a success sound.

---

### Placement Sounds

Required sounds:

* Placement mode started
* Building rotated, optional
* Valid placement confirmed
* Invalid placement attempt
* Placement cancelled

The final placement sound must play only after the real building prefab is created.

---

### Survival Sounds

Required sounds:

* Player damage
* Health recovery
* Food consumed
* Low-health warning, optional
* Death

Possible additional sounds:

* Hunger warning
* Extreme temperature warning
* Stamina exhausted

Warning sounds must not repeat too frequently.

---

### Objective and Game Flow Sounds

Required sounds:

* Objective completed
* New objective displayed
* Game paused, optional
* Game resumed, optional
* Game Over
* Victory
* Rescue signal activation

The victory sound should be clearly different from ordinary objective completion.

## Ambient Audio

The island should contain at least one ambient sound layer.

Possible ambience:

* Ocean waves
* Wind
* Distant birds
* Jungle insects
* Cave ambience

Recommended area ambience:

### Beach and Desert

* Ocean
* Light wind
* Occasional birds

### Jungle

* Insects
* Birds
* Leaves
* Reduced ocean volume

### Cave

* Wind or low rumble
* Water drops
* Reduced exterior ambience

A complex dynamic audio mixer is not required, but volume transitions should not be abrupt.

## Audio Management Rules

* Audio clips should not be played directly from many unrelated scripts when a centralized solution is practical.
* Repeated actions should use reusable audio methods.
* Gameplay audio should respect global volume settings if they are later added.
* AudioSource components should use appropriate spatial settings.
* UI sounds should usually be non-spatial.
* World sounds should use spatial audio when appropriate.
* Looping sounds must stop when their source becomes inactive.
* Missing AudioClips must not cause runtime exceptions.
* Audio volume must be checked in the Windows build.

## Minimum Audio Categories

Recommended Audio Mixer groups:

* Master
* Music
* Ambience
* Gameplay
* UI

A full settings menu is not required, but separating categories will improve future development.

## Music

Music is optional for MVP version `1.0`.

Possible use:

* Quiet Main Menu music
* Low-intensity exploration music
* Short victory music

Music must not:

* Cover gameplay sounds
* Loop with obvious gaps
* Become too intense for normal exploration
* Delay the release

One simple ambient track is enough.

## Visual Feedback Scope

Important gameplay actions must produce visible feedback.

## Interaction Highlight

A valid interaction target should be visually recognizable.

Possible methods:

* Outline
* Material change
* Crosshair change
* Small target indicator
* Interaction prompt

The project should avoid creating new material instances every frame.

### Highlight rules

* Highlight activates only for the current target.
* Previous targets return to their normal appearance.
* Highlight disappears when the target is destroyed.
* Highlight does not remain after looking away.
* Placement ghost objects are not highlighted as normal interactables.

## Pickup Feedback

Picking up an item should provide:

* Pickup sound
* Inventory quantity update
* Temporary notification
* Optional small visual effect

Example:

```text
Branch collected
```

The world item should disappear only after the inventory accepts the item.

## Resource Gathering Feedback

Chopping, digging or breaking resources should provide:

* Interaction progress
* Hit sound
* Small camera feedback
* Particles
* Resource removal or state change
* Inventory notification

Possible particle examples:

* Wood chips
* Dust
* Small stones
* Leaves

Particles should remain simple and lightweight.

## Damage Feedback

Receiving damage should provide at least two forms of feedback.

Required minimum:

* Screen flash or overlay
* Damage sound

Recommended additional feedback:

* Camera shake
* HUD animation
* Short vignette
* Directional indicator, optional

### Camera shake rules

* The original camera position is initialized before the first shake.
* Shake strength matches the damage intensity.
* Repeated damage does not permanently move the camera.
* Camera returns to its expected local position.
* Shake does not override other camera systems permanently.

## Healing and Food Feedback

Using a consumable should provide:

* Inventory quantity update
* Survival bar update
* Use sound
* Temporary notification
* Optional screen effect

Examples:

```text
Health restored
```

```text
Hunger restored
```

The effect should appear only after the item was successfully consumed.

## Crafting Feedback

Successful crafting should provide:

* Craft sound
* Short output animation
* Notification with the crafted item name
* Updated inventory
* Updated ingredient values
* Updated Craft button state

Example:

```text
Stone Tool crafted
```

Failed crafting should clearly indicate missing resources without showing success feedback.

## Placement Feedback

The placement preview must clearly communicate whether placement is allowed.

### Valid placement

Recommended feedback:

* Green or neutral valid tint
* Enabled confirmation input
* Optional subtle placement indicator

### Invalid placement

Recommended feedback:

* Red tint
* Disabled confirmation
* Short reason message

Possible messages:

```text
Cannot place inside another object
```

```text
Cannot place in water
```

```text
Surface is too steep
```

The player should not need to guess why placement failed.

## Chest Feedback

Opening a chest should provide:

* Opening animation or visible lid change
* Sound
* Reward notification
* Permanent opened state

An opened chest should look different from a closed chest.

The chest must not appear reusable if its reward can only be collected once.

## Objective Feedback

Completing an objective should provide:

* Completion sound
* Short UI animation
* Completed state
* New objective transition

The feedback should last approximately one to two seconds.

It must not interrupt player movement for a long period.

## Area Unlock Feedback

Opening the jungle entrance should feel like a major progression moment.

Recommended feedback:

* Barrier animation or destruction
* Particles
* Sound
* Objective completion
* New objective
* Clear view into the unlocked area

The barrier should not simply disappear without explanation unless production time is limited.

A short scripted animation is enough.

## Death Feedback

The death sequence should include:

* Disabled controls
* Camera or character reaction
* Screen fade or visual effect
* Death sound
* Game Over screen

A complex ragdoll system is not required.

A simple animation, camera drop or fade is acceptable.

## Victory Feedback

Activating the Emergency Radio should include:

1. Activation interaction.
2. Radio or signal sound.
3. Light, particle or antenna effect.
4. Final objective completion.
5. Short delay.
6. Player input disabled.
7. Win Screen displayed.

Possible visual signals:

* Flashing beacon
* Rising smoke
* Signal light
* Radio antenna animation
* Distant rescue vehicle silhouette, optional

The final effect should be visible in the portfolio trailer.

## Environment Polish

The final island should use visual polish strategically.

Required areas of focus:

* Starting beach
* Workbench location
* Blocked jungle entrance
* Jungle route
* Cave entrance
* Final signal point

These areas should receive more attention than unreachable decorative parts of the map.

## Environment Feedback

The environment should help guide the player through:

* Landmarks
* Lighting
* Paths
* Object placement
* Color contrast
* Open views toward important locations

Examples:

* Shipwreck marks the starting area.
* Large rocks mark the resource zone.
* Dense vegetation marks the jungle entrance.
* Distinct cave lighting marks the final component location.
* Open sea view marks the signal point.

## Lighting Scope

Version `1.0` should contain stable and readable lighting.

Required lighting goals:

* The player can see interaction targets.
* Important areas are visually distinct.
* The night is readable if the day/night cycle remains enabled.
* The cave is dark but navigable.
* The final location has a clear focal point.
* UI remains readable in all lighting conditions.

Lighting must not prioritize realism over gameplay clarity.

## Day/Night Visual Scope

If the full day/night system remains in MVP:

* Sun rotation must be smooth.
* Light intensity must change smoothly.
* Exposure must remain controlled.
* Sky transitions must not be abrupt.
* Night must not become completely black.
* Important gameplay areas must remain visible.

If the full system causes instability, use a fixed time of day or one scripted transition for version `1.0`.

## Performance Rules for Visual Effects

* Particle systems must use limited particle counts.
* Effects must stop after completion.
* Materials must not be instantiated every frame.
* Transparent effects must be used carefully in HDRP.
* Repeated interactions must not leave hidden effects in the scene.
* Visual polish must not cause major frame drops.
* Final effects must be tested with the Unity Profiler.
* Performance must be checked in the Windows build.

## Portfolio Polish Requirements

Before release, the game must have at least:

* One polished starting view
* One polished gathering interaction
* One polished crafting interaction
* One polished placement interaction
* One visible jungle unlock moment
* One polished final victory moment
* Consistent UI
* Stable lighting
* Balanced audio

These moments should be suitable for:

* Screenshots
* GIF recordings
* Gameplay trailer
* GitHub README
* itch.io page

## Deferred Audio and Visual Features

The following features are outside the MVP scope:

* Large original soundtrack
* Full voice acting
* Character dialogue
* Advanced facial animation
* Motion-captured animations
* Large cinematic cutscenes
* Complex destruction physics
* Advanced weather effects
* Volumetric storms
* Multiple footstep types for every surface
* Full dynamic audio occlusion
* Advanced underwater post-processing
* Large VFX library
* Cinematic rescue vehicle sequence
## Technical Scope

Version `1.0` must demonstrate clean Unity and C# development practices suitable for a Junior Unity Developer portfolio.

The technical goal is not to create an enterprise-scale framework.

The goal is to keep the project:

* Understandable
* Stable
* Testable
* Extendable
* Easy to explain during an interview

## Unity Version

The project uses:

* Unity `6000.3.4f1`
* High Definition Render Pipeline
* C#
* UI Toolkit
* ScriptableObject-based game data

The Unity version must be clearly listed in:

* GitHub README
* itch.io page
* Release notes

The project should not be upgraded to another Unity version during the final month unless a critical issue requires it.

## Render Pipeline

The final project should use one primary render pipeline.

Current target:

* HDRP

Before release:

* Confirm that all gameplay scenes use HDRP materials.
* Remove or disable unnecessary render-pipeline dependencies when safe.
* Check that no required asset becomes pink or broken.
* Test lighting and post-processing in the Windows build.
* Do not change render pipelines during polishing.

## Project Folder Structure

The project’s own files should be organized under:

```text
Assets/_Project
```

Recommended structure:

```text
Assets
├── _Project
│   ├── Art
│   │   ├── Models
│   │   ├── Textures
│   │   ├── Animations
│   │   └── VFX
│   ├── Audio
│   │   ├── Music
│   │   ├── Ambience
│   │   ├── Gameplay
│   │   └── UI
│   ├── Materials
│   ├── Prefabs
│   │   ├── Player
│   │   ├── Items
│   │   ├── Resources
│   │   ├── Interactables
│   │   ├── Buildings
│   │   └── Environment
│   ├── Scenes
│   ├── ScriptableObjects
│   │   ├── Items
│   │   ├── Recipes
│   │   └── Objectives
│   ├── Scripts
│   │   ├── Core
│   │   ├── Player
│   │   ├── Survival
│   │   ├── Inventory
│   │   ├── Items
│   │   ├── Interaction
│   │   ├── Crafting
│   │   ├── Building
│   │   ├── Objectives
│   │   ├── World
│   │   └── UI
│   └── UI
│       ├── UXML
│       ├── USS
│       └── Icons
└── ThirdParty
```

Moving third-party assets is optional if relocation may break package references.

All new project-owned files must be placed inside `_Project`.

## Scene Scope

Required scenes:

* Main Menu
* Main Gameplay Scene

Optional scenes:

* Loading Scene
* Credits Scene

Version `1.0` does not require:

* Multiple gameplay levels
* Separate tutorial scene
* Separate biome scenes
* Persistent additive world loading
* Complex scene streaming

## Scene Naming

Recommended names:

```text
MainMenu
SurvivalIsland
```

Avoid final scene names such as:

```text
New Scene
Test
Scene1
Copy
FinalFinal
```

## Prefab Rules

Reusable world and gameplay objects should use prefabs.

Required prefab categories:

* Player
* Pickup items
* Gatherable resources
* Chest
* Workbench
* Blocked jungle entrance
* Final rescue device
* UI documents when appropriate

Prefab variants may be used for similar resources.

### Prefab validation

Every required prefab should have:

* Correct layer
* Correct tag when needed
* Required colliders
* Correct trigger settings
* Assigned ScriptableObject data
* Assigned visual model
* Assigned audio references when required
* No missing scripts
* No broken prefab overrides

## ScriptableObject Data

ScriptableObjects should store reusable gameplay data.

Required data types:

* ItemData
* RecipeData
* ItemEffect
* ObjectiveData, if the objective system uses data assets

ScriptableObjects should contain data, not scene-specific runtime state.

### ItemData responsibilities

ItemData may contain:

* Item name
* Description
* Icon
* Item category
* Item effects
* Placement prefab
* Optional interaction information

### RecipeData responsibilities

RecipeData contains:

* Input items and quantities
* Output item and quantity
* Required crafting station

### Runtime state

Runtime values such as:

* Current health
* Current inventory quantity
* Current objective index
* Current placement state

must not be stored permanently in shared ScriptableObject assets unless the data is explicitly copied or reset.

## Code Architecture

The project should keep gameplay responsibilities separated.

Recommended main areas:

### PlayerRoot

Acts as a central access point for player systems.

It may provide access to:

* Movement
* Survival
* Inventory
* Water state
* Interaction
* Input

PlayerRoot should not contain the complete implementation of every system.

### Movement State Machine

Movement states should remain separated into:

* Grounded
* Airborne
* Swimming

Each state should be responsible for its own movement rules.

State transitions must not be duplicated across unrelated scripts.

### Survival System

The survival system manages:

* Health
* Stamina
* Hunger
* Temperature, if enabled
* Death

UI should subscribe to survival changes rather than controlling survival values directly.

### Inventory

The inventory stores item quantities and exposes operations such as:

```csharp
AddItem(ItemData item, int count)
RemoveItem(ItemData item, int count)
HasItem(ItemData item, int count)
GetItemCount(ItemData item)
UseItem(ItemData item)
```

The inventory UI must not directly modify the internal item collection.

### Interaction

The interaction system should separate:

* Target detection
* Interaction input
* Interaction behavior
* UI feedback

World objects should expose clear interaction behavior instead of requiring the player controller to know every object type.

### Crafting

Crafting logic should remain separated from crafting UI.

`CraftingService` is responsible for:

* Recipe validation
* Ingredient checking
* Ingredient removal
* Output addition

`CraftingPanelController` is responsible for:

* Displaying recipes
* Selecting recipes
* Showing availability
* Handling button input
* Refreshing UI

### Building Placement

Placement should separate:

* Placement input
* Ghost visualization
* Surface detection
* Overlap validation
* Final object creation
* Inventory consumption

The placement ghost must not act as a real gameplay object.

### Objectives

The objective system should use events from gameplay systems.

Examples:

* Item collected
* Item crafted
* Building placed
* Area opened
* Area entered
* Final device activated

Objective progress should not depend on expensive continuous scene searches.

## Event-Driven Architecture

Events should be used for state changes that multiple systems need to observe.

Recommended events:

* Inventory changed
* Health changed
* Hunger changed
* Stamina changed
* Damage received
* Player died
* Item crafted
* Object placed
* Objective completed
* Victory triggered

### Event rules

* Subscribe in `OnEnable` or during controlled initialization.
* Unsubscribe in `OnDisable` or `OnDestroy`.
* Avoid anonymous subscriptions that cannot be removed.
* Do not invoke gameplay events repeatedly every frame.
* Prevent duplicate event subscriptions.
* Event listeners should handle missing or disabled UI safely.

## Input Architecture

Input should be accessed through one consistent system.

Recommended approach:

* Input service
* Central player input controller
* Clearly separated gameplay and UI modes

Gameplay scripts should avoid reading the same input independently in many unrelated places.

### Input modes

The game should support:

* Gameplay
* Inventory
* Crafting
* Placement
* Paused
* Dead
* Victory

Only inputs allowed by the active mode should be processed.

## UI Architecture

UI Toolkit controllers should be responsible for:

* Querying visual elements
* Registering callbacks
* Displaying current data
* Sending user actions to gameplay services

UI controllers should not contain major gameplay calculations.

### UI callback rules

* Register callbacks once.
* Remove callbacks when the controller is disabled.
* Avoid registering the same button callback repeatedly.
* Validate queried UI elements before use.
* Missing optional UI elements must not crash gameplay.
* UI updates should respond to events where possible.

## Namespace Rules

All project scripts should use consistent namespaces.

Recommended root namespace:

```csharp
_Project.Scripts
```

Examples:

```csharp
_Project.Scripts.Gameplay.Player
_Project.Scripts.Gameplay.Survival
_Project.Scripts.Gameplay.Inventory
_Project.Scripts.Gameplay.Crafting
_Project.Scripts.Gameplay.Interaction
_Project.Scripts.Gameplay.Building
_Project.Scripts.Gameplay.Objectives
_Project.Scripts.UI
```

Scripts should not remain in the global namespace unless there is a clear reason.

## Naming Rules

### Classes

Use PascalCase:

```text
PlayerInventory
CraftingService
ObjectiveController
```

### Methods

Use PascalCase:

```text
AddItem
TryCraft
EnterWater
```

### Private fields

Use underscore camelCase:

```text
_playerRoot
_currentStation
_selectedRecipe
```

### Local variables

Use camelCase:

```text
itemCount
targetPosition
selectedRecipe
```

### Boolean values

Use clear state names:

```text
isDead
isSwimming
canCraft
hasEnoughResources
```

Avoid unclear names such as:

```text
flag
value2
temp
thing
```

unless the value is genuinely temporary and obvious.

## Serialized Field Rules

Inspector references should usually use:

```csharp
[SerializeField] private
```

instead of public fields.

Public fields should be used only when they are part of a deliberate API.

Required Inspector references should be validated.

## Validation Rules

Use validation to detect configuration errors early.

Possible validation locations:

* `Awake`
* `OnValidate`
* Custom validation methods
* EditMode tests

Validation should check:

* Missing ItemData
* Missing icons
* Invalid quantities
* Missing prefabs
* Missing colliders
* Missing UI documents
* Missing Volume overrides
* Invalid recipe outputs
* Missing required station data

Validation messages should clearly identify the affected object.

## Null Safety

Runtime systems must handle missing references safely.

Priority areas:

* PlayerRoot references
* Inventory references
* UIDocument references
* Camera references
* ItemData
* RecipeData
* Placement prefabs
* Collider references
* AudioClip references
* Objective data

A missing optional effect may be skipped.

A missing critical dependency should produce one clear error rather than repeated errors every frame.

## Update Method Rules

`Update()` should be used only for logic that genuinely needs frame-by-frame execution.

Appropriate examples:

* Player input
* Camera movement
* Placement preview
* Time progression
* Movement states

Avoid in `Update()`:

* Rebuilding UI lists
* Searching the complete scene
* Creating materials
* Allocating new collections repeatedly
* Checking static recipe data
* Repeatedly subscribing to events

## Physics Rules

Physics queries should use configured LayerMasks.

Required considerations:

* Interaction targets
* Placement blocking
* Ground detection
* Water detection
* Resource detection

Physics queries should avoid detecting:

* Player-owned helper objects
* Placement ghost
* UI objects
* Irrelevant environment layers

Debug Gizmos may be used for development but should not affect gameplay.

## Coroutine and Timing Rules

Coroutines may be used for:

* Short UI transitions
* Objective completion delay
* Damage cooldown
* Death sequence
* Victory sequence
* Temporary feedback

Coroutines must stop safely when their owner is disabled or destroyed.

Gameplay timers should use the correct time source.

Pause-sensitive logic may use:

```csharp
Time.deltaTime
```

UI transitions that should continue while paused may use:

```csharp
Time.unscaledDeltaTime
```

## Static and Singleton Rules

Singletons should be used only where appropriate.

Potential valid uses:

* Game flow manager
* Audio manager
* Scene transition manager

Singletons must:

* Prevent duplicates
* Clear static references when destroyed
* Handle scene reload correctly
* Avoid preserving unwanted runtime state

Not every gameplay service should become a singleton.

## Error and Logging Rules

Before release:

* Remove temporary `Debug.Log` calls.
* Remove repeated logs from `Update`.
* Remove obsolete test classes.
* Remove large commented code blocks.
* Remove unused variables.
* Fix compiler warnings.
* Keep only useful error messages.

Development logs may use clear prefixes:

```text
[Inventory]
[Crafting]
[Placement]
[Objectives]
```

## Test Scope

Testing must include:

* Play Mode testing
* Windows build testing
* Edge-case testing
* Basic performance testing
* Optional EditMode tests for pure logic

## EditMode Tests

Recommended tests:

### Inventory

* Add a new item.
* Add to an existing stack.
* Remove part of a stack.
* Remove the complete stack.
* Prevent negative quantity.
* Reject null item data.

### CraftingService

* Craft with sufficient resources.
* Reject crafting without resources.
* Handle exact resource quantities.
* Handle duplicate ingredients.
* Add multiple output items.
* Reject invalid recipes.

### Survival Values

* Clamp increase to maximum.
* Clamp decrease to zero.
* Trigger death only once.
* Restore configured values correctly.

EditMode tests are recommended but must not delay the playable build.

## Play Mode Test Checklist

Every major test session should include:

* Start the game.
* Move and sprint.
* Jump.
* Enter and leave water.
* Pick up items.
* Open inventory.
* Use a consumable.
* Gather a resource.
* Open a chest.
* Craft by hand.
* Place a Workbench.
* Craft at the Workbench.
* Open the jungle entrance.
* Obtain the final component.
* Craft the Emergency Radio.
* Trigger victory.
* Restart after victory.
* Die.
* Restart after death.
* Pause and resume.

## Edge-Case Testing

Required edge cases:

* Spam interaction input.
* Walk away during a hold interaction.
* Open UI while moving.
* Press Escape repeatedly.
* Cancel placement.
* Attempt invalid placement.
* Attempt crafting without resources.
* Craft with exact resources.
* Use the last consumable item.
* Enter water while jumping.
* Leave water near a steep shore.
* Die with a UI panel open.
* Restart while `Time.timeScale` is zero.
* Trigger an objective event more than once.
* Attempt victory twice.

## Performance Scope

Version `1.0` should maintain stable performance on the developer’s target computer.

Performance testing should inspect:

* CPU usage
* GPU usage
* Garbage collection
* Memory growth
* Physics queries
* UI rebuilding
* Particle systems
* Day/night transition
* HDRP lighting
* Placement preview

### Performance rules

* Avoid continuous memory growth.
* Avoid large repeated GC allocations.
* Avoid rebuilding complete UI every frame.
* Avoid excessive overlapping colliders.
* Avoid unnecessary real-time lights.
* Avoid high-cost effects outside visible gameplay areas.
* Use object pooling only where it provides a clear benefit.
* Do not add complex optimization systems before identifying an actual problem.

## Git Workflow

The project should use:

* `main` for stable portfolio-ready code
* `development` for active development

Optional feature branches:

```text
feature/swimming-fix
feature/item-usage
feature/pause-menu
feature/victory-condition
fix/crafting-validation
```

For a solo project, feature branches are recommended for large or risky changes but are not required for every small edit.

## Commit Rules

Commits should be small and understandable.

Recommended format:

```text
type: short description
```

Examples:

```text
feat: add pause menu
fix: prevent duplicate crafting ingredients
refactor: separate placement validation
docs: update MVP scope
style: unify inventory UI
test: add crafting service tests
```

Avoid unclear messages such as:

```text
update
fix
work
changes
final
final2
```

## Git Commit Types

Recommended types:

* `feat`
* `fix`
* `refactor`
* `docs`
* `style`
* `test`
* `chore`
* `audio`
* `level`
* `balance`
* `release`

## Repository Cleanup

Before release:

* Remove tracked `.idea` files.
* Confirm `Library` is ignored.
* Confirm `Temp` is ignored.
* Confirm `Logs` is ignored.
* Confirm `Obj` is ignored.
* Confirm build folders are ignored unless intentionally released.
* Remove recovery scenes.
* Remove test scenes.
* Remove unused scripts.
* Remove missing script references.
* Remove unused ScriptableObjects from final UI.
* Check third-party asset licenses.

## Required Documentation Files

The final repository should contain:

```text
README.md
PROJECT_AUDIT.md
MVP_SCOPE.md
DEVLOG.md
LICENSE or license information
```

Optional documentation:

```text
BUGS.md
TEST_REPORT.md
CHANGELOG.md
```

## README Scope

The final README should include:

* Project title
* Short game description
* Gameplay GIF or video
* Screenshots
* Key features
* Technical highlights
* Architecture overview
* Controls
* Unity version
* Installation instructions
* Build link
* Third-party asset credits
* Development status

## DEVLOG Scope

`DEVLOG.md` should contain short development entries.

Recommended format:

```text
Date
Completed
Problems
Decisions
Next step
```

The devlog should focus on meaningful progress, not every minor Inspector change.

## Windows Build Scope

Target platform:

* Windows 64-bit

Recommended build folder:

```text
Builds/Windows/SurvivalIsland_v1.0.0
```

Required build contents:

* Executable
* Data folder
* Unity runtime files
* Optional README with controls

## Build Profile Requirements

Before building:

* Main Menu is the first scene.
* Gameplay scene is included.
* Correct architecture is selected.
* Development Build is disabled for release.
* Script Debugging is disabled for release.
* Product name is correct.
* Company name is configured.
* Version number is configured.
* Game icon is assigned if available.
* Default resolution is appropriate.
* Fullscreen behavior is tested.

## Build Validation

The final build must be tested outside Unity Editor.

Required checks:

* Application starts.
* Main Menu appears.
* Start Game works.
* Mouse and keyboard input work.
* Cursor locking works.
* UI Toolkit panels display correctly.
* Audio plays.
* Materials are not pink.
* Lighting works.
* Crafting works.
* Placement works.
* Death works.
* Pause works.
* Victory works.
* Restart works.
* Main Menu return works.
* Quit works.

## Repeated Build Testing

The final Windows build must be completed at least three times.

Recommended test runs:

### Run 1 — Normal progression

Complete the intended route without intentionally breaking systems.

### Run 2 — Edge cases

Attempt invalid actions, cancel interactions and open UI at unusual moments.

### Run 3 — Restart flow

Test death, restart, victory, restart and return to Main Menu.

## Release Versioning

Initial release:

```text
v1.0.0
```

Possible future versions:

```text
v1.0.1 — Bug fixes
v1.1.0 — Additional polish or optional feature
v2.0.0 — Major gameplay expansion
```

Version `1.0.0` should contain the complete MVP loop.

## Release Definition

The technical build is ready for release when:

* There are no compiler errors.
* There are no blocking runtime exceptions.
* Priority 1 systems work.
* The complete objective sequence works.
* The game can be finished in the Windows build.
* Restart works after death and victory.
* No duplicate managers appear.
* Input modes do not conflict.
* The repository is clean.
* The README is complete.
* The build is publicly downloadable.
* The gameplay video is available.
## Out of Scope

The following features are intentionally excluded from MVP version `1.0`.

They may be considered only after the first complete portfolio release.

### World

* Multiple large islands
* Procedural world generation
* Large open world
* Large underground cave network
* Underwater exploration zone
* Multiple separate levels
* Dynamic world streaming
* Random resource generation
* Large ancient city
* Large player-built settlement

### Combat

* Enemy AI
* Hostile animals
* Melee combat
* Ranged combat
* Firearms
* Boss fights
* Enemy spawning system
* Enemy loot
* Armor
* Weapon upgrades

### Advanced Survival

* Thirst, unless already stable
* Oxygen
* Sleep
* Fatigue
* Diseases
* Poison
* Bleeding
* Injuries
* Body-part damage
* Food expiration
* Complex cooking
* Clothing insulation
* Shelter temperature
* Wetness
* Advanced medicine
* Permanent status effects

### Building

* Full base-building system
* Walls
* Floors
* Roofs
* Doors
* Storage construction
* Building destruction
* Building repair
* Structure stability
* Electricity
* Water collection
* Farming
* Multiple crafting stations
* Workbench upgrades

### Progression

* Skill tree
* Character levels
* Experience points
* Equipment progression
* Multiple tool tiers
* Item rarity
* Random item quality
* Large recipe collection
* Recipe discovery
* Branching objectives
* Side quests
* Multiple endings

### Narrative

* Dialogue system
* NPC characters
* Voice acting
* Cutscene system
* Branching story
* Large text logs
* Complex collectible lore
* Cinematic rescue sequence

### Technical Features

* Multiplayer
* Networking
* Cloud saves
* Multiple save slots
* Full world persistence
* Mod support
* Steam integration
* Achievements
* Controller support
* Key rebinding
* Localization
* Console platforms

### Weather

Dynamic weather is optional and excluded from MVP unless all required systems are completed early.

Deferred weather features:

* Rain
* Storms
* Lightning
* Wind simulation
* Wet surfaces
* Weather-driven temperature
* Weather forecasting
* Dynamic cloud systems

## Scope Protection Rules

The following rules protect the project from uncontrolled expansion:

1. No new major system may be added before the victory condition works.
2. No optional system may delay a Priority 1 task.
3. Every new item must support the main progression.
4. Every new recipe must have a clear gameplay purpose.
5. Every new location must support an existing objective.
6. Visual polish must not replace missing gameplay functionality.
7. A working simple solution is preferred over an unfinished complex solution.
8. Features removed from MVP should be recorded in a future-development list.
9. Version `1.0` must be released before work begins on a large expansion.
10. A feature is not considered complete until it works in the Windows build.

## Project Risks

## Risk 1 — Scope Expansion

### Description

The project may become too large because survival games naturally encourage adding more systems, resources, locations and crafting recipes.

### Possible consequences

* The game remains unfinished.
* Existing systems receive insufficient testing.
* The victory condition is delayed.
* The portfolio release is postponed.
* Development motivation decreases.

### Prevention

* Follow the MVP Scope document.
* Keep one main island.
* Keep one final objective.
* Keep one required crafting station.
* Keep approximately 10–14 item types.
* Keep approximately 6–8 required recipes.
* Record optional ideas instead of implementing them immediately.

### Response

When a new idea appears, ask:

1. Is this required for the player to complete the game?
2. Does this improve the portfolio more than fixing an unfinished system?
3. Can the game be released without it?

If the game can be released without the feature, defer it.

---

## Risk 2 — Too Many Partially Completed Systems

### Description

The project already contains many systems, but several are only partially integrated.

### Possible consequences

* Individual mechanics work separately but fail during a full playthrough.
* UI and gameplay states conflict.
* Restart produces unexpected errors.
* The game appears larger but less complete.

### Prevention

* Finish one system before expanding another.
* Define completion criteria.
* Test every system after restart.
* Test complete system combinations.
* Mark systems as `Working` only after Play Mode and build testing.

### Response

Development order should prioritize:

1. Broken systems
2. Missing required systems
3. Integration
4. Complete gameplay loop
5. Feedback
6. Visual polish
7. Optional features

---

## Risk 3 — Swimming Instability

### Description

Swimming is currently not working correctly because the player falls underwater instead of remaining near the surface.

### Possible consequences

* Water becomes a gameplay trap.
* The player can leave the intended level.
* Movement states become stuck.
* The island boundary becomes unreliable.

### Prevention

* Fix swimming before final level design.
* Test all state transitions.
* Test different shore heights.
* Test repeated water entry and exit.
* Add safe recovery when the player falls too deep.

### Response

If stable swimming cannot be completed quickly:

* Restrict deep-water access.
* Use shallow water near playable areas.
* Add a safe teleport or respawn volume.
* Keep swimming visually present but mechanically simple.

Swimming should not delay the entire release indefinitely.

---

## Risk 4 — Input Conflicts

### Description

Inventory, crafting, placement, pause, death and victory may all attempt to control movement, camera input and cursor state.

### Possible consequences

* The player moves while using UI.
* The camera rotates while clicking buttons.
* The cursor remains unlocked after closing a panel.
* Multiple menus open simultaneously.
* Placement continues after death.

### Prevention

* Use clear input modes.
* Centralize cursor control.
* Allow only one major UI state at a time.
* Close or block conflicting panels.
* Restore gameplay input through one consistent method.

### Response

Before release, test every transition:

```text
Gameplay → Inventory → Gameplay
Gameplay → Crafting → Gameplay
Gameplay → Placement → Cancel
Gameplay → Pause → Resume
Inventory → Escape → Gameplay
Crafting → Escape → Gameplay
Gameplay → Death
Gameplay → Victory
Death → Restart
Victory → Restart
```

---

## Risk 5 — Restart State Problems

### Description

Scene reload may preserve static values, singleton references, time scale or event subscriptions.

### Possible consequences

* Duplicate managers appear.
* The player remains dead after restart.
* `Time.timeScale` remains zero.
* Objectives remain completed.
* UI remains open.
* Events fire multiple times.

### Prevention

* Reset time scale before scene loading.
* Clear static references correctly.
* Prevent singleton duplicates.
* Unsubscribe events.
* Reset objective and survival state.
* Test repeated restart cycles.

### Response

The restart system must be tested after:

* Death
* Pause
* Victory
* Open inventory
* Open crafting panel
* Active placement mode

---

## Risk 6 — Crafting Progression Block

### Description

Incorrect resource quantities or recipe configuration may prevent the player from completing the game.

### Possible consequences

* Required resources run out.
* A final component cannot be crafted.
* Optional crafting consumes critical materials.
* The player must restart the entire game.

### Prevention

* Provide 10–20% extra basic resources.
* Keep unique components protected.
* Validate recipes.
* Test the complete crafting path.
* Avoid random availability for required resources.
* Avoid optional recipes that consume unique components.

### Response

During testing, record:

* Required quantities
* Available quantities
* Remaining quantities after completion
* Resources players frequently miss
* Resources that require excessive gathering

Reduce recipe costs if progression becomes repetitive.

---

## Risk 7 — Third-Party Asset Dependency

### Description

The project contains external models, materials and environment packages.

### Possible consequences

* Missing assets break the build.
* Licensing information is incomplete.
* Repository size becomes unnecessarily large.
* The project appears visually inconsistent.

### Prevention

* Credit third-party assets.
* Check license conditions.
* Keep personal code and assets organized under `_Project`.
* Avoid claiming external artwork as original work.
* Remove unused packages only after checking references.
* Test all materials after package cleanup.

### Response

The portfolio description must clearly separate:

* Programming contribution
* Game design contribution
* UI contribution
* Third-party visual assets

---

## Risk 8 — Performance Problems in HDRP

### Description

HDRP, large environment assets, transparent effects and real-time lighting may create performance issues.

### Possible consequences

* Low frame rate
* Large build size
* Slow scene loading
* Expensive shadows
* Expensive post-processing
* Poor trailer recording quality

### Prevention

* Profile the final gameplay scene.
* Reduce unnecessary real-time lights.
* Limit particle counts.
* Remove unused high-resolution assets.
* Avoid excessive transparent materials.
* Reduce shadow distance if necessary.
* Use one stable quality level for the portfolio build.

### Response

Optimize only measured problems.

Priority order:

1. Remove obvious unnecessary work.
2. Reduce expensive visual settings.
3. Simplify distant environment.
4. Reduce effect complexity.
5. Consider object pooling only when needed.

---

## Risk 9 — Spending Too Long on Visual Polish

### Description

The environment and UI may receive repeated redesigns while required gameplay remains incomplete.

### Possible consequences

* The game looks better but cannot be completed.
* Important bugs remain.
* Portfolio publication is delayed.

### Prevention

Visual polish begins only after:

* Swimming works.
* Item usage works.
* Workbench progression works.
* Pause works.
* Death and restart work.
* Victory works.
* A full playthrough is possible.

### Response

When deciding between tasks, prefer:

```text
Complete system
over
additional decoration
```

and:

```text
Stable build
over
new visual feature
```

---

## Risk 10 — Insufficient Build Testing

### Description

Systems may work in Unity Editor but fail in the final Windows build.

### Possible consequences

* Missing scene
* Broken cursor
* Missing assets
* Incorrect lighting
* UI scaling problems
* Restart failure
* Quit button failure

### Prevention

* Create builds throughout development.
* Test outside Unity Editor.
* Test after major system changes.
* Test the final release in a copied folder.
* Test the build at the target resolution.

### Response

A task is not fully complete until its main flow works in a Windows build.

## Development Constraints

The project must follow these constraints:

* Target development period: approximately 30 days
* Target daily work: approximately 4–6 hours
* Target playtime: 15–25 minutes
* Target platform: Windows
* Primary input: keyboard and mouse
* Primary role target: Junior Unity Developer
* Primary engine: Unity
* Primary language: C#
* Primary UI technology: UI Toolkit
* Primary render pipeline: HDRP

## Required Version 1.0 Content

Version `1.0` must contain:

* One Main Menu
* One gameplay island
* One player controller
* Grounded movement
* Airborne movement
* Swimming
* Health
* Stamina
* Hunger
* One healing or food item
* Item pickup
* Inventory
* Item usage
* Resource gathering
* One chest type
* Hand crafting
* One Workbench
* Workbench crafting
* Building placement
* One blocked progression route
* One jungle area
* One small cave
* One final shore
* One linear objective sequence
* One final rescue device
* Death
* Game Over
* Restart
* Pause
* Victory
* Win Screen
* Windows build
* GitHub documentation
* Gameplay video
* itch.io page

## Minimum Playable Version

The project reaches the minimum playable state when:

1. The player can start the gameplay scene.
2. Movement, camera, sprint and jump work.
3. The player can collect resources.
4. Inventory stores collected items.
5. The player can use at least one consumable.
6. The player can craft Rope.
7. The player can craft the Stone Tool.
8. The player can gather Wood.
9. The player can craft and place the Workbench.
10. The Workbench opens advanced crafting.
11. The player can open the jungle route.
12. The player can obtain final components.
13. The player can craft the Emergency Radio.
14. The player can activate the rescue signal.
15. The Win Screen appears.
16. The player can restart or return to the Main Menu.

At this stage, visual effects and audio may still be incomplete.

## Portfolio-Ready Version

The project becomes portfolio-ready when:

* The minimum playable version works.
* The complete game can be finished in 15–25 minutes.
* No critical bugs remain.
* No runtime exceptions occur during a full playthrough.
* Input modes do not conflict.
* Swimming is stable.
* Death and restart work.
* Pause works.
* Victory works.
* All required UI is readable.
* Main interactions have feedback.
* Lighting is stable.
* Audio is balanced.
* Performance is acceptable.
* The Windows build has been completed three times.
* GitHub README is complete.
* Third-party assets are credited.
* A gameplay video is available.
* The build is available for download.

## Definition of Done for Version 1.0

Version `1.0` is considered complete only when all of the following are true.

### Gameplay

* [ ] The player can complete the full progression.
* [ ] All required resources are obtainable.
* [ ] All required recipes work.
* [ ] The Workbench can be placed and used.
* [ ] The jungle route can be opened.
* [ ] The final component can be obtained.
* [ ] The Emergency Radio can be created.
* [ ] The rescue signal can be activated.
* [ ] Victory cannot trigger more than once.

### Survival

* [ ] Health works.
* [ ] Health recovery works.
* [ ] Hunger works.
* [ ] Hunger recovery works.
* [ ] Stamina works.
* [ ] Damage works.
* [ ] Death works.
* [ ] Restart restores the expected state.
* [ ] Temperature is either complete or disabled.

### Movement

* [ ] Walking works.
* [ ] Sprinting works.
* [ ] Jumping works.
* [ ] Falling works.
* [ ] Swimming works.
* [ ] Water transitions work.
* [ ] The player cannot permanently leave the playable area.

### Interaction

* [ ] Pickup works.
* [ ] Gathering works.
* [ ] Chest interaction works.
* [ ] Workbench interaction works.
* [ ] Progression interaction works.
* [ ] Final interaction works.
* [ ] Prompts update correctly.
* [ ] Interaction is blocked in UI states.

### UI

* [ ] HUD works.
* [ ] Inventory works.
* [ ] Crafting UI works.
* [ ] Objective UI works.
* [ ] Placement UI works.
* [ ] Pause Menu works.
* [ ] Game Over works.
* [ ] Win Screen works.
* [ ] Cursor states work.
* [ ] UI scales correctly.

### Stability

* [ ] There are no compiler errors.
* [ ] There are no blocking runtime exceptions.
* [ ] There are no repeated critical warnings.
* [ ] Restart does not create duplicate managers.
* [ ] `Time.timeScale` resets correctly.
* [ ] Event subscriptions do not duplicate.
* [ ] The full game has been completed at least three times.

### Portfolio

* [ ] The repository is organized.
* [ ] README is complete.
* [ ] Screenshots are included.
* [ ] Gameplay video is included.
* [ ] Controls are documented.
* [ ] Architecture is documented.
* [ ] Third-party assets are credited.
* [ ] A Windows build is available.
* [ ] An itch.io page is published.
* [ ] The project is included in the CV.

## Release Approval

The project may be released as version `1.0.0` when:

1. The complete game can be finished without developer tools.
2. All Priority 1 systems are working.
3. The victory condition is stable.
4. No critical bugs remain.
5. The Windows build has passed three complete test runs.
6. The repository is ready for public review.
7. The gameplay video accurately represents the final build.

Optional features do not block release.

## Future Development List

After version `1.0`, possible development directions may include:

* Dynamic weather
* Additional food
* More healing items
* Tool durability
* Save system
* Additional crafting station
* Expanded cave
* Additional island
* Simple enemy
* Combat prototype
* Advanced temperature
* Additional objectives

Future development begins only after the portfolio version is publicly available.
