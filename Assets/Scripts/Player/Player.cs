using UnityEngine;
using VContainer;

public class Player : MonoBehaviour
{
    [Inject, Key("death menu")] private GameObject _deathMenu;
    [Inject, Key("dynamic objects")] private GameObject _dynamicObjects;

    private PlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    public void Die()
    {
        _deathMenu.SetActive(true);
        _dynamicObjects.SetActive(false);

        _input.DisableControl();
    }
}
