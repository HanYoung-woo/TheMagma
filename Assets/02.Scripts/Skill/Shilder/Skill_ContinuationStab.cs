using System.Collections;
using UnityEngine;

public class Skill_ContinuationStab : SkillBase
{
    void Awake()
    {
        this._name     = "연속 찌르기";
        this._icon     = "Shild/";
        this._cooltime = 8.0f;
    }

    public override IEnumerator Use()
    {
        yield return null;

        Debug.Log( "연속 찌르기" );
    }
}