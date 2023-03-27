﻿//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//=================================

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarteeb.Api.Models.Foundations.Scores;

namespace Tarteeb.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        DbSet<Score> Scores { get; set; }

        public async ValueTask<Score> UpdateSocreAsync(Score score)=>
            await UpdateAsync(score);

        public async ValueTask<Score> DeleteScoreAsync(Score score) =>
            await DeleteAsync(score);
    }
}
