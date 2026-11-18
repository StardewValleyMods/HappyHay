using HappyHay.Integrations;
using HappyHay.Patches;
using HarmonyLib;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace HappyHay;

public class ModEntry : Mod
{
    private ModConfig _config = null!;

    public override void Entry(IModHelper helper)
    {
        I18n.Init(helper.Translation);
        _config = helper.ReadConfig<ModConfig>();

        Harmony harmony = new(ModManifest.UniqueID);
        FarmAnimalDayUpdatePatches.Apply(harmony, _config);

        helper.Events.GameLoop.GameLaunched += OnGameLaunched;
    }

    private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
    {
        GmcmIntegration.Register(Helper, ModManifest, _config);
    }
}