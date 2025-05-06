using UnityEngine;

public class FactoryHammerTower : Factory
{
    [SerializeField]
    private ProductHammerTower m_ProductPrefab;

    public override IProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(m_ProductPrefab.gameObject, position, Quaternion.identity);
        ProductHammerTower newProduct = instance.GetComponent<ProductHammerTower>();

        newProduct.Init();
        return newProduct;
    }
}