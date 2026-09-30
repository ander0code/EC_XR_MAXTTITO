using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Reaparecer : MonoBehaviour
{
    [SerializeField] float alturaMinima = -2f;

    Rigidbody cuerpo;
    Vector3 posicionInicial;
    Quaternion rotacionInicial;

    void Awake()
    {
        cuerpo = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }

    void FixedUpdate()
    {
        if (cuerpo.position.y < alturaMinima)
            Volver();
    }

    public void Volver()
    {
        if (!cuerpo.isKinematic)
        {
            cuerpo.linearVelocity = Vector3.zero;
            cuerpo.angularVelocity = Vector3.zero;
        }
        transform.SetPositionAndRotation(posicionInicial, rotacionInicial);
        cuerpo.position = posicionInicial;
        cuerpo.rotation = rotacionInicial;
    }
}
