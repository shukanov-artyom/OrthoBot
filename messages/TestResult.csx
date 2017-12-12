#load "TestContent.csx"

using System;
using System.Linq;

[Serializable]
public class TestResult
{
    private readonly TestContent content;
    private readonly IDictionary<int, int> questionNumbersAndAnswers;

    public TestResult(TestContent content,
        IDictionary<int, int> questionNumbersAndAnswers)
    {
        this.content = content;
        this.questionNumbersAndAnswers = questionNumbersAndAnswers;
        TotalQuestionsAnswered = content.Questions.Count;
        CorrectQuestionsAnswered = 0;
        for (int i = 0; i < TotalQuestionsAnswered; i++)
        {
            if (content.Questions[i].CorrectAnswer == questionNumbersAndAnswers[i])
            {
                CorrectQuestionsAnswered++;
            }
        }
        Ratio = $"{CorrectQuestionsAnswered} / {TotalQuestionsAnswered}";
    }
    public int TotalQuestionsAnswered { get; set; }

    public int CorrectQuestionsAnswered { get; set; }

    public string Ratio { get; }
}