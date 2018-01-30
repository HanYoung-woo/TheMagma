using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ClassBase : CharacterBase
{
    public enum eClassType
    {
        None = -1 ,
        Shilder ,
        Archer  ,
        Bishop
    };
    protected eClassType _classType = eClassType.None;
    public    eClassType getClassType
    {
        get { return _classType; }
    }

    protected List<SkillBase> _skill_List;

    protected virtual void Awake()
    {
        SettingButtons();
    }

    // 내가 적에게 데미지를 보냄
    protected abstract void SendDamage();
    // 적이 나에게 데미지를 보냄
    public    abstract void RecvDamage(int damage);


    protected void SettingButtons()
    {
        _skill_List = new List<SkillBase>();

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
                btn.onClick.AddListener
                (
                    () => { BasicAttack(); }
                );
                continue;
            }


            SkillBase skill = skill_list[ btnIdx ];

            string path = skill.getIcon;

            btn.GetComponent<Image>().sprite = Resources.Load< Sprite >( path );
            btn.onClick.AddListener
            (
                () => { StartCoroutine( skill.Use() ); }
            );

            _skill_List.Add( skill );
        }
    }

    protected abstract void BasicAttack();
}