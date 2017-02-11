using System.Collections.Generic;

namespace Cake.Apprenda
{
    ///// <summary>
    ///// Provides functionality for constructing ACS commands
    ///// </summary>
    //public sealed class ACSCommandBuilder
    //{
    //    /// <summary>
    //    /// Builds the command to read all registered clouds
    //    /// </summary>
    //    /// <returns></returns>
    //    public ReadRegisteredCloudsCommand ReadRegisteredClouds()
    //    {
    //        return new ReadRegisteredCloudsCommand();
    //    }
    //}

    ///// <summary>
    ///// Represents an ACS command that returns a result
    ///// </summary>
    //public interface IACSCommand<out TResult> : IACSCommand
    //{
    //    /// <summary>
    //    /// Parses standard out to return result object
    //    /// </summary>
    //    TResult ParseResults(IEnumerable<string> standardOutput);
    //}

    ///// <summary>
    ///// Represents an ACS command
    ///// </summary>
    ///// <seealso cref="IACSCommand" />
    //public interface IACSCommand
    //{
    //    /// <summary>
    //    /// Gets the name of the command.
    //    /// </summary>
    //    string CommandName { get; }
    //}

    ///// <summary>
    ///// Provides base functionality for ACS commands.
    ///// </summary>
    //public abstract class ACSCommandBase<TResult> : IACSCommand<TResult>
    //{
    //    /// <inheritdoc />
    //    public abstract string CommandName { get; }

    //    /// <inheritdoc />
    //    public abstract TResult ParseResults(IEnumerable<string> standardOutput);
    //}
}
