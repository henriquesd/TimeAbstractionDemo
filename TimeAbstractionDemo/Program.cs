using TimeAbstractionDemo;

var demoService = new DemoService(TimeProvider.System);

Console.WriteLine(demoService.GetTimeOfDay());
Console.WriteLine("--------------------");

await demoService.MethodWithDelay();
Console.WriteLine("--------------------");