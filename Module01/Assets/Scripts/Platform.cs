using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private LayerMask layersAllowed;

    private Collider platformCollider;

    private void Awake()
    {
        platformCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool isAllowed =
            (layersAllowed.value & (1 << collision.gameObject.layer)) != 0;

        if (!isAllowed)
        {
            Physics.IgnoreCollision(
                collision.collider,
                platformCollider,
                true
            );
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        bool isAllowed =
            (layersAllowed.value & (1 << collision.gameObject.layer)) != 0;

        if (!isAllowed)
        {
            Physics.IgnoreCollision(
                collision.collider,
                platformCollider,
                false
            );
        }
    }
}