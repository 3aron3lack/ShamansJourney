using UnityEngine;
using UnityEngine.Events;

public class CheckDialogNumber : MonoBehaviour
{
    private int dialogNumber = 0;
    public UnityEvent OnDialogEnd;


    public void AddDialogInt()
    {
        dialogNumber++;
    }
    public void DialogAction()
    {
        if(dialogNumber == 1)
        {
            OnDialogEnd.Invoke();
        }
    }
}
