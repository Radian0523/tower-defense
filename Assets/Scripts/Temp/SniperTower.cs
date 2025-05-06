using UnityEngine;

// Temporary class to demonstrate the sniper tower functionality
public class SniperTower : MonoBehaviour
{
    [SerializeField] float m_Duration = 2f;
    [SerializeField] ObjectPool m_ObjectPool;
    [SerializeField] Transform muzzulePosition;
    [SerializeField] float muzzuleVelocity = 10f;

    float m_Timer = 0f;

    void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer <= m_Duration) return;
        m_Timer = 0f;
        Shoot();
    }

    void Shoot()
    {
        GameObject bulletObject = m_ObjectPool.GetPooledObject().gameObject;

        if (bulletObject == null) return;

        bulletObject.SetActive(true);

        bulletObject.transform.SetPositionAndRotation(muzzulePosition.position, muzzulePosition.rotation);

        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzuleVelocity, ForceMode.Acceleration);

        bulletObject.GetComponent<ProjectileSniperTower>().Deactivate();
    }
}