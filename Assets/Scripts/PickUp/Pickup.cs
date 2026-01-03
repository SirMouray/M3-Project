using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float _lifeSpan;

    private PickupEffects _effect;

    private void Awake()
    {
        _effect = GetComponent<PickupEffects>();
    }

    private void Start()
    {
        Destroy(gameObject, _lifeSpan);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (_effect != null)
        {
            _effect.OnPick(other.gameObject);
        }
        Destroy(gameObject);
    }
}
