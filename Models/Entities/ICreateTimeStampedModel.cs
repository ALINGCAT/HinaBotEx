using System;

namespace OneBot.FrameworkDemo.Models.Entities
{
    public interface ICreateTimeStampedModel
    {
        DateTime CreatedAt { get; set; }
    }
}