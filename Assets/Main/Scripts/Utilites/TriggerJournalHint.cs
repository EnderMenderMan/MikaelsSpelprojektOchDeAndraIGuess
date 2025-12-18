using UnityEngine;

public class TriggerJournalHint : MonoBehaviour
{
    [Tooltip("The amount this scripts function TiggerHint can be triggered")][SerializeField] int canBeTriggeredAmount;
    [Tooltip("If true the scipts function TriggerHint will trigger the next journal hint. If set to true will override triggerSpecificHint")][SerializeField] bool TriggerNextHint;
    [Tooltip("The specific journal hint that this scripts function TriggerHint will trigger. Will only work if TriggerNextHint is set to false")][SerializeField] Journal.HintType triggerSpecificHint;

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
