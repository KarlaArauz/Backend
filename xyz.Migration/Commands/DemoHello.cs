using Oakton;
using Spectre.Console;

namespace xyz.Migration.Commands;

public class DemoHello
{
    public class HelloInput
    {
        [Description("The greetings to be printed to the console output")]
        public string Saludo { get; set; }

        [Description("The color of the text. Default is black")]
        public ConsoleColor Color { get; set; } = ConsoleColor.Black;

        [Description("Optional title preceeding the name")]
        public string TitleFlag { get; set; }
    }

    [Description("Print somebody's name", Name = "dot-nothing")]
    public class DoNameThingsCommand : OaktonAsyncCommand<HelloInput>
    {
        public DoNameThingsCommand()
        {

        }

        public override async Task<bool> Execute(HelloInput input)
        {
            AnsiConsole.Write($"[{input.Color}]Starting...[/]");
            await Task.Delay(TimeSpan.FromSeconds(3));

            AnsiConsole.Write($"[{input.Color}]Done! {input.Saludo}[/]");
            return true;
        }
    }
}