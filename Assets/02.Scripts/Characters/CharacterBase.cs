using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    protected struct Stat
    {
        public string _name;
        public int    _curHP , _maxHP;
        public int    _curMP , _maxMP;
        public int    _damage;
        public float  _moveSpeed;
    };

    protected Stat _stat;

    public void SetHP(int value)
    {
        _stat._curHP += value;
        _stat._curHP = Mathf.Clamp( _stat._curHP , 0 , _stat._maxHP );
    }

    public void SetMP(int value)
    {
        _stat._curMP += value;
        _stat._curMP = Mathf.Clamp( _stat._curMP , 0 , _stat._maxMP );
    }
}