using Godot;

public class EventService: IEventService {

    public void SendEvent(string eventName) {
        GD.Print("Sent event");
    } 
}