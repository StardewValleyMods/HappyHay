namespace HappyHay;

public sealed class ModConfig
{
    private int _doubleFriendshipChancePercent;
    public int DoubleFriendshipChancePercent
    {
        get => _doubleFriendshipChancePercent;
        set => _doubleFriendshipChancePercent = Math.Clamp(value, 0, 100);
    }
}