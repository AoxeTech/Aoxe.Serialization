Trace.Listeners.Add(new ConsoleTraceListener());

var runner = new Runner();
runner.FromBytes(100000);
runner.FromStream(100000);
runner.FromStreamAsync(100000);
runner.FromText(100000);
runner.ToBytes(100000);
runner.ToStream(100000);
runner.ToText(100000);

Console.ReadLine();