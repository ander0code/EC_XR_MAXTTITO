using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Feedback;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

// Los mandos del XR Interaction Simulator no tienen vibración y XRI lo avisa en la consola
// cada vez que intenta usarla. Con un visor real la vibración sigue activa.
public class HapticaSinVisor : MonoBehaviour
{
    void Start()
    {
        if (XRInteractionSimulator.instance == null)
            return;

        foreach (var vibracion in GetComponentsInChildren<SimpleHapticFeedback>(true))
            vibracion.enabled = false;
    }
}
