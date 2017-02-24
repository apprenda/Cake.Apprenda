using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cake.Apprenda.ACS.GetAddOns
{
    /// <summary>
    /// Provides support for parsing the stdout from a <see cref="GetAddOns"/> command
    /// </summary>
    /// <seealso cref="GetAddOns"/>
    internal sealed class AddOnParser
    {
        /// <summary>
        /// Parses results from standard output
        /// </summary>
        /// <param name="standardOutput"></param>
        /// <returns></returns>
        public IEnumerable<AddOnInfo> ParseResults(IEnumerable<string> standardOutput)
        {
            if (standardOutput == null)
            {
                throw new ArgumentNullException(nameof(standardOutput));
            }
            
            var allLines = standardOutput.ToList();

            // empty collection or any line contains the "no addons" line, bail
            if(allLines.Count < 1 || allLines.Any(s => s != null && s.Contains("No add-ons found")))
            {
                yield break;
            }

            // if we're this far, find the lines to skip.
            var startAfter = allLines.FindIndex(x => x != null && x.Trim().Equals("Add-ons:", StringComparison.OrdinalIgnoreCase));
            if (startAfter > -1)
            {
                allLines = allLines.Skip(startAfter + 1).ToList();
            }

            // pattern match the addOn name identifier.
            var addOnIdentifierExpr = new Regex("^.*?:$", RegexOptions.IgnoreCase);

            AddOnInfo current = null;
            foreach (var line in allLines)
            {
                // junk line, just move on
                if (string.IsNullOrEmpty(line))
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

                    // new one
                    current = new AddOnInfo { Name = line.TrimEnd(':') };
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
            private static readonly Regex _alias = new Regex("Alias: (.*)");
            private static readonly Regex _author = new Regex("Author: (.*)");
            private static readonly Regex _vendor = new Regex("Vendor: (.*)");
            private static readonly Regex _description = new Regex("Description: (.*)");
            private static readonly Regex _allowsParameters = new Regex("Allows Arbitrary Parameters: (.*)");
            private static readonly Regex _help = new Regex("Help: (.*)");

            public static void Mutate(string line, AddOnInfo addOnInfo)
            {
                if (string.IsNullOrEmpty(line))
                {
                    throw new ArgumentException("Value cannot be null or empty.", nameof(line));
                }

                if (addOnInfo == null)
                {
                    throw new ArgumentNullException(nameof(addOnInfo));
                }

                line = line.Trim();

                Match match = null;

                if ((match = _alias.Match(line)).Success)
                {
                    addOnInfo.Alias = match.Groups[1].Value;
                }

                if ((match = _author.Match(line)).Success)
                {
                    addOnInfo.Author = match.Groups[1].Value;
                }

                if ((match = _vendor.Match(line)).Success)
                {
                    addOnInfo.Vendor = match.Groups[1].Value;
                }

                if ((match = _description.Match(line)).Success)
                {
                    addOnInfo.Description = match.Groups[1].Value;
                }

                if ((match = _allowsParameters.Match(line)).Success)
                {
                    addOnInfo.AllowsArbitraryParameters = string.Equals(match.Groups[1].Value, "True", StringComparison.OrdinalIgnoreCase);
                }

                if ((match = _help.Match(line)).Success)
                {
                    addOnInfo.HelpText = match.Groups[1].Value;
                }
            }
        }
    }
}