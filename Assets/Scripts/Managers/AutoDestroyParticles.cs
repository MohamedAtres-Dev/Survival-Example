using UnityEngine;

public class AutoDestroyParticles : MonoBehaviour
{
    //I can make a system for particles but i have no time
    private void OnEnable()
    {
        Destroy(gameObject, 2f);
    }


}
