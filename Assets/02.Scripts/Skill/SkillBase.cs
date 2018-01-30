using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    [ SerializeField ]
    protected string _name;


    #region =====　Property　=====
    [ SerializeField ]
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

    [ SerializeField ]
    protected float _cooltime;
    public    float getCooltime
    {
        get { return _cooltime; }
    }
    #endregion


    public abstract System.Collections.IEnumerator Use();
}