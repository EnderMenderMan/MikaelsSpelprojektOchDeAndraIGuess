using UnityEngine;

public class TriggerJournalHint : MonoBehaviour
{
    [SerializeField] int canBeTriggeredAmount;
    [SerializeField] bool TriggerNextHint;
    [SerializeField] Journal.HintType triggerSpecificHint;

    public void TriggerHint()
    {
        if (canBeTriggeredAmount == 0)
            return;
        canBeTriggeredAmount--;
        if (TriggerNextHint)
        {
            Journal.Instance.TriggerNextHint();
        }
        else
        {
            Journal.Instance.TryTriggerHint(triggerSpecificHint);
        }
    }
}
