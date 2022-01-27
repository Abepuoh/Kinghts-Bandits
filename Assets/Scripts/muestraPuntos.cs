using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muestraPuntos : MonoBehaviour
{
    [SerializeField] private Transform origen;
    [SerializeField] private Transform destino;
    // Start is called before the first frame update
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(origen.position, 0.1f);
        Gizmos.DrawSphere(destino.position, 0.1f);
    }
}
