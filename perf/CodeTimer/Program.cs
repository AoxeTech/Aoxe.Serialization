Trace.Listeners.Add(new ConsoleTraceListener());

var @case = new Case();
@case.FromBytes(100000);
@case.FromStream(100000);
@case.FromStreamAsync(100000);
@case.FromText(100000);
@case.ToBytes(100000);
@case.ToStream(100000);
@case.ToText(100000);

Console.ReadLine();