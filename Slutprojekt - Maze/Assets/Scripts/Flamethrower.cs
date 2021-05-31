using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 1.5f)]
    private float fireRate = 1;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFireSource;

    private float timer;
    private bool isShooting;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);

        muzzleParticle.Play();
        gunFireSource.Play();

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        float thickness = 2f; //<-- Desired thickness here.
        Vector3 origin = firePoint.position + new Vector3(0, 0.6f, -1.6f);
        Vector3 direction = firePoint.TransformDirection(Vector3.forward);
        if (Physics.SphereCast(ray, thickness, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Zombie>();
            if (health != null)
                health.TakeDamage(damage);
        }
        

    }
}
