using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Gun _equippedWeapon;

    private void Start()
    {
        Instantiate(_equippedWeapon, transform);
    }

    public void EquipWeapon(Gun newWeapon)
    {
        _equippedWeapon = Instantiate(newWeapon, transform);
    }

    private void Update()
    {
        _equippedWeapon = GetComponentInChildren<Gun>();
    }
}
