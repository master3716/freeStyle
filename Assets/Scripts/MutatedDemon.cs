public class MutatedDemon
{
    private int health;
    private float speed;
    private int damage;

    public MutatedDemon()
    {
        
    }
    public MutatedDemon(int health, float speed, int damage)
    {
        this.health = health;
        this.speed = speed;
        this.damage = damage;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetDamage()
    {
        return damage;
    }
    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}