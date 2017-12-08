using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;
using MultiDialogsBot.Domain;
using MultiDialogsBot.Domain.Content;

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
        IAwaitable<IMessageActivity> argument)
    {
        var message = await result;
        string messageLower = message.Text.ToLower();
        if (messageLower.Contains("test"))
        {
            throw new NotImplementedException();
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
        throw new NotImplementedException("OnOptionSelected");
        // try
        // {
        //     string optionSelected = await result;
        //     if (optionSelected == BotAction.None)
        //     {
        //         // Will it crash?
        //         context.Done<object>(null);
        //     }
        //     else if (optionSelected == BotAction.PassTest)
        //     {
        //         var testRequestDialog = FormDialog.FromForm(
        //             TestRequest.BuildForm,
        //             FormOptions.PromptInStart);
        //         context.Call(
        //             testRequestDialog,
        //             ResumeAfterTestRequestDialog);
        //     }
        //     else if (optionSelected == BotAction.DisplayInfo)
        //     {
        //         await context.PostAsync("Orthobullets Demo Bot. Hope you like it!");
        //         context.Wait(MessageReceivedAsync);
        //     }
        //     else
        //     {
        //         throw new InvalidOperationException("Incorrect input.");
        //     }
        // }
        // catch (TooManyAttemptsException ex)
        // {
        //     await context.PostAsync("Too many attemps. But please keep trying!");
        //     context.Wait(MessageReceivedAsync);
        // }
    }
}