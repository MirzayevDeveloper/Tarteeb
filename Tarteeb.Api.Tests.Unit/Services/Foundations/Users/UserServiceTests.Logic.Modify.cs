﻿//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//=================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using System;
using System.Threading.Tasks;
using Tarteeb.Api.Models;
using Xunit;

namespace Tarteeb.Api.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldModifyUserAsync()
        {
            //given
            DateTimeOffset randomDate = GetRandomDateTimeOffset();
            User randomUser = CreateRandomModifyUser(randomDate);
            User inputUser = randomUser;
            User storageUser = inputUser.DeepClone();
            storageUser.UpdatedDate = randomUser.CreatedDate;
            User updatedUser = inputUser;
            User exceptedUser = updatedUser.DeepClone();
            Guid userId = inputUser.Id;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectUserByIdAsync(userId))
                    .ReturnsAsync(storageUser);

            this.storageBrokerMock.Setup(broker =>
               broker.UpdateUserAsync(inputUser))
                   .ReturnsAsync(updatedUser);

            //when
            User actualUser =
                await this.userService.ModifyUserAsync(inputUser);

            //then
            actualUser.Should().BeEquivalentTo(exceptedUser);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectUserByIdAsync(userId),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateUserAsync(inputUser),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}