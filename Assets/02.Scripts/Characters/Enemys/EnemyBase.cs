public abstract class EnemyBase : CharacterBase
{
	// 내가 적에게 데미지를 보냄
    protected abstract void SendDamage();
    // 적이 나에게 데미지를 보냄
    public    abstract void RecvDamage(int damage);
}