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
        SetHP( damage );

        if ( _stat._curHP <= 0 )
        {
            _chrState = eChrState.Dead;
        }
    }

    protected override void BasicAttack()
    {
        Debug.Log( "공격!!!" );
    }
}