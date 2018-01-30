﻿using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    protected string _name;


    #region =====　Property　=====
    protected string _icon;
    public    string getIcon
    {
        get
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append( "Images/Icon/Skill/" );
            sb.Append( _icon  );

            return sb.ToString();
        }
    }

    protected float _cooltime;
    public    float getCooltime
    {
        get { return _cooltime; }
    }

    protected float _value;
    public    float getValue
    {
        get { return _value; }
    }
    #endregion


    public abstract System.Collections.IEnumerator Use();
}