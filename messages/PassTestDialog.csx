#load "TestResult.csx"
#load "TestContent.csx"

using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;

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
        await DisplayCurrentQuestionAsync(context);
        //context.Wait<string>(WaitForAnswerOnCurrentQuestion);
    }

    private async Task DisplayCurrentQuestionAsync(IDialogContext context)
    {
        await context.PostAsync($"Question {currentQuestionNumber + 1}");
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
        IMessageActivity messageOptions = context.MakeMessage();
        StringBuilder optionsTextBuilder = new StringBuilder();
        var options = new List<string>();
        foreach (var option in question.Answers)
        {
            options.Add(option.Value);
        }
        string optionsTotalText = optionsTextBuilder.ToString();
        messageOptions.Text = optionsTotalText;
        await context.PostAsync(messageOptions);
        PromptDialog.Choice(
            context,
            WaitForAnswerOnCurrentQuestion,
            options,
            "Please select an option",
            "Not a valid option",
            3);
    }

    private async Task WaitForAnswerOnCurrentQuestion(
        IDialogContext context,
        IAwaitable<string> result)
    {
        var question = testContent.Questions[currentQuestionNumber];
        string answer = await result;
        int answerNumber;
        bool hasTextualAnswer = question.Answers.Any(a => a.Value == answer);
        if (Int32.TryParse(answer, out answerNumber) || hasTextualAnswer)
        {
            if (hasTextualAnswer)
            {
                answerNumber = question.Answers.First(a => a.Value == answer).Key;
            }
            questionsAndAnswers[currentQuestionNumber] = answerNumber;
            if (currentQuestionNumber == testContent.Questions.Count - 1)
            {
                context.Done<TestResult>(new TestResult(testContent, questionsAndAnswers));
            }
            else
            {
                currentQuestionNumber++;
                await DisplayCurrentQuestionAsync(context);
            }
        }
        else
        {
            await context.PostAsync("This is not an answer, please try again.");
            context.Wait<string>(WaitForAnswerOnCurrentQuestion);
        }
    }
}