using System.Collections;
using UnityEngine;

public class Skill_Provocation : SkillBase
{
    void Awake()
    {
        this._name     = "도발";
        this._icon     = "Shild/";
        this._cooltime = 20.0f;
    }

    public override IEnumerator Use()
    {
        yield return null;

        Debug.Log( "도발" );
    }
}