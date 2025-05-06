using Unity.VisualScripting;
using UnityEngine;

public class FactorySniperTower : Factory
{
    [SerializeField]
    private ProductSniperTower m_ProductPrefab;

    public override IProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(m_ProductPrefab.gameObject, position, Quaternion.identity);
        ProductSniperTower newProduct = instance.GetComponent<ProductSniperTower>();

        newProduct.Init();
        return newProduct;
    }
}