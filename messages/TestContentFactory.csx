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

        // 4504
        var q4504 = new TestQuestion(
            "Skeletal maturity is an important variable in the progression of idiopathic scoliosis. Figures A-E are radiographs showing varying stages of skeletal maturity.  The patient represented by which Figure would be expected to have the highest risk of progression of an idiopathic scoliotic curve?",
            new Dictionary<int, string>() 
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" },
                    { 4, "D" },
                    { 5, "E" } 
                },
            3);
        q4504.AttachedImages.Add("http://upload.orthobullets.com/question/4504/images/screen+shot+2013-11-25+at+8.21.20+pm.jpg");
        q4504.AttachedImages.Add("http://upload.orthobullets.com/question/4504/images/screen+shot+2013-11-25+at+8.19.39+pm.jpg");
        q4504.AttachedImages.Add("http://upload.orthobullets.com/question/4504/images/screen+shot+2013-11-25+at+8.20.33+pm.jpg");
        q4504.AttachedImages.Add("http://upload.orthobullets.com/question/4504/images/screen+shot+2013-11-25+at+7.53.06+pm.jpg");
        q4504.AttachedImages.Add("http://upload.orthobullets.com/question/4504/images/screen+shot+2013-11-03+at+8.40.23+am.jpg");
        yield return q4504;

        // 3116
        var q3116 = new TestQuestion(
            "While dissecting in the middle window of the ilioinguinal approach a nerve is encountered entering the obturator foramen. Excessive retraction on this structure would result in which of the following?",
            new Dictionary<int, string>() 
                {
                    { 1, "Lateral thigh numbness" },
                    { 2, "Weakness in knee extension" },
                    { 3, "Anterior thigh numbness" },
                    { 4, "Medial thigh numbness" },
                    { 5, "Weakness in hip flexion" } 
                },
            4);
        q3116.AttachedImages.Add("http://upload.orthobullets.com/question/3116/images/obturator%201.jpg");
        q3116.AttachedImages.Add("http://upload.orthobullets.com/question/3116/images/sensory%20innervation.jpg");
        yield return q3116;

        // 4410
        var q4410 = new TestQuestion(
            "A 74-year-old man presents with start-up thigh pain following a total hip replacement 10 years ago.  Immediate post-operative radiograph is shown in Figure A.  A current radiograph is shown in Figure B.  Aspiration of the hip yields 1,005 white blood cells/ml.  ESR is 12 (normal <40) and CRP is 0.4 (normal <1.2).  Which of the following is the most appropriate management at this time?",
            new Dictionary<int, string>() 
                {
                    { 1, "Revision of the femoral component to an uncemented, long, fully porous-coated stem" },
                    { 2, "Revision of the femoral component to a cemented stem" },
                    { 3, "Revision of the femoral component to an allograft prosthetic composite" },
                    { 4, "Revision of the femoral component to a proximal femoral replacement" },
                    { 5, "Removal of prosthesis with insertion of antibiotic spacer" } 
                },
            1);
        q4410.AttachedImages.Add("http://upload.orthobullets.com/question/4410/images/subsidence.jpg");
        q4410.AttachedImages.Add("http://upload.orthobullets.com/question/4410/images/subsidence%20post.jpg");
        yield return q4410;

        // 3589
        var q3589 = new TestQuestion(
            "A 25-year-old right-hand dominant construction worker suffers an industrial injury as seen below.  He is hemodynamically stable and his only injury is to the limb below.   In terms of replantation of the affected limb, which of the following is true?",
            new Dictionary<int, string>() 
                {
                    { 1, "Transpositional microsurgery offers the best results" },
                    { 2, "Replantation is contraindicated as the injury is through flexor zone II" },
                    { 3, "Replantation is contraindicated because of the extent of injury" },
                    { 4, "Heterotopic transplantation would offer the best function" },
                    { 5, "Anatomic replantation of hand offers the best results" } 
                },
            5);
        q3589.AttachedImages.Add("http://upload.orthobullets.com/question/3589/images/photo%282%29.jpg");
        q3589.AttachedImages.Add("http://upload.orthobullets.com/question/3589/images/photo%281%29.jpg");
        q3589.AttachedImages.Add("http://upload.orthobullets.com/question/3589/images/photo%283%29.jpg");
        q3589.AttachedImages.Add("http://upload.orthobullets.com/question/3589/images/photo%284%29.jpg");
        q3589.AttachedImages.Add("http://upload.orthobullets.com/question/3589/images/multidigitreplantation1.jpg");
        yield return q3589;

        // 3288
        var q3288 = new TestQuestion(
            "Which of the following best describes a squamous cell carcinoma that develops as a result of chronic drainage from sinus tracts or a result of burn scars? ",
            new Dictionary<int, string>() 
                {
                    { 1, "Cushing's ulcer" },
                    { 2, "Mooren's ulcer" },
                    { 3, "Chancroid ulcer" },
                    { 4, "Marjolin's ulcer" },
                    { 5, "Curling's ulcer" } 
                },
            4);
        yield return q3288;

        // 4591
        var q4591 = new TestQuestion(
            "A 32-year-old female sustains a proximal humerus fracture shown in Figure A.  This fracture goes on to uneventful union, but she complains of a lack of sensation over the lateral deltoid and has weakness with the Hornblower's test at final follow-up.  Which of the following structures is most likely injured in this patient?",
            new Dictionary<int, string>() 
                {
                    { 1, "Anterior branch of the axillary nerve" },
                    { 2, "Posterior branch of the axillary nerve" },
                    { 3, "Posterior cord of the brachial plexus" },
                    { 4, "Suprascapular nerve" },
                    { 5, "Musculocutaneous nerve" } 
                },
            2);
        q4591.AttachedImages.Add("http://upload.orthobullets.com/question/4591/images/greater%20tuberosity%20humerus%20fx%201a.jpg");
        yield return q4591;

        // 1350
        var q1350 = new TestQuestion(
            "A load-elongation curve for a tendon is shown in Figure A. Which of the following statements accurately describes the region labeled X?",
            new Dictionary<int, string>() 
                {
                    { 1, "The failure region which has crimped tendon fibers" },
                    { 2, "The linear region which has parallel oriented tendon fibers" },
                    { 3, "The linear region which has crimped tendon fibers" },
                    { 4, "The toe region which has parallel oriented tendon fibers" },
                    { 5, "The toe region which has crimped tendon fibers" } 
                },
            5);
        q1350.AttachedImages.Add("http://upload.orthobullets.com/question/1350/images/creep.jpg");
        q1350.AttachedImages.Add("http://upload.orthobullets.com/question/1350/images/creep2.jpg");
        yield return q1350;

        // 2954
        var q2954 = new TestQuestion(
            "A 2-year and 11-month old child fell while playing with friends 2 hours ago and has avoided bearing weight on the right leg since that time. The child is afebrile and exam reveals tenderness along the distal tibial shaft with no significant swelling. Radiographs are shown in Figure A and B. What is the most appropriate treatment?",
            new Dictionary<int, string>() 
                {
                    { 1, "MRI of the tibia" },
                    { 2, "Aspiration of the tibia" },
                    { 3, "Referral to child services" },
                    { 4, "Long leg cast application" },
                    { 5, "Serum vitamin D, calcium, and phosphate levels" } 
                },
            4);
        q2954.AttachedImages.Add("http://upload.orthobullets.com/question/2954/images/toddlers%20ap%20xr.jpg");
        q2954.AttachedImages.Add("http://upload.orthobullets.com/question/2954/images/toddlers%20lat%20xr.jpg");
        yield return q2954;
    }
}