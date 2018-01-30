using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_ContinueDamage : SkillBase
{
    private csGameSceneManager _mngGameScene;

    [ SerializeField ] private float _range        = 50.0f;
    [ SerializeField ] private float _duration     = 5.5f;
    [ SerializeField ] private float _intervalTime = 0.5f;
    [ SerializeField ] private float _value        = 1.5f;
    private float _damage = 0.0f;   // Parent Damage

    [ Header( "-----　Skill Effect　-----" ) ]
    [ SerializeField ] private GameObject _motionEffect;
    [ SerializeField ] private GameObject _hitEffect;

    void Awake()
    {
        this._mngGameScene = GameObject.Find         ( "GameSceneManager" )
                                       .GetComponent < csGameSceneManager >();

        // Skill Setting
        this._name     = "";
        this._icon     = "Boss/";
        this._cooltime = 10.0f;

        this._damage   = this.GetComponentInParent< CharacterBase >().getDamage;
    }

    public override IEnumerator Use()
    {
        yield return null;

        List<ClassBase> playerList = new List<ClassBase>();
        _mngGameScene.GetPlayerList( ref playerList );

        GameObject[] effects = new GameObject[ playerList.Count ];

        for ( int idx = 0; idx < playerList.Count; idx++ )
        {
            if ( playerList[ idx ] == null )
            {
                playerList.RemoveAt( idx );
                continue;
            }

            bool isNone = playerList[ idx ].getChrState == ClassBase.eChrState.None;
            bool isDead = playerList[ idx ].getChrState == ClassBase.eChrState.Dead;

            if ( isNone || isDead )
                continue;


            float distance = Vector3.Distance( this.transform.position , playerList[ idx ].transform.position );

            if ( distance <= _range )
            {
                effects[ idx ] = Instantiate
                (
                    _hitEffect ,
                    playerList[ idx ].transform.position ,
                    Quaternion.identity                  ,
                    playerList[ idx ].transform
                );
            }
        }

        float damage = _value * _damage;

        for ( int idx = 0; idx < effects.Length; idx++ )
        {
            if ( effects[ idx ] == null )
                continue;

            effects[ idx ].GetComponent< Skill_ContinueDamageFire >()
                          .Setting( _duration , _intervalTime , - ((int) damage) );

            effects[ idx ].SetActive( true );
        }
    }
}