using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class InspectionHandler : MonoBehaviour
{
    public enum CulingMasks
    {
        InspectionON = 55,
        InspectionOFF = -1
    }

    private Items item;
    [SerializeField] private InputState inputState;
    [SerializeField] private FPC fpc;
    [SerializeField] private Camera cameraFPC;
    [SerializeField] private CursorMode cursor;
    public GameObject positionItems;

    [SerializeField] private GameObject cameraInspection;

    private float xRot, yRot;
    [SerializeField] private float speedRotation;

    [SerializeField] private PostProcessVolume postProcessing;

    [SerializeField] private InspectionMenu inspectionMenu;

    [HideInInspector]public bool isTaken;
    private bool isRotation;

    public Vector3 posLareFrame;

    public float x;


    private void Update()
    {
        
        if (item != null)
        {
            item.gameObject.transform.position = positionItems.transform.position;
            //item.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));

        }
        if (inputState.isDropObject && isTaken)
        {
            DropItems();
        }

        if (inputState.isRotationObject && isTaken)
        {
            RotationItems();
        }

        if (inputState.isZoomObject && isTaken)
        {
            ZoomItems();
        }
    }


    public void ItemsInspections(Items item)
    {
        this.item = item;
        inspectionMenu.DescribeItem(this.item.nameItem, this.item.descriptionItem);
        item.gameObject.transform.localScale += new Vector3(item.AddScale, item.AddScale, item.AddScale); 

    }
    private void RotationItems()
    {
        RotationHandler();

        item.gameObject.transform.rotation = Quaternion.Euler(yRot, -xRot, -30f);

    }

    private void ZoomItems()
    {
        float x = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(x);
    }

    private void DropItems()
    {
        Debug.Log("Предмет выброшен");
        item.gameObject.transform.position = item.startPosition;
        item.gameObject.transform.rotation = item.startRotation;
        item.gameObject.transform.localScale = item.startScale;
        isTaken = false;
        cursor.Locked();
        fpc.enabled = true;
        item.gameObject.layer = 0;
        item = null;
        cameraFPC.cullingMask = (int)CulingMasks.InspectionOFF;
        cameraInspection.SetActive(false);
        postProcessing.enabled = false;
        inspectionMenu.ShowHideMenu(false);
    }

    private void RotationHandler()
    {
        xRot += Input.GetAxis("Mouse X") * speedRotation;
        yRot += Input.GetAxis("Mouse Y") * speedRotation;

    }
}
