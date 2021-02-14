using UnityEngine;
using Pathfinding;
using System;
using MilkShake;

[RequireComponent(typeof(Seeker)) , RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IHealth
{
    #region Fields
    //particles
    [SerializeField] protected ParticleSystem destroyEffect = default;
    protected ParticleSystem.MainModule particleSetting = default;

    [Header("SO")]
    [SerializeField] private ShakePreset shakePreset = default;
    [SerializeField] private AudioManager _audioManger = default;

    public AudioClip clip = default;

    [Space]
    [Header("Variables")]
    protected float currentHealth = 0f;
    [SerializeField] protected float maxHealth = 0f;
    protected Transform target = default;
    [NonSerialized] public Rigidbody2D rb2D = default;
    [NonSerialized] public bool isTargetInRange = false;

    //Use this Velocity Vector to move Enemy
    [NonSerialized] public Vector3 velocity = default;

    //AStar vars
    protected Seeker _seeker = default;
    protected Path _path = default;
    private float nextWaypointDistance = 3;
    private int currentWaypoint = 0;
    private float repeatRate = 0.5f;
    private float lastRepeat = float.NegativeInfinity;
    protected bool reachedEndOfPath = false;

    #endregion

    #region Monobehaviour
    public virtual void Start()
    {
        currentHealth = maxHealth;

        target = GameObject.FindGameObjectWithTag("Player").transform;

        _seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();

        particleSetting = destroyEffect.main;
    }

    public virtual void FixedUpdate()
    {
        if (!isTargetInRange)
            return;

        if (Time.time > lastRepeat + repeatRate && _seeker.IsDone())
        {
            lastRepeat = Time.time;

            // Start a new path to the targetPosition, call the the OnPathComplete function
            // when the path has been calculated (which may take a few frames depending on the complexity)
            _seeker.StartPath(transform.position, target.position, OnPathComplete);
        }

        if (_path == null)
        {
            // We have no path to follow yet, so don't do anything
            return;
        }

        // Check in a loop if we are close enough to the current waypoint to switch to the next one.
        // We do this in a loop because many waypoints might be close to each other and we may reach
        // several of them in the same frame.
        reachedEndOfPath = false;
        // The distance to the next waypoint in the path
        float distanceToWaypoint;
        while (true)
        {
            // If you want maximum performance you can check the squared distance instead to get rid of a
            // square root calculation. But that is outside the scope of this tutorial.
            distanceToWaypoint = Vector3.Distance(transform.position, _path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance)
            {
                // Check if there is another waypoint or if we have reached the end of the path
                if (currentWaypoint + 1 < _path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    // Set a status variable to indicate that the agent has reached the end of the path.
                    // You can use this to trigger some special code if your game requires that.
                    reachedEndOfPath = true;
                    break;
                }
            }
            else
            {
                break;
            }
        }

        // Slow down smoothly upon approaching the end of the path
        // This value will smoothly go from 1 to 0 as the agent approaches the last waypoint in the path.
        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;

        // Direction to the next waypoint
        // Normalize it so that it has a length of 1 world unit
        Vector3 dir = (_path.vectorPath[currentWaypoint] - transform.position).normalized;
        // Multiply the direction by our desired speed to get a velocity
        velocity = dir * speedFactor;


        // If you are writing a 2D game you may want to remove the CharacterController and instead modify the position directly
        // transform.position += velocity * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTargetInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTargetInRange = false;
        }
    }
    #endregion

    #region Methods
    public virtual void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        { 
            _audioManger.PlaySound(clip);
            gameObject.SetActive(false);
        }
        Shaker.ShakeAll(shakePreset);

    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

        // Path pooling. To avoid unnecessary allocations paths are reference counted.
        // Calling Claim will increase the reference count by 1 and Release will reduce
        // it by one, when it reaches zero the path will be pooled and then it may be used
        // by other scripts. The ABPath.Construct and Seeker.StartPath methods will
        // take a path from the pool if possible. See also the documentation page about path pooling.
        p.Claim(this);
        if (!p.error)
        {
            if (_path != null) _path.Release(this);
            _path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
        else
        {
            p.Release(this);
        }
    }

    #endregion
}
