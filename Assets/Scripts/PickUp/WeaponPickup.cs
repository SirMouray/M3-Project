using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : PickupEffects
{
    [SerializeField] private Gun _weapon;

    public override void OnPick(GameObject picker)
    {
        var weaponHolder = picker.GetComponent<WeaponHolder>();

        if (weaponHolder != null)
        {
            weaponHolder.EquipWeapon(_weapon);
        }
    }
}