using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;

namespace EventManagementProject.Repositories
{
    public class EventRepository :Repository<int,Event>,IEventRepository
    {

        public EventRepository(EventManagementContext context) : base(context) { }
    }
}
