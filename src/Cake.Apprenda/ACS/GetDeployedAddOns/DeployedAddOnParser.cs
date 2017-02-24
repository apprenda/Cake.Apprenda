using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cake.Apprenda.ACS.GetDeployedAddOns
{
    /// <summary>
    /// Provides support for parsing the stdout from a <see cref="GetDeployedAddOns"/> command
    /// </summary>
    /// <seealso cref="GetAddOns"/>
    internal sealed class DeployedAddOnParser
    {
        /// <summary>
        /// Parses results from standard output
        /// </summary>
        /// <param name="standardOutput"></param>
        /// <returns></returns>
        public IEnumerable<DeployedAddOnInfo> ParseResults(IEnumerable<string> standardOutput)
        {
            if (standardOutput == null)
            {
                throw new ArgumentNullException(nameof(standardOutput));
            }

            var allLines = standardOutput.ToList();

            // empty collection or any line contains the "no addons" line, bail
            if (allLines.Count < 1 || allLines.Any(s => s != null && s.Contains("No deployed add-ons found")))
            {
                yield break;
            }

            // if we're this far, find the lines to skip.
            var startAfter = allLines.FindIndex(x => x != null && x.Trim().Equals("Deployed add-ons:", StringComparison.OrdinalIgnoreCase));
            if (startAfter > -1)
            {
                allLines = allLines.Skip(startAfter + 1).ToList();
            }

            // pattern match the token we'll use to create a new instance.  in this case, because of the bug with the line having only a colon, 
            // we have to double-dip on the "Alias:" line.
            var addOnIdentifierExpr = new Regex("^Alias: .*?$", RegexOptions.IgnoreCase);

            DeployedAddOnInfo current = null;
            foreach (var line in allLines)
            {
                // junk line, just move on
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                // TODO: if the bug with the line containing _only_ a colon is fixed, this condition can be mutated.
                if (string.Equals(line.Trim(), ":", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // clean up the line and attempt to match it.
                if (addOnIdentifierExpr.IsMatch(line.Trim()))
                {
                    // are we at a new one? return the last one.
                    if (current != null)
                    {
                        yield return current;
                    }

                    // new one; we'll populate it below.
                    current = new DeployedAddOnInfo();
                }

                // set the properties.  this isn't terribly efficient, but oh well.
                Expressions.Mutate(line, current);
            }

            // handle the last one
            if (current != null)
            {
                yield return current;
            }
        }

        private static class Expressions
        {
            private static readonly Regex _alias = new Regex("^Alias: (.*)");
            private static readonly Regex _instanceAlias = new Regex("Instance Alias: (.*)");
            private static readonly Regex _author = new Regex("Author: (.*)");
            private static readonly Regex _vendor = new Regex("Vendor: (.*)");
            private static readonly Regex _connectionData = new Regex("Connection Data: (.*)");
            private static readonly Regex _deploymentTime = new Regex("Deploy Time: (.*)");

            public static void Mutate(string line, DeployedAddOnInfo deployedAddOnInfo)
            {
                if (string.IsNullOrEmpty(line))
                {
                    throw new ArgumentException("Value cannot be null or empty.", nameof(line));
                }

                if (deployedAddOnInfo == null)
                {
                    throw new ArgumentNullException(nameof(deployedAddOnInfo));
                }

                line = line.Trim();

                Match match = null;

                if ((match = _alias.Match(line)).Success)
                {
                    deployedAddOnInfo.Alias = match.Groups[1].Value;
                }

                if ((match = _instanceAlias.Match(line)).Success)
                {
                    deployedAddOnInfo.InstanceAlias = match.Groups[1].Value;
                }

                if ((match = _author.Match(line)).Success)
                {
                    deployedAddOnInfo.Author = match.Groups[1].Value;
                }

                if ((match = _vendor.Match(line)).Success)
                {
                    deployedAddOnInfo.Vendor = match.Groups[1].Value;
                }

                if ((match = _connectionData.Match(line)).Success)
                {
                    deployedAddOnInfo.ConnectionData = match.Groups[1].Value;
                }

                if ((match = _deploymentTime.Match(line)).Success)
                {
                    deployedAddOnInfo.DeploymentTime = match.Groups[1].Value;
                }
            }
        }
    }
}
