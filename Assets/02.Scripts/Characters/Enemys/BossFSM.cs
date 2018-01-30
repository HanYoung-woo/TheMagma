using System.Collections;
using UnityEngine;

public partial class BossFSM : MonoBehaviour
{
    #region =====　State　=====
    public enum eChrState
    {
        None = -1 ,
        Idle   , Move     , Run  ,
        Attack , Attacked , Dead
    }

    protected eChrState _chrState;
    public    eChrState getChrState
    {
        get { return _chrState; }
    }
    #endregion


    private SkillBase[] _skill_List;


    private Animator _anim;
    private bool     _isNewState = false;

    void Awake()
    {
        _skill_List = this.GetComponentsInChildren< SkillBase >();

        StartCoroutine( _skill_List[0].Use() );
        Debug.Log( _skill_List[0].name );
    }

    void OnEnable()
    {
        this._chrState = eChrState.Idle;

        StartCoroutine( StartFSM() );
    }


    #region =====　FSM　=====
    void SetState(eChrState state)
    {
        if ( _chrState == eChrState.Dead )
            return;

        _isNewState = true;
        _chrState   = state;
    }

    IEnumerator StartFSM()
    {
        while ( true )
            yield return StartCoroutine( _chrState.ToString() );
    }
    #endregion


    #region =====　Method　=====
    bool isAnimStata(int layerIndex, string stateName)
    {
        return _anim.GetCurrentAnimatorStateInfo( layerIndex )
                    .IsName( stateName );
    }

    bool isAnimDone(int layerIndex)
    {
        float normalizedTime = _anim.GetCurrentAnimatorStateInfo( layerIndex )
                                    .normalizedTime % 1.0f;

        return ( normalizedTime >= 0.99f );
    }
    #endregion
}