#load "BotAction.csx"
#load "TestRequest.csx"
#load "InfoDialog.csx"
#load "TestContent.csx"
#load "TestContentFactory.csx"
#load "PassTestDialog.csx"
#load "TestResult.csx"

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;

[Serializable]
public class RootDialog : IDialog<object>
{
    protected int count = 1;

    public Task StartAsync(IDialogContext context)
    {
        try
        {
            context.Wait(MessageReceivedAsync);
        }
        catch (OperationCanceledException error)
        {
            return Task.FromCanceled(error.CancellationToken);
        }
        catch (Exception error)
        {
            return Task.FromException(error);
        }
        return Task.CompletedTask;
    }

    public virtual async Task MessageReceivedAsync(
        IDialogContext context,
        IAwaitable<IMessageActivity> result)
    {
        var message = await result;
        string messageLower = message.Text.ToLower();
        if (messageLower.Contains("test"))
        {
            EnterTestRequestDialog(context);
        }
        else if (messageLower.Contains("info"))
        {
            await context.Forward(
                new InfoDialog(),
                ResumeAfterInfoDialog,
                message,
                CancellationToken.None);
        }
        else
        {
            ShowOptions(context);
        }
    }

    private void ShowOptions(IDialogContext context)
        {
            PromptDialog.Choice(
                context,
                OnOptionSelected,
                new List<string>()
                {
                    BotAction.None,
                    BotAction.PassTest,
                    BotAction.DisplayInfo
                },
                "Please select an option",
                "Not a valid option",
                3);
        }

    private async Task ResumeAfterInfoDialog(
        IDialogContext context,
        IAwaitable<object> result)
    {
        context.Wait(MessageReceivedAsync);
    }

    private async Task OnOptionSelected(
        IDialogContext context,
        IAwaitable<string> result)
    {
        try
        {
            string optionSelected = await result;
            if (optionSelected == BotAction.None)
            {
                // Will it crash?
                await context.PostAsync("Ok, let me know if you need something.");
                context.Wait(MessageReceivedAsync);
            }
            else if (optionSelected == BotAction.PassTest)
            {
                EnterTestRequestDialog(context);
            }
            else if (optionSelected == BotAction.DisplayInfo)
            {
                await context.PostAsync("Orthobullets Demo Bot. Hope you like it!");
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                throw new InvalidOperationException("Incorrect input.");
            }
        }
        catch (TooManyAttemptsException ex)
        {
            await context.PostAsync("Too many attemps. But please keep trying!");
            context.Wait(MessageReceivedAsync);
        }
    }

    private void EnterTestRequestDialog(IDialogContext context)
    {
        var testRequestDialog = FormDialog.FromForm(
            TestRequest.BuildForm,
            FormOptions.PromptInStart);
        context.Call(
            testRequestDialog,
            ResumeAfterTestRequestDialog);
    }

    private async Task ResumeAfterTestRequestDialog(
        IDialogContext context,
        IAwaitable<TestRequest> result)
    {
        TestRequest request = await result;
        TestContent content = new TestContentFactory(request).Create();
        var dialog = new PassTestDialog(content);
        await context.PostAsync("Starting test!");
        context.Call(dialog, ResumeAfterTestPassed);
    }

    private async Task ResumeAfterTestPassed(
        IDialogContext context,
        IAwaitable<TestResult> result)
    {
        var testResult = await result;
        await context.PostAsync($"Test passed! Your result: {testResult.Ratio}");
        context.Wait(MessageReceivedAsync);
    }
}