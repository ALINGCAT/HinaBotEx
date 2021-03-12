using System;

namespace OneBot.FrameworkDemo.Models.Entities
{
    public interface IUpdateTimeStampedModel
    {
        DateTime UpdatedAt { get; set; }
    }
}
