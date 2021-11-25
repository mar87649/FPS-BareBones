using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverA : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as Subject).state == Subject.State.PAUSED)
        {
            //disable scripts
            Debug.Log("ConcreteObserverA: Reacted to the event.");
        }
    }
}
