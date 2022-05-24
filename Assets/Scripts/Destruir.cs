using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    [SerializeField]
    GameObject textoGanar;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        textoGanar.SetActive(true);
    }
}
