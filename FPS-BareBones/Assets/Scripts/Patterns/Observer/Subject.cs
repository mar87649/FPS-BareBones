using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : ISubject
{
    public enum State { PAUSED, UNPAUSED }
    public State state;

    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        Debug.Log("Subject: Attached an observer.");
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Remove(observer);
        Debug.Log("Subject: Detached an observer.");
    }

   public void Notify()
    {
        Debug.Log("Subject: Notifying observers...");

        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }

    public void SomeBusinessLogic()
    {
        Debug.Log("\nSubject: I'm doing something important.");
        this.state = State.PAUSED;

        Debug.Log("Subject: My state has just changed to: " + this.state);
        this.Notify();
    }
}
