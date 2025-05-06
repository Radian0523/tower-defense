using UnityEngine;

public class ProductSniperTower : MonoBehaviour, IProduct
{
    [SerializeField]
    private string m_ProductName = "Sniper Tower";

    public string ProductName { get => m_ProductName; set => m_ProductName = value; }

    public void Init()
    {
        gameObject.name = m_ProductName;
    }
}