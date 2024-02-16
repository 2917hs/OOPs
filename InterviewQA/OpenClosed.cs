namespace InterviewQA
{
    public class OpenClosed
    {
        public ParentInterface ParentInterface { get; }
        public OpenClosed(ParentInterface parentInterface)
        {
            this.ParentInterface = parentInterface;

            string name = parentInterface.DoesExist();

            System.Console.WriteLine(name);
        }
    }

    public interface ParentInterface
    {
        public string DoesExist();
    }

    public class Child1 : ParentInterface
    {
        public string DoesExist()
        {
            return nameof(Child1);
        }
    }

    public class Child2 : ParentInterface
    {
        public string DoesExist()
        {
            return nameof(Child2);
        }
    }

    public class Child3 : ParentInterface
    {
        public string DoesExist()
        {
            return nameof(Child2);
        }
    }
}