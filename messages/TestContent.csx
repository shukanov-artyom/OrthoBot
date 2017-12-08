#load "TestQuestion.csx"

using System.Collections.Generic;

public class TestContent
{
    public TestContent()
    {
        Questions = new List<TestQuestion>();
    }

    public List<TestQuestion> Questions
    {
        get;
    }
}