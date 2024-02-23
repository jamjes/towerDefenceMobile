public interface IDamageable
{
    void Inflict(float amount);
    void Heal();
    void Kill();
}

public interface ISpawnable
{
    void OnInstantiate(float duration);
}
