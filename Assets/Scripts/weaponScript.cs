using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScript : MonoBehaviour
{
    public float throwForce = 10f;
    public float maxThrowForce = 4f;
    private float startTime;

    public GameObject prefab;
    private GameObject sphere;

    Camera FPScamera;

    // Start is called before the first frame update
    void Start()
    {
        FPScamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            startTime = Time.time;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            float endTime = Time.time;
            float force = CalculateForce(endTime - startTime);
            Shoot(force);
        }
    }

    private void Shoot(float force)
    {
        if (sphere != null)
        {
            Destroy(sphere);
        }

        sphere = Instantiate(prefab, transform.position, Quaternion.identity);
        sphere.GetComponent<Rigidbody>().AddForce(FPScamera.transform.forward * force, ForceMode.Impulse);
    }

    private float CalculateForce(float holdDownTime)
    {
        float normalizedHoldTime = Mathf.Clamp01(holdDownTime / maxThrowForce);
        float force = normalizedHoldTime * throwForce;
        return force;
    }
}
