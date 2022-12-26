namespace ASE_Assignment
{
    /// <summary>
    /// A class that signifies the end of a loop command code block.
    /// </summary>
    public class EndWhile : Command
    {
        public EndWhile(List<string> parameters)
        {
            Parameters = parameters;
        }

        public override void VerifyParameters()
        {
            if (Parameters.Count != 0)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }
        }

        public override void Operation()
        {
            return;
        }
    }
}