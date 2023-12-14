using System;

public enum State
{
    Start,
    Stop
}
public class FortState
{
    //Stock l'�tat actuel
    private State _state;

    public FortState()
    {
        _state = State.Stop;
    }

    //Changement d'�tat
    public void ChangeState(State newState)
    {
        _state = newState;
    }

    //Effectuer une action en fonction de l'�tat actuel
    public void Action()
    {
        switch (_state)
        {
            case State.Start:
                Console.WriteLine("En cours d'ex�cution...");
                break;
            case State.Stop:
                Console.WriteLine("Arr�t�.");
                break;
            default:
                Console.WriteLine("�tat non reconnu.");
                break;
        }
    }
}
