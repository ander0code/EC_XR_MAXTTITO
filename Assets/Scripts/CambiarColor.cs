using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRSimpleInteractable), typeof(Renderer))]
public class CambiarColor : MonoBehaviour
{
    [SerializeField] Color[] colores =
    {
        new Color(0.55f, 0.3f, 0.95f),
        new Color(0.2f, 0.8f, 0.55f),
        new Color(0.95f, 0.45f, 0.2f),
        new Color(0.25f, 0.6f, 0.95f),
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
