﻿//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//=================================

using Xeptions;

namespace Tarteeb.Api.Models.Processings.Users
{
    public class UserProcessingDependencyValidationException : Xeption
    {
        public UserProcessingDependencyValidationException(Xeption innerException)
            : base(message: "User dependency validation error occurred, fix the errors and try again", innerException)
        { }
    }
}
