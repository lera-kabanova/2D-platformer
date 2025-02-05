using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerReferences 
{
    [SerializeField]
    private GameObject[] weaponObjects;

    public GameObject[] WeaponObjects { get => weaponObjects; set => weaponObjects = value; }
}
