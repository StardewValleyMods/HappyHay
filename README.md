# Happy Hay
Happy Hay is a Stardew Valley mod that makes hay just as good as fresh grass. Animals that eat hay from the trough in their barn or coop get the same mood and friendship as animals that eat grass outside, with an optional chance to receive the blue grass friendship bonus as well.

[Nexus Page](https://www.nexusmods.com/stardewvalley/mods/55701)

## Installation
1. Install the latest version of [SMAPI](https://smapi.io).
2. Download this mod from [Releases](https://github.com/StardewValleyMods/HappyHay/releases).
3. Extract it into your `Stardew Valley/Mods` folder.
4. (Optional) Install [Generic Mod Config Menu](https://www.nexusmods.com/stardewvalley/mods/5098) to change the settings in-game.

## How it works
Vanilla animals that eat hay from the trough get less out of the meal than animals that eat grass outside. Happy Hay lets them eat through the same logic the game uses for grass, so both meals award the same mood and friendship.

With the optional chance enabled, a hay meal can instead award the amount blue grass gives (+16 friendship instead of +8). The result is rolled once per animal per day, seeded from the animal and the date, so reloading a save cannot reroll it, and the total is still capped at 1000 friendship like vanilla.

It only applies where vanilla would grant a hay meal: an animal in a barn or coop, with hay in the trough, on a day when the animal is actually hungry.

## Configuration
The mod adds a **Double friendship chance** slider (0-100%, default `0`). `0` keeps vanilla hay behaviour; `100` makes every hay meal give the blue grass amount.

If you prefer to edit the file directly, it is located at `Mods/HappyHay/config.json`:

## Building from Source
The mod build package should locate your game folder automatically. If you need to specify it manually, edit the `.csproj` file:
```xml
<PropertyGroup>
    ...
    <GamePath>YOUR_GAME_PATH_HERE</GamePath>
    ...
</PropertyGroup>
```
Alternatively, you can set a global path by creating a `stardewvalley.targets` file in your user profile folder (`%userprofile%` on Windows or `~` on Linux/macOS):
```xml
<Project>
   <PropertyGroup>
      <GamePath>YOUR_GAME_PATH_HERE</GamePath>
   </PropertyGroup>
</Project>
```