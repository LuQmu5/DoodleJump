using System;

public class CharacterProgressHandler
{
    public float MaxHeight { get; private set; } = 0;

    public event Action<float> MaxHeightChanged;

    public void SetMaxHeight(float value)
    {
        if (value <= MaxHeight)
            throw new ArgumentException($"{nameof(value)} can't be less than {nameof(MaxHeight)}");

        MaxHeight = value;

        MaxHeightChanged?.Invoke(MaxHeight);
    }
}
