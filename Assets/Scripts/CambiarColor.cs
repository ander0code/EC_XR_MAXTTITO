using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRSimpleInteractable), typeof(Renderer))]
public class CambiarColor : MonoBehaviour
{
    [SerializeField] Color[] colores =
    {
        new Color(0.16f, 0.32f, 0.62f),
        new Color(0.8f, 0.36f, 0.24f),
        new Color(0.45f, 0.55f, 0.25f),
        new Color(0.9f, 0.7f, 0.2f),
        new Color(0.5f, 0.22f, 0.4f),
    };

    XRSimpleInteractable interactable;
    Material material;
    int actual;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        material = GetComponent<Renderer>().material;
    }

    void OnEnable() => interactable.selectEntered.AddListener(Siguiente);
    void OnDisable() => interactable.selectEntered.RemoveListener(Siguiente);
    void Start() => material.color = colores[actual];

    void Siguiente(SelectEnterEventArgs args)
    {
        actual = (actual + 1) % colores.Length;
        material.color = colores[actual];
    }
}
