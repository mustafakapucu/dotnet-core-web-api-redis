using System;

namespace simple_redis_api_on_docker.Models
{
    public class TestModel
    {
        public TestModel()
        {

        }

        public TestModel(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
