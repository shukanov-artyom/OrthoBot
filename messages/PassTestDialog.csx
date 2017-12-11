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
        context.Wait(WaitForAnswerOnCurrentQuestion);
    }

    private async Task WaitForAnswerOnCurrentQuestion(
        IDialogContext context,
        IAwaitable<IMessageActivity> result)
    {
        IMessageActivity questionAnswer = await result;
        int answerInt;
        if (!Int32.TryParse(questionAnswer.Text, out answerInt))
        {
            context.PostAsync("This does not look like an answer number, please try again.");
            context.Wait(WaitForAnswerOnCurrentQuestion);
        }
        questionsAndAnswers[currentQuestionNumber] = answerInt;
        if (currentQuestionNumber == testContent.Questions.Count - 1)
        {
            context.Done<TestResult>(new TestResult(testContent, questionsAndAnswers));
        }
        else
        {
            currentQuestionNumber++;
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
            context.Wait(WaitForAnswerOnCurrentQuestion);
        }
    }
}