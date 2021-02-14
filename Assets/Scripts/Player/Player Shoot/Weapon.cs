using UnityEngine;


public class Weapon : MonoBehaviour
{
    #region Fields
    [SerializeField] private PoolManager _poolManager = default;
    public AudioManager _audioManger = default;
    [SerializeField] private Shot[] shots = default;

    [SerializeField] private InputHandler _inputHandler = default;

    private float nextTimeFire;
    private int shotIndex = 0;
    [SerializeField] private float refreshFireTime = 0.2f;

    #endregion

    #region Monobehaviour

    private void OnEnable()
    {
        _inputHandler.fireEvent += FireWeapon;
        _inputHandler.switchWeaponEvent += OnSwitchWeapon;
    }

    private void OnDisable()
    {
        _inputHandler.fireEvent -= FireWeapon;
        _inputHandler.switchWeaponEvent -= OnSwitchWeapon;
    }

    //private void Start()
    //{
    //    _audioManger.Audio = GetComponent<AudioSource>();
    //}
    #endregion

    #region Methods
    private void OnSwitchWeapon()
    {
        switch (shotIndex)
        {
            case 0:
                shotIndex = 1;
                break;
            case 1:
                shotIndex = 0;
                break;
        }
    }

    private bool CanFire()
    {
        return Time.time >= nextTimeFire;
    }

    private void FireWeapon()
    {
        if (CanFire())
        {
            nextTimeFire = Time.time + refreshFireTime;
            shots[shotIndex].Launch(this, _poolManager);
        }
    }

    #endregion
}
