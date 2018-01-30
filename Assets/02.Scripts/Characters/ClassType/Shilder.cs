using UnityEngine;

public class Shilder : ClassBase
{
    protected override void Awake()
    {
        base.Awake();

        this._classType = eClassType.Shilder;
        this._chrState  = eChrState.Idle;
    }

    public override void RecvDamage(int damage)
    {
        
    }

    protected override void BasicAttack()
    {
    }
}