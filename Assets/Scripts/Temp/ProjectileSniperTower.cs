using System.Collections;
using UnityEngine;

// Temporary class for the projectile of the sniper tower
[RequireComponent(typeof(Rigidbody), typeof(PooledObject))]
public class ProjectileSniperTower : MonoBehaviour
{
    [SerializeField]
    private float m_LifeTime = 2f;

    PooledObject pooledObject;

    void Awake()
    {
        pooledObject = GetComponent<PooledObject>();
    }

    public void Deactivate()
    {
        StartCoroutine(DeactivateRoutine(m_LifeTime));
    }

    IEnumerator DeactivateRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.linearVelocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        pooledObject.Release();
        gameObject.SetActive(false);
    }
}