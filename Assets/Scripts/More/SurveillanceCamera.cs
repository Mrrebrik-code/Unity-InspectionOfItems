using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveillanceCamera : MonoBehaviour
{

    [SerializeField] private GameObject cameraItem;
    [SerializeField] private GameObject fantom;
    [SerializeField] Interactive interactive;
    [SerializeField] Material fantommat;
    [SerializeField] Material normal;

    private RaycastHit hitFantomLeft;
    private RaycastHit hitFantomRight;
    private RaycastHit hitFantomDown;
    private RaycastHit hitFantomBack;

    Vector3 axisAdd = new Vector3(0f, 0f, 0f);


    private void Start()
    {
    }
    private void Update()
    {

        CreateFantom();
    }


    private void CreateFantom()
    {
        if (fantom == null)
        {
            fantom = Instantiate(cameraItem);
            fantom.GetComponent<BoxCollider>().enabled = false;
            fantom.gameObject.name = "Fantom " + cameraItem.name;
            fantom.GetComponent<MeshRenderer>().material = fantommat;
        }
        else
        {
            LogicCreatFantom();
            fantom.transform.position = interactive.hit.point + axisAdd;
        }

        if (interactive.hit.transform == null && fantom != null)
            Destroy(fantom);
    }

    private void LogicCreatFantom()
    {

    }
}
