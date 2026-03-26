using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    public PlayerMovement Movement { get; private set; }
    public PlayerLook Look { get; private set; }
    public PlayerSurvival Survival { get; private set; }
    public PlayerInteraction Interaction { get; private set; }
    public PlayerInventory Inventory { get; private set; }

    private void Awake()
    {
        Movement = GetComponent<PlayerMovement>();
        Look = GetComponent<PlayerLook>();
        Survival = GetComponent<PlayerSurvival>();
        Interaction = GetComponent<PlayerInteraction>();
        Inventory = GetComponent<PlayerInventory>();
    }
}
