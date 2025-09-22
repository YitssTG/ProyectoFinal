using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Camera cam;
    [SerializeField] private float stoppingDistance = 0.5f;

    void Awake()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (cam == null) cam = Camera.main;
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            agent.stoppingDistance = stoppingDistance;
            agent.SetDestination(hit.point);
        }
    }

    public bool IsMoving()
    {
        return agent.hasPath && agent.remainingDistance > agent.stoppingDistance;
    }
}