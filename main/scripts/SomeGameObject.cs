using Godot;
using System;

namespace ExampleGame;

public partial class SomeGameObject(string name, int number, IEventService eventService)
{
    public string Name = name;
    public int Number = number;
    
    private IEventService _eventService = eventService;

    public void IncrementNumber() {
        Number++;
    }

    public void ChangeName(string newName) {
        Name = newName;
        _eventService?.SendEvent("NameChanged");
    }


}
