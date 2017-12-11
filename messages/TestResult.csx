#load "TestContent.csx"

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
    }
    public int TotalQuestionsAnswered { get; set; }

    public int CorrectQuestionAnswered { get; set; }
}