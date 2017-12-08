#load "TestResult.csx"
#load "TestContent.csx"

using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

public class PassTestDialog : IDialog<TestResult>
{
    private readonly TestContent testContent;

    public PassTestDialog(TestContent testContent)
    {
        this.testContent = testContent;
    }

    public Task StartAsync(IDialogContext context)
    {
        throw new NotImplementedException();
    }
}