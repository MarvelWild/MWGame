namespace MwGame;


/// <summary>
/// https://www.monogameextended.net/docs/features/entities/
/// learning ecs
/// </summary>
public class Expiry
{
    public Expiry(float timeRemaining)
    {
        TimeRemaining = timeRemaining;
    }

    public float TimeRemaining;
}