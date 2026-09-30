using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Collider))]
public class Canasta : MonoBehaviour
{
    [SerializeField] TextMesh marcador;

    readonly HashSet<Rigidbody> dentro = new HashSet<Rigidbody>();
    int record;

    void Start() => ActualizarMarcador();

    void OnTriggerEnter(Collider other)
    {
        var cuerpo = other.attachedRigidbody;
        if (cuerpo == null || !cuerpo.TryGetComponent<XRGrabInteractable>(out _))
            return;

        if (dentro.Add(cuerpo))
            ActualizarMarcador();
    }

    void OnTriggerExit(Collider other)
    {
        var cuerpo = other.attachedRigidbody;
        if (cuerpo != null && dentro.Remove(cuerpo))
            ActualizarMarcador();
    }

    void ActualizarMarcador()
    {
        record = Mathf.Max(record, dentro.Count);
        marcador.text = $"En la canasta: {dentro.Count}\nRécord: {record}";
    }
}
