using UnityEngine;
using UnityEngine.UI;

public abstract class ClassBase : CharacterBase
{
    #region =====　enum ClassType　=====
    public enum eClassType
    {
        None = -1 ,
        Shilder ,
        Archer  ,
        Bishop
    };

    [ SerializeField ]
    protected eClassType _classType = eClassType.None;
    public    eClassType getClassType
    {
        get { return _classType; }
    }
    #endregion


    #region =====　enum ChrState　=====
    public enum eChrState
    {
        None = -1 ,
        Idle   , Move     , Run ,
        Attack , Attacked ,
        Dead
    };

    [ SerializeField ]
    protected eChrState _chrState = eChrState.None;
    public    eChrState getChrState
    {
        get { return _chrState; }
    }
    #endregion


    protected virtual void Awake()
    {
        SettingButtons();
    }

    // 적이 나에게 데미지를 보냄
    public    abstract void RecvDamage(int damage);


    protected void SettingButtons()
    {
        Transform   tfJoystick = GameObject.Find( "btnAttackGroup" ).transform;
        Button[]    btns       = tfJoystick.GetComponentsInChildren< Button >();
        
        SkillBase[] skill_list = this.GetComponentsInChildren< SkillBase >();

        foreach(Button btn in btns)
        {
            string btnName = btn.name;
                   btnName = btnName.Substring( btnName.Length - 1 , 1 );

            int btnIdx = -1;

            if( ! int.TryParse( btnName , out btnIdx ) )
            {
                // 기본공격 셋팅
                btn.onClick.AddListener
                (
                    () => { BasicAttack(); }
                );
                continue;
            }

            // 스킬 셋팅
            SkillBase skill = skill_list[ btnIdx ];

            string path = skill.getIcon;

            btn.GetComponent<Image>().sprite = Resources.Load< Sprite >( path );
            btn.onClick.AddListener
            (
                () => { StartCoroutine( skill.Use() ); }
            );
        }
    }

    protected abstract void BasicAttack();
}