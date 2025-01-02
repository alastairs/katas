using Katas.Dependencies.Cli;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
    config.SetApplicationName("deps");
    config.AddCommand<PrintCommand>("print");
});

return app.Run(args);