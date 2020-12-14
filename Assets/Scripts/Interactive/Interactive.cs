using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera cameraFPC;
    [SerializeField] private LayerMask layerMask;//Inspection layer
    public RaycastHit hit;
    [HideInInspector]public Ray ray;
    [SerializeField] private float maxDistanceRay;

    [SerializeField] private InputState inputState;
    [SerializeField] private InspectionHandler inspectionHandler;
    private FPC fpc;
    [SerializeField] private CursorMode cursor;

    [SerializeField] private GameObject cameraInspection;
    [SerializeField] private PostProcessVolume postProcessing;

    [SerializeField] InspectionMenu inspectionMenu;

    private void Start()
    {
        Initializate();
    }

    private void Update()
    {
        Ray();
        CheckRaycast();

        CheckObject();
    }

    private void Initializate()
    {
        fpc = GetComponent<FPC>();
        cursor.Locked();    }
    private void Ray()
    {
        ray = cameraFPC.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

    }

    private void CheckRaycast()
    {
        //If the ray touches an object with the "Inspection" layer set
        //if (Physics.Raycast(ray, out hit, maxDistanceRay, layerMask.value))
        //{
        //    Debug.DrawRay(cameraFPC.transform.position, ray.direction * maxDistanceRay, Color.green);
        //}
        if (Physics.Raycast(ray, out hit, maxDistanceRay))
        {
            InstanceMode();
            Debug.DrawRay(cameraFPC.transform.position, ray.direction * maxDistanceRay, Color.blue);
        }
        //If the ray does not touch
        if(hit.transform == null)
        {
            Debug.DrawRay(cameraFPC.transform.position, ray.direction * maxDistanceRay, Color.red);
        }
        if (hit.transform != null && hit.transform.GetComponent<Items>())
        {
            Debug.DrawRay(cameraFPC.transform.position, ray.direction * maxDistanceRay, Color.green);
        }
    }

    private void CheckObject()
    {
        //If the object is Items
        if (hit.transform != null && hit.collider.gameObject.GetComponent<Items>())
        {
            TakeObject();
        }

    }

    private void TakeObject()
    {
        if (inputState.isTakeObject)
        {
            hit.transform.gameObject.layer = 8;
            Debug.Log("Предмет поднят");
            inspectionHandler.ItemsInspections(hit.transform.gameObject.GetComponent<Items>());
            inspectionHandler.isTaken = true;
            cursor.Unlocked();
            fpc.enabled = false;
            cameraFPC.cullingMask = 55;
            cameraInspection.SetActive(true);
            postProcessing.enabled = true;
            inspectionMenu.ShowHideMenu(true);
        }
    }

    private void InstanceMode()
    {

    }

}
