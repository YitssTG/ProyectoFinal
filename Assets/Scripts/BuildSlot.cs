using UnityEngine;

public class BuildSlot : MonoBehaviour
{
    private GameObject builtTower;

    // Construir en este slot
    public void Build(GameObject towerPrefab)
    {
        if (builtTower != null)
        {
            Debug.Log("Este slot ya está ocupado.");
            return;
        }

        builtTower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
    }

    void OnMouseDown()
    {
        // Buscar al GameManager y construir en este slot
        GameManager.Instance.TryBuild(this);
    }
}