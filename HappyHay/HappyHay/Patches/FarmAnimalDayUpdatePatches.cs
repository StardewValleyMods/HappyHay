using HarmonyLib;
using StardewValley;

namespace HappyHay.Patches;

public class FarmAnimalDayUpdatePatches
{
    private const string HayId = "(O)178";
    private const int HungerThreshold = 200;
    private const int MaxFriendship = 1000;
    private const int BonusFriendship = 8;

    private static ModConfig? _config;

    public static void Apply(Harmony harmony, ModConfig config)
    {
        harmony.Patch(
            AccessTools.Method(typeof(FarmAnimal), nameof(FarmAnimal.dayUpdate)),
            prefix: new HarmonyMethod(typeof(FarmAnimalDayUpdatePatches), nameof(GiveHayMeal))
        );

        _config = config;
    }

    private static void GiveHayMeal(FarmAnimal __instance, GameLocation environment)
    {
        if (environment is not AnimalHouse || environment.IsRainingHere() || environment.IsWinterHere())
        {
            return;
        }

        if (__instance.fullness.Value >= HungerThreshold || !TroughHasHay(environment))
        {
            return;
        }

        int fullness = __instance.fullness.Value;
        bool wasEating = __instance.isEating.Value;
        bool wasLooping = __instance.Sprite.loop;
        int friendshipBefore = __instance.friendshipTowardFarmer.Value;

        __instance.Eat(environment);

        if (__instance.friendshipTowardFarmer.Value > friendshipBefore && RollDoubleFriendship(__instance))
        {
            __instance.friendshipTowardFarmer.Value = Math.Min(MaxFriendship, __instance.friendshipTowardFarmer.Value + BonusFriendship);
        }

        __instance.fullness.Value = fullness;
        __instance.isEating.Value = wasEating;
        __instance.Sprite.loop = wasLooping;
    }

    private static bool RollDoubleFriendship(FarmAnimal animal)
    {
        int chancePercent = _config?.DoubleFriendshipChancePercent ?? 0;
        if (chancePercent <= 0)
        {
            return false;
        }

        Random random = Utility.CreateRandom(animal.myID.Value, Game1.stats.DaysPlayed);
        return random.Next(100) < chancePercent;
    }

    private static bool TroughHasHay(GameLocation house)
    {
        return house.objects.Pairs.Any(pair => pair.Value.QualifiedItemId == HayId);
    }
}