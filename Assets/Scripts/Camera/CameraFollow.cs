using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Fields
    private Transform target = default;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] [Range(0.01f, 1f)] private float smoothSpeed = 0.15f;
    [SerializeField] private Vector3 offset = default;
    #endregion

    #region MonoBehaviour
    void Start()
    {
        //TODO : call this when instansiate the player first by using  events
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothSpeed);

    }
    #endregion
}
