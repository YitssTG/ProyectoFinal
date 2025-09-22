using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject currentTower;   // Prefab de la torre
    public GridManager gridManager;   // Referencia al GridManager

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Llamado desde un slot al hacer click
    public void TryBuild(BuildSlot slot)
    {
        if (currentTower == null)
        {
            Debug.Log("No hay torre seleccionada.");
            return;
        }

        // 👇 Validar si el slot pertenece al GridManager
        bool isRegistered = false;
        foreach (BuildSlot s in gridManager.slots)
        {
            if (s == slot)
            {
                isRegistered = true;
                break;
            }
        }

        if (!isRegistered)
        {
            Debug.Log("Este slot no está registrado en el GridManager.");
            return;
        }

        slot.Build(currentTower);
    }
}