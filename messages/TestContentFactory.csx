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
        var q1004 = new TestQuestion(
            "A 28-year-old man is thrown from his motorcycle and sustains the closed injury seen in Figure A.  The limb remains neurovascularly intact.  What is the most appropriate initial treatment of this injury?",
            new Dictionary<int, string>()
            {
                { 1, "Bulky compressive splint" },
                { 2, "Open reduction and internal fixation" },
                { 3, "Closed intramedullary nailing" },
                { 4, "Spanning external fixation" },
                { 5, "Hinged spanning external fixation" }
            },
            4);
            q1004.AttachedImages.Add("http://upload.orthobullets.com/question/1004/images/prox%20tibia%201.jpg");
            yield return q1004;

        // 3670
        var q3670 =  new TestQuestion(
            "Which of the following foot conditions is most appropriately treated with the orthotic shown in Figure A?",
            new Dictionary<int, string>()
            {
                { 1, "Hallux rigidus" },
                { 2, "Hallux valgus" },
                { 3, "Midfoot arthritis" },
                { 4, "Freiberg Infraction" },
                { 5, @"Interdigital neuroma (Morton's)" } 
            },
            1);
        q3670.AttachedImages.Add("http://upload.orthobullets.com/question/3670/images/mortons%20extension.jpg");
        q3670.AttachedImages.Add("http://upload.orthobullets.com/question/3670/images/hallux%20rigidus%20xr.jpg");
        yield return q3670;
    }
}