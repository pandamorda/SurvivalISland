using System;

public static class GameplayState
{
    public static bool IsGameplayEnabled { get; private set; } = true;
    public static event Action<bool> OnGameplayEnabledChanged;

    public static void SetGameplayEnabled(bool value)
    {
        if (IsGameplayEnabled == value)
        {
            return;
        }

        IsGameplayEnabled = value;
        OnGameplayEnabledChanged?.Invoke(value);
    }
}
