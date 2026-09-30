using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Collider))]
public class CajaHerramientas : MonoBehaviour
{
    [SerializeField] TextMesh marcador;

    // Cada herramienta tiene varias piezas con collider, así que se cuentan las piezas dentro de cada una.
    readonly Dictionary<Rigidbody, int> dentro = new Dictionary<Rigidbody, int>();
    int total;

    void Start()
    {
        total = FindObjectsByType<XRGrabInteractable>().Length;
        ActualizarMarcador();
    }

    void OnTriggerEnter(Collider other)
    {
        var cuerpo = other.attachedRigidbody;
        if (cuerpo == null || !cuerpo.TryGetComponent<XRGrabInteractable>(out _))
            return;

        dentro.TryGetValue(cuerpo, out var piezas);
        dentro[cuerpo] = piezas + 1;
        if (piezas == 0)
            ActualizarMarcador();
    }

    void OnTriggerExit(Collider other)
    {
        var cuerpo = other.attachedRigidbody;
        if (cuerpo == null || !dentro.TryGetValue(cuerpo, out var piezas))
            return;

        if (piezas > 1)
        {
            dentro[cuerpo] = piezas - 1;
            return;
        }

        dentro.Remove(cuerpo);
        ActualizarMarcador();
    }

    void ActualizarMarcador()
    {
        marcador.text = dentro.Count == total
            ? "¡Taller ordenado!"
            : $"Herramientas guardadas\n{dentro.Count} de {total}";
    }
}
