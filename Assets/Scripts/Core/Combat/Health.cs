using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : NetworkBehaviour
{
    public NetworkVariable<int> currentHealth = new NetworkVariable<int>();
    [field: SerializeField] public int MaxHealth { get; private set; } = 100;

    private bool isDead;
    public Action<Health> OnDie;
    

    public override void OnNetworkSpawn()
    {
        if (!IsServer) { return; }

        currentHealth.Value = MaxHealth;
    }

    public void TakeDamage(int damageValue)
    {
        ModifyHealth(-damageValue);
    }
    
    public void RestoreHealth(int healValue)
    {
        ModifyHealth(healValue);
    }
    
    private void ModifyHealth(int value)
    {
        if (!isDead) { return; }

        int newHealth = currentHealth.Value + value;
        currentHealth.Value = Mathf.Clamp(newHealth, 0, MaxHealth);

        if (currentHealth.Value == 0)
        {
            OnDie?.Invoke(this);
            isDead = true;
        }
    }
}

