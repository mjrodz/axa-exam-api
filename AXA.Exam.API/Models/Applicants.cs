using System;
using System.Collections.Generic;

namespace AXA.Exam.API.Models
{
    public class Applicants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string PositionApplied { get; set; }
        public string Source { get; set; }
        public string XaxaApiKey { get; set; }
    }
}
