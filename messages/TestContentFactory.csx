using System;

public class TestContentFactory
{
    private readonly TestRequest request;

    public TestContentFactory(TestRequest request)
    {
        this.request = request;
    }

    public TestContent Create()
    {
        return null;
    }
}