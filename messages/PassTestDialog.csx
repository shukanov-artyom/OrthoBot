#load "TestResult.csx"
#load "TestContent.csx"

using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

public class PassTestDialog : IDialog<object>
{
    // private readonly TestContent testContent;

    // public PassTestDialog(TestContent testContent)
    // {
    //     this.testContent = testContent;
    // }

    public async Task StartAsync(IDialogContext context)
    {
        context.Wait(WaitForMessage);
    }

    private async Task WaitForMessage(
        IDialogContext context,
        IAwaitable<object> result)
    {
        var message = await result;
        context.Done<object>(null);
    }
}