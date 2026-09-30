using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRSimpleInteractable))]
public class BotonReinicio : MonoBehaviour
{
    XRSimpleInteractable interactable;

    void Awake() => interactable = GetComponent<XRSimpleInteractable>();
    void OnEnable() => interactable.selectEntered.AddListener(Reiniciar);
    void OnDisable() => interactable.selectEntered.RemoveListener(Reiniciar);

    void Reiniciar(SelectEnterEventArgs args)
    {
        foreach (var objeto in FindObjectsByType<Reaparecer>())
            objeto.Volver();
    }
}
