

// <summary>
// Implementation of output styling services.
class OutputService : IOutputService
{
    // Method to style output
    #region Methods
    // <inheritdoc/>
    // Styles the output by printing a decorative line
    public void StyleOutput()
    {
        Console.WriteLine("#####################################");
    }
    #endregion
}