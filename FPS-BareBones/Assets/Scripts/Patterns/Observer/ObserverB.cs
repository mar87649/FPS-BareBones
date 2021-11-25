using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverB : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as Subject).State == Subject.State.PAUSED || (subject as Subject).State >= Subject.State.UNPAUSED)
        {
            Debug.Log("ConcreteObserverB: Reacted to the event.");
        }
    }
}
