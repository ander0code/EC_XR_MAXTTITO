using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRSimpleInteractable))]
public class InterruptorLuz : MonoBehaviour
{
    [SerializeField] Light luz;
    [SerializeField] Renderer bombilla;
    [SerializeField] Color colorEncendida = new Color(1f, 0.82f, 0.45f);
    [SerializeField] Color colorApagada = new Color(0.25f, 0.25f, 0.25f);

    XRSimpleInteractable interactable;
    Material materialBombilla;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        if (bombilla != null)
            materialBombilla = bombilla.material;
    }

    void OnEnable() => interactable.selectEntered.AddListener(Alternar);
    void OnDisable() => interactable.selectEntered.RemoveListener(Alternar);
    void Start() => ActualizarBombilla();

    void Alternar(SelectEnterEventArgs args)
    {
        luz.enabled = !luz.enabled;
        ActualizarBombilla();
    }

    void ActualizarBombilla()
    {
        if (materialBombilla == null)
            return;

        var color = luz.enabled ? colorEncendida : colorApagada;
        materialBombilla.color = color;
        materialBombilla.SetColor("_EmissionColor", luz.enabled ? color * 2f : Color.black);
    }
}
