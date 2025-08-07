
public class Rage
{
    private int rageSpeed;
    private float rageDuration;
    private float rageDamageMultiplier;

    public Rage(int rageSpeed, float rageDuration, float rageDamageMultiplier)
    {
        this.rageSpeed = rageSpeed;
        this.rageDuration = rageDuration;
        this.rageDamageMultiplier = rageDamageMultiplier;

    }
    public int GetRageSpeed()
    {
        return rageSpeed;
    }
    public float GetRageDuration()
    {
        return rageDuration;
    }
    public float GetRageDamageMultiplier()
    {
        return rageDamageMultiplier;
    }
    public void SetRageSpeed(int speed)
    {
        rageSpeed = speed;
    }
    public void SetRageDuration(float duration)
    {
        rageDuration = duration;
    }
    public void SetRageDamageMultiplier(float multiplier)
    {
        rageDamageMultiplier = multiplier;
    }
}