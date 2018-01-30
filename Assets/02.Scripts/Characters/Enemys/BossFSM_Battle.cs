using System.Collections;

public partial class BossFSM
{
    IEnumerator Attack()
    {
        _isNewState = false;

        do
        {
            yield return null;

            if ( ! isAnimStata( 0 , "Base Layer.Attack" ) )
                SetState( eChrState.Idle );

        } while ( ! _isNewState );
    }

    IEnumerator Dead()
    {
        _isNewState = false;

        do
        {
            yield return null;
        } while ( _isNewState );
    }
}