using System.Collections;
using UnityEngine;

public class Skill_Rush : SkillBase
{
    float _value;

    void Awake()
    {
        this._name     = "돌진";
        this._icon     = "Shild/";
        this._cooltime = 12.0f;
    }

    public override IEnumerator Use()
    {
        yield return null;

        Debug.Log( "돌진" );
    }
}