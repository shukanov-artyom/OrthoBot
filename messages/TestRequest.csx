using System;
using System.Collections.Generic;
using Microsoft.Bot.Builder.FormFlow;

[Serializable]
public class TestRequest
{
    public int QuestionsCount { get; set; }

    public List<SubspecialtyType> Subspecialties { get; set; }

    public QuestionTier QuestionsTier { get; set; }

    public TestingMode TestingMode { get; set; }

    [Optional]
    public string TestName { get; set; }

    public static IForm<TestRequest> BuildForm()
    {
        return new FormBuilder<TestRequest>()
            .Message("Which test would you like to pass?")
            .Build();
    }
}

public enum QuestionTier
{
    All = 1,

    Free = 2,

    VirtualCurriculum = 3
}

public enum TestingMode
{
    VEQTRPracticeMode = 1,

    VEQTRLearningMode = 2,

    TestingMode = 3
}

public enum SubspecialtyType
{
    All = 100,

    /// <summary>
    /// Trauma Orthopaedics subspecialty.
    /// </summary>
    Trauma = 1,

    /// <summary>
    /// Spine Orthopaedics subspecialty.
    /// </summary>
    Spine = 2,

    /// <summary>
    /// Sports Orthopaedics subspecialty.
    /// </summary>
    Sports = 3,

    /// <summary>
    /// Pediatrics Orthopaedics subspecialty.
    /// </summary>
    Pediatrics = 4,

    /// <summary>
    /// Recon Orthopaedics subspecialty.
    /// </summary>
    Recon = 5,

    /// <summary>
    /// Hand Orthopaedics subspecialty.
    /// </summary>
    Hand = 6,

    /// <summary>
    /// Foot / Ankle Orthopaedics subspecialty.
    /// </summary>
    FootAndAnkle = 7,

    /// <summary>
    /// Pathology Orthopaedics subspecialty.
    /// </summary>
    Pathology = 8,

    /// <summary>
    /// Basic Science Orthopaedics subspecialty.
    /// </summary>
    BasicScience = 9,

    /// <summary>
    /// Anatomy Orthopaedics subspecialty.
    /// </summary>
    Anatomy = 10,

    /// <summary>
    /// Approaches Orthopaedics subspecialty.
    /// </summary>
    Approaches = 12,

    /// <summary>
    /// General Orthopaedics subspecialty (no particular subspecialty).
    /// </summary>
    General = 13
}