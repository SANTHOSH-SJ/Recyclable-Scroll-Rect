﻿using System.Collections.Generic;
using UnityEngine;
using PolyAndCode.UI;

/// <summary>
/// Demo controller class for Recyclable Scroll Rect. 
/// A controller class is responsible for providing the scroll rect with datasource. Any class can be a controller class. 
/// The only requirement is to inherit from IRecyclableScrollRectDataSource and implement the interface methods
/// </summary>

//Dummy Data model for demostraion
struct ContactInfo
{
    public string Name;
    public string Gender;
    public string id;
}

public class RecyclableScrollerDemo : MonoBehaviour, IRecyclableScrollRectDataSource
{
    [SerializeField]
    RecyclableScrollRect _recyclableScrollRect;

    [SerializeField]
    private int _dataLength;

    //Dummy data List
    private List<ContactInfo> _contactList = new List<ContactInfo>();

    //Recyclable scroll rect's data source must be assigned in Awake.
    private void Awake()
    {
        InitData();
        _recyclableScrollRect.DataSource = this;
    }

    //Initialising _contactList with dummy data 
    private void InitData()
    {
        if (_contactList != null) _contactList.Clear();

        string[] genders = { "Male", "Female" };
        for (int i = 0; i < _dataLength; i++)
        {
            ContactInfo obj = new ContactInfo();
            obj.Name = i + "_Name";
            obj.Gender = genders[Random.Range(0, 2)];
            obj.id = "item : " + i;
            _contactList.Add(obj);
        }

    }

    #region DATA SOURCE

    /// <summary>
    /// implement GetItemCount and return list length.
    /// </summary>
    public int GetItemCount()
    {
        return _contactList.Count;
    }

    /// <summary>
    /// implement setCellData to configure the cell. It is called by Recyclable Scroll Rect while recycling cells.
    /// </summary>
    public void SetCell(ICell cell, int index)
    {
        var item = cell as DemoCell;
        item.nameLabel.text = _contactList[index].Name;
        item.genderLabel.text = _contactList[index].Gender;
        item.idLabel.text = _contactList[index].id;
    }
    
    #endregion
}


