using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovementUIController : MonoBehaviour
{
    [SerializeField] InvestigatorStats stats;
    [SerializeField] TextMeshProUGUI movementPointText;

    public void UpdateMovementPointText()
    {
        movementPointText.text = stats.speed.ToString(); // Add other movement modifiers, too
    }
}
