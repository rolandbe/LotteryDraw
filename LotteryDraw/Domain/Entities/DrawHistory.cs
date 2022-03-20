using System;

namespace Domain.Entities
{
    public class DrawHistory : Base
    {
        public string Numbers { get; set; }
        public DateTimeOffset DrawnAt { get; set; }
    }
}