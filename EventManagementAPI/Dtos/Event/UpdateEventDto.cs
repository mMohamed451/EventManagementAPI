﻿using System;

namespace EventManagementApi.Dtos
{
    public class UpdateEventDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
