# BetterInfinityRage

BetterInfinityRage is a plugin for **SCP: Secret Laboratory** designed to enhance the behavior of SCP-096. It improves the gameplay by enabling SCP-096 to dynamically track and interact with players that are targeted by its rage mechanic, providing hints based on the player's location.

## Features

- **Target Tracking:** Tracks players targeted by SCP-096, ensuring it always has a target to focus on during its rage.
- **Hint System:** Displays location-based hints to SCP-096 about the closest targeted player, enhancing gameplay immersion.
- **Efficient Coroutine Handling:** The plugin utilizes coroutines to periodically check the positions of targets, optimizing performance and reducing unnecessary checks.
- **Target Removal on Death:** When a tracked target dies, the plugin removes them from the tracking list and stops tracking when there are no more active targets.
- - **Config & Translation Support:** The plugin includes a `config` for configuring settings and a `translation` for customizing the messages shown in-game, allowing easy localization and setup.

## Configuration

- **Position Check Interval:** Set the frequency (in seconds) at which the plugin checks the positions of tracked players.
- **Always Show Player:** Option to always display the targeted player's location to SCP-096, regardless of zone.

## How It Works

- **Rage Persistence:** SCP-096 cannot exit its rage if more than one target is still alive. This ensures that SCP-096 continues its pursuit of all remaining targets until they are all eliminated.
- **Tracking Targets:** When SCP-096 targets a player, that player is added to the tracking list. The plugin continuously tracks the position of the closest target.
- **Hint System:** Based on the position of the closest target, SCP-096 receives a hint about the room the target is in, which it can use to better locate the player.
- **Target Removal:** If a tracked player dies, they are removed from the list, and the plugin stops tracking if there are no active targets left.

~~Readme is made by chatgpt cuz i'm lazy lol~~

