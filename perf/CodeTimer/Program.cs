Trace.Listeners.Add(new ConsoleTraceListener());

Console.WriteLine("CodeTimer go!");

var @case = new Case();
const int iteration = 100000;

@case.FromBytes(iteration);
@case.FromStream(iteration);
@case.FromStreamAsync(iteration);
@case.FromText(iteration);
@case.ToBytes(iteration);
@case.ToStream(iteration);
@case.ToText(iteration);

Console.WriteLine("CodeTimer complete!");

Console.ReadLine();
