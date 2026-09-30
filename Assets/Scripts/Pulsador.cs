using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

// Hunde el botón mientras está seleccionado para que se note la pulsación.
[RequireComponent(typeof(XRSimpleInteractable))]
public class Pulsador : MonoBehaviour
{
    [SerializeField] float recorrido = 0.015f;

    XRSimpleInteractable interactable;
    Vector3 posicionReposo;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        posicionReposo = transform.localPosition;
    }

    void OnEnable()
    {
        interactable.selectEntered.AddListener(Hundir);
        interactable.selectExited.AddListener(Soltar);
    }

    void OnDisable()
    {
        interactable.selectEntered.RemoveListener(Hundir);
        interactable.selectExited.RemoveListener(Soltar);
    }

    void Hundir(SelectEnterEventArgs args) => transform.localPosition = posicionReposo + Vector3.down * recorrido;
    void Soltar(SelectExitEventArgs args) => transform.localPosition = posicionReposo;
}
