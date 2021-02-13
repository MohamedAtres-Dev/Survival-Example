using UnityEngine;

public class Projectile : ShotBehaviour
{

    public override void Move(Transform trans)
    {
        rb2D.AddForce(trans.up * shotSpeed , ForceMode2D.Impulse);
    }

}
