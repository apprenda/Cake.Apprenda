using System;

namespace Cake.Apprenda.Tests.ACS
{
    /// <summary>
    /// Provides base support for exercising aspects of a given <see cref="TSettings"/> type
    /// </summary>
    /// <typeparam name="TSettings">The type of the settings.</typeparam>
    public abstract class ACSSettingsTestsBase<TSettings> where TSettings : ACSSettings
    {
        /// <summary>
        /// Provides a fluent extension point for asserting behavior from a particular constructor
        /// </summary>
        /// <param name="ctor">The factory delegate used for creating a <see cref="TSettings"/> instance</param>
        /// <returns></returns>
        protected Action Constructor(Func<TSettings> ctor)
        {
            // ReSharper disable once NotAccessedVariable
            TSettings settings;
            Action result = () => settings = ctor();

            return result;
        }
    }
}