using System;
using UnityEngine;
using System.Collections.Generic;
public class Gravityyyy : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f; //Gervitational 6.674

    public static List<Gravityyyy> OtherObjecList;

   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (OtherObjecList == null)
        {
            OtherObjecList = new List<Gravityyyy>();
        }
        
        OtherObjecList.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (Gravityyyy Obj in OtherObjecList)
        {
            if (Obj != this)
            {
                Attract(Obj);
            }
        }
    }

    void Attract(Gravityyyy other)
    {
        Rigidbody otherRb = other.rb;

        Vector3 direction = rb.position - otherRb.position;

        float distance = direction.magnitude;

        if (distance == 0f) {return;}

        float ForceMagnitude = G * (rb.mass * otherRb.mass) / Mathf.Pow(distance, 2);

        Vector3 GravityForce = ForceMagnitude * direction.normalized;
        
        otherRb.AddForce(GravityForce);

    }

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
