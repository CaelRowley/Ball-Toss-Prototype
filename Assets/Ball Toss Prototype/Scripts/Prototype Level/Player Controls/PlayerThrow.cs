﻿using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed;

    // Spawns projectile when the magnet switch is used
    private void Update()
    {
        if(GvrViewer.Instance.Triggered)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
}
