public class TestQuestion
{
    public TestQuestion(string text,
        IDictionary<int, string> answers,
        int correctAnswer)
    {
        Text = text;
        Answers = answers;
        CorrectAnswer = correctAnswer;
    }

    public string Text { get; }

    public IDictionary<int, string> Answers { get; }

    public int CorrectAnswer { get; }
}