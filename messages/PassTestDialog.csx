#load "TestResult.csx"
#load "TestContent.csx"

using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

[Serializable]
public class PassTestDialog : IDialog<TestResult>
{
    private readonly TestContent testContent;

    private readonly Dictionary<int, int> questionsAndAnswers = 
        new Dictionary<int, int>();

    private int currentQuestionNumber;

    public PassTestDialog(TestContent testContent)
    {
        this.testContent = testContent;
        currentQuestionNumber = 0;
    }

    public async Task StartAsync(IDialogContext context)
    {
        await context.PostAsync("Entered test dialog!");
        await DisplayCurrentQuestionAsync(context);
        context.Wait(WaitForAnswerOnCurrentQuestion);
    }

    private async Task PostNextQuestionWaitForAnswer(
        IDialogContext context,
        IAwaitable<object> result)
    {
        currentQuestionNumber++;
        await DisplayCurrentQuestionAsync(context);
        context.Wait(WaitForAnswerOnCurrentQuestion);
    }

    private async Task DisplayCurrentQuestionAsync(
        IDialogContext context)
    {
        var question = testContent.Questions[currentQuestionNumber];
        IMessageActivity message = context.MakeMessage();
        message.Text = question.Text;
        foreach (var attachment in question.AttachedImages)
        {
            message.Attachments.Add(
            new Attachment() 
            {
                ContentType = "image/jpeg",
                ContentUrl = attachment
            });
        }
        await context.PostAsync(message);
    }

    private async Task WaitForAnswerOnCurrentQuestion(
        IDialogContext context,
        IAwaitable<object> result
    )
    {
        var questionAnswer = await result;
        questionsAndAnswers[currentQuestionNumber] = Int32.Parse((string)questionAnswer);
        // TODO : input validation
        if (currentQuestionNumber == testContent.Questions.Count - 1)
        {
            context.Done(new TestResult(testContent, questionsAndAnswers));
        }
        context.Wait(PostNextQuestionWaitForAnswer);
    }
}