using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [HideInInspector] public Vector3 startPosition;
    [HideInInspector] public Quaternion startRotation;
    [HideInInspector] public Vector3 startScale;

    public float AddScale;

    public string nameItem;
    public string descriptionItem;

    private void Awake()
    {
        startScale = gameObject.transform.localScale;
        startPosition = gameObject.transform.position;
        startRotation = gameObject.transform.rotation;
    }
}
