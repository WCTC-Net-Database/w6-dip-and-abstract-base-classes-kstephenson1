﻿namespace w6_assignment_ksteph.Commands.Invokers;

public class CommandInvoker
{
    // CommandInvoker is used to keep a log of and execute commands.

    private List<ICommand> _commands;

    public CommandInvoker()
    {
        _commands = new();
    }

    public void ExecuteCommand(ICommand command)
    {
        _commands.Add(command);
        command.Execute();
    }
}
