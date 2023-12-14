using System;

public enum State
{
    Start,
    Stop
}
public class FortState
{
    //Stock l'état actuel
    private State _state;

    public FortState()
    {
        _state = State.Stop;
    }

    //Changement d'état
    public void ChangeState(State newState)
    {
        _state = newState;
    }

    //Effectuer une action en fonction de l'état actuel
    public void Action()
    {
        switch (_state)
        {
            case State.Start:
                Console.WriteLine("En cours d'exécution...");
                break;
            case State.Stop:
                Console.WriteLine("Arrêté.");
                break;
            default:
                Console.WriteLine("État non reconnu.");
                break;
        }
    }
}
