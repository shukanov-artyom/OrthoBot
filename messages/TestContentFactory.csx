#load "TestContent.csx"
#load "TestRequest.csx"

using System;
using System.Linq;

public class TestContentFactory
{
    private readonly TestRequest request;

    public TestContentFactory(TestRequest request)
    {
        this.request = request;
    }

    public TestContent Create()
    {
        return new TestContent(GetQuestions().Take(request.QuestionsCount));
    }

    private IEnumerable<TestQuestion> GetQuestions()
    {
        // 1004
        // TODO 
        
        // 3670
        var q1004 =  new TestQuestion(
            "Which of the following foot conditions is most appropriately treated with the orthotic shown in Figure A?",
            new Dictionary<int, string>()
            {
                {1, "Hallux rigidus"},

            },
            1);
        q1004.AttachedImages.Add("http://upload.orthobullets.com/question/3670/images/mortons%20extension.jpg");
        q1004.AttachedImages.Add("http://upload.orthobullets.com/question/3670/images/hallux%20rigidus%20xr.jpg");
        yield return q1004;
    }
}