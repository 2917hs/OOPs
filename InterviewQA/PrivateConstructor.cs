using System;
namespace InterviewQA
{
    public sealed class PrivateConstructor
    {
        private int age;

        public string name = string.Empty;

        public PrivateConstructor()
        {
        }

        private PrivateConstructor(int age, string name)
        {
            this.age = age;
            this.name = name;
        }
    }
}

