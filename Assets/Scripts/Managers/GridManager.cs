using UnityEngine;

public class GridManager : MonoBehaviour
{
    public BuildSlot[] slots; // Arrastras manualmente desde la escena

    // (Opcional) m�todo si quieres construir en slot por �ndice
    public void BuildInSlot(int index, GameObject towerPrefab)
    {
        if (index < 0 || index >= slots.Length) return;
        slots[index].Build(towerPrefab);
    }
}