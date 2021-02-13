using UnityEngine;

public class Bullet : ShotBehaviour
{
    #region Methods

    public override void Move(Transform trans)
    {
        rb2D.AddForce(trans.up * shotSpeed, ForceMode2D.Impulse);
    }
    #endregion
}
