using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.81f;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;

    [SerializeField]
    private AudioSource _weaponAudio;

    private int _currentAmmo;
    private int _maxAmmo = 50;
    private bool _isReloadingWeapon;
    private int _coins;

    private UIManager _uiManager;

    public int Coins { get => _coins; }

    [SerializeField]
    private GameObject _weapon;


    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _currentAmmo = _maxAmmo;
        _uiManager.UpdateAmmo(_currentAmmo);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && _currentAmmo > 0 && _weapon.activeSelf)
        {
            Shoot();
        }
        else
        {
            _muzzleFlash.SetActive(false);
            _weaponAudio.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R) && !_isReloadingWeapon)
        {
            _isReloadingWeapon = true;
            StartCoroutine(ReloadWeapon());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        CalculateMovement();
    }

    void Shoot()
    {
        _muzzleFlash.SetActive(true);
        _currentAmmo--;
        _uiManager.UpdateAmmo(_currentAmmo);
        if (!_weaponAudio.isPlaying)
        {
            _weaponAudio.Play();
        }
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitMarker, 1f);
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        _uiManager.UpdateAmmo(_currentAmmo);
        _isReloadingWeapon = false;
    }

    public void AddCoins(int coins)
    {
        _coins += coins;
    }

    public void SubtractCoins(int coins)
    {
        _coins -= coins;
    }

    public void EnableWeapon()
    {
        _weapon.SetActive(true);
    }
}
