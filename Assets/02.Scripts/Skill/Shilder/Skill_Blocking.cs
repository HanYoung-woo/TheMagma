using System.Collections;
using UnityEngine;

public class Skill_Blocking : SkillBase
{
    void Awake()
    {
        this._name     = "막기";
        this._icon     = "Shild/";
        this._cooltime = 6.0f;
    }

    public override IEnumerator Use()
    {
        yield return null;

        Debug.Log( "막기" );
    }
}