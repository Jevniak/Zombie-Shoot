using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> rigidbodyList;

    private void Awake()
    {
        foreach (Rigidbody rb in rigidbodyList)
        {
            rb.isKinematic = true;
        }
    }
}