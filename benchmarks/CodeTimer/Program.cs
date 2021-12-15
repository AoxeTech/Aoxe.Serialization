// See https://aka.ms/new-console-template for more information


using CodeTimer.Runner;

Trace.Listeners.Add(new ConsoleTraceListener());

var runner = new Runner();
runner.FromBytes(1000);
runner.FromStream(1000);
runner.FromStreamAsync(1000);
runner.FromText(1000);
runner.ToBytes(1000);
runner.ToStream(1000);
runner.ToText(1000);

Console.ReadLine();