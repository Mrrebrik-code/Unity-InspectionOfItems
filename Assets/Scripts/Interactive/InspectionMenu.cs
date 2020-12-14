using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectionMenu : MonoBehaviour
{
    [SerializeField] private GameObject inspectionMenu;
    [SerializeField] private GameObject crosshair;

    [SerializeField] private Text descriptionItem;
    [SerializeField] private Text nameItem;
    public void ShowHideMenu(bool active)
    {
        inspectionMenu.SetActive(active);
        crosshair.SetActive(!active);
    }
    public void DescribeItem(string name,string description)
    {
        nameItem.text = name;
        descriptionItem.text = description;
    }
}
