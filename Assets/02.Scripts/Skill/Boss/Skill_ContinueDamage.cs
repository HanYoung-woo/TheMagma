using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_ContinueDamage : SkillBase
{
    private List<ClassBase> _playerList;

    [ SerializeField ] private float _range        = 50.0f;
    [ SerializeField ] private float _duration     = 5.5f;
    [ SerializeField ] private float _intervalTime = 0.5f;
    [ SerializeField ] private float _value        = 1.5f;

    [ Header( "-----　Skill Effect　-----" ) ]
    [ SerializeField ] private GameObject _motionEffect;
    [ SerializeField ] private GameObject _hitEffect;

    void Awake()
    {
        // Search Players
        GameObject[] objPlayerList = GameObject.FindGameObjectsWithTag( "Player" );

        _playerList = new List<ClassBase>();

        foreach ( GameObject player in objPlayerList )
            _playerList.Add( player.GetComponent< ClassBase >() );


        // Skill Setting
        this._name     = "";
        this._icon     = "Boss/";
        this._cooltime = 10.0f;
    }

    public override IEnumerator Use()
    {
        yield return null;

        GameObject[] hitPlayer = new GameObject[ _playerList.Count ];

        for ( int idx = 0; idx < _playerList.Count; idx++ )
        {
            if ( _playerList[ idx ] == null )
            {
                _playerList.RemoveAt( idx );
                continue;
            }

            bool isNone = _playerList[ idx ].getChrState == ClassBase.eChrState.None;
            bool isDead = _playerList[ idx ].getChrState == ClassBase.eChrState.Dead;

            if ( isNone || isDead )
                continue;

            hitPlayer[ idx ] = Instantiate( _hitEffect , _playerList[ idx ].transform.position , Quaternion.identity , _playerList[ idx ].transform );
        }


        foreach ( GameObject effect in hitPlayer )
            effect.SetActive( true );
    }
}