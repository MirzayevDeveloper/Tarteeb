﻿//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//=================================

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Tarteeb.Api.Models.Foundations.Milestones;
using Tarteeb.Api.Models.Foundations.Users;

namespace Tarteeb.Api.Models.Foundations.Tickets
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public TicketStatus Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public Guid? AssigneeId { get; set; }
        [NotMapped]
        public User Assignee { get; set; }

        public Guid CreatedUserId { get; set; }
        [NotMapped]
        public User CreatedUser { get; set; }

        public Guid UpdatedUserId { get; set; }
        [JsonIgnore]
        public User UpdatedUser { get; set; }

        public Guid MilestoneId { get; set; }
        [NotMapped]
        public Milestone Milestone { get; set; }
    }
}