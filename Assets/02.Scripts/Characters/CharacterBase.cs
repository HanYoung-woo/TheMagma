using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    [ System.Serializable ]
    protected struct Stat
    {
        public string _name;
        public int    _curHP , maxHP;
        public int    _curMP , maxMP;
        public int    _damage;
        public float  _moveSpeed;
    };

    [ SerializeField ] protected Stat _stat;
    public int getDamage
    {
        get { return _stat._damage; }
    }

    public void SetHP(int value)
    {
        _stat._curHP += value;
        _stat._curHP = Mathf.Clamp( _stat._curHP , 0 , _stat.maxHP );
    }

    public void SetMP(int value)
    {
        _stat._curMP += value;
        _stat._curMP = Mathf.Clamp( _stat._curMP , 0 , _stat.maxMP );
    }
}