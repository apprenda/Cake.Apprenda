﻿using System;
using Cake.Core;

// ReSharper disable once CheckNamespace
namespace Xunit
{
    public partial class Assert
    {
        public static void IsArgumentNullException(Exception exception, string parameterName)
        {
            IsType<ArgumentNullException>(exception);
            Equal(parameterName, ((ArgumentNullException)exception).ParamName);
        }

        public static void IsArgumentException(Exception exception, string parameterName, string message)
        {
            IsType<ArgumentException>(exception);
            Equal(parameterName, ((ArgumentException)exception).ParamName);
            Equal(new ArgumentException(message, parameterName).Message, exception.Message);
        }

        public static void IsArgumentException(Exception exception, string parameterName)
        {
            IsType<ArgumentException>(exception);
            Equal(parameterName, ((ArgumentException)exception).ParamName);
        }

        public static void IsCakeException(Exception exception, string message)
        {
            IsExceptionWithMessage<CakeException>(exception, message);
        }

        public static void IsCakeExceptionWithMessage(Exception exception, Func<string, bool> match)
        {
            IsType<CakeException>(exception);
            True(match(exception.Message));
        }

        public static void IsExceptionWithMessage<T>(Exception exception, string message)
            where T : Exception
        {
            IsType<T>(exception);
            Equal(message, exception.Message);
        }
    }
}
