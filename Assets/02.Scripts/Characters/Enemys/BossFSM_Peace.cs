using System.Collections;
using UnityEngine;

public partial class BossFSM
{
    IEnumerator Idle()
    {
        _isNewState = false;

        do
        {
            yield return null;
        } while ( ! _isNewState );
    }

    IEnumerator Move()
    {
        _isNewState = false;

        do
        {
            yield return null;
        } while ( _isNewState );
    }
}