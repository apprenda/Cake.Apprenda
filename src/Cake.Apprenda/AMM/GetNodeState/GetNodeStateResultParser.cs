using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Cake.Core;

namespace Cake.Apprenda.AMM.GetNodeState
{
    internal sealed class GetNodeStateResultParser
    {
        private static readonly Regex _successExpression = new Regex("^The node state of .*? is (?<state>.*?)\\.", RegexOptions.IgnoreCase);
        private static readonly Regex _expectedErrorExpression = new Regex("^An error occurred while executing the command '.*?'\\.(?<error>.*?)$");

        public NodeState Parse(IEnumerable<string> standardOut)
        {
            var output = string.Join(" ", standardOut ?? Enumerable.Empty<string>()).Trim();
            var match = _successExpression.Match(output);

            NodeState result;
            if (match.Success && match.Groups["state"]?.Success == true && Enum.TryParse(match.Groups["state"].Value, true, out result))
            {
                return result;
            }

            match = _expectedErrorExpression.Match(output);
            if (match.Success && match.Groups["error"]?.Success == true)
            {
                throw new CakeException($"An error occured while executing command: {match.Groups["error"].Value.Trim()}");
            }

            throw new CakeException($"Unable to parse response. Raw response was: {output}");
        }
    }
}