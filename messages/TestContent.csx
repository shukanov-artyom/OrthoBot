#load "TestQuestion.csx"

using System.Collections.Generic;
using System.Linq;

[Serializable]
public class TestContent
{
    public TestContent(IEnumerable<TestQuestion> questions)
    {
        Questions = questions.ToList();
    }

    public List<TestQuestion> Questions
    {
        get;
    }
}