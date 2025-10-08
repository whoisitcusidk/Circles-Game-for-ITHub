using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;
    [SerializeField] private GameObject _dynamic;

    private PlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    public void Die()
    {
        _deathMenu.SetActive(true);
        _dynamic.SetActive(false);

        _input.DisableControl();
    }
}
