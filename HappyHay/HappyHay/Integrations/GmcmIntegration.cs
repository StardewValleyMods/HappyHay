using GenericModConfigMenu;
using StardewModdingAPI;

namespace HappyHay.Integrations;

public static class GmcmIntegration
{
    public static void Register(IModHelper helper, IManifest manifest, ModConfig config)
    {
        var api = helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");

        if (api is null)
        {
            return;
        }

        void Apply(int value)
        {
            config.DoubleFriendshipChancePercent = value;
        }

        api.Register(
            manifest,
            () => Apply(0),
            () => helper.WriteConfig(config)
            );

        api.AddNumberOption(
            manifest,
            () => config.DoubleFriendshipChancePercent,
            Apply,
            I18n.Config_Chance_Name,
            I18n.Config_Chance_Tooltip,
            0,
            100,
            1,
            value => $"{value}%"
            );
    }
}