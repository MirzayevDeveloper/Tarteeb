//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//=================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarteeb.Api.Models.Foundations.Tickets;

namespace Tarteeb.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public void ConfigureTicketDeleteBehavior(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(ticket => ticket.MilestoneId)
                .IsRequired(false);

            builder.Property(user => user.MilestoneId)
            .IsRequired(false);

            builder.HasOne(t => t.Assignee)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.AssigneeId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.Milestone)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.MilestoneId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
