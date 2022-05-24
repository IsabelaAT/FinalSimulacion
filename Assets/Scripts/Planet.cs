
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float InfluenceRadius = 2;

    [SerializeField]
    private Transform influenceRegion;
    

    private void Start()
    {
        ChangeInfluenceRegion(InfluenceRadius);
    }

    private void OnValidate()
    {
        ChangeInfluenceRegion(InfluenceRadius);
    }

    public void ChangeInfluenceRegion(float newRadius)
    {
        InfluenceRadius = newRadius;
        influenceRegion.localScale = new Vector3(InfluenceRadius * 2f, InfluenceRadius * 2f, 1);
    }
}
