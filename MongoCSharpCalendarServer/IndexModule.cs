namespace MongoCSharpCalendarServer
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return Response.AsRedirect("http://localhost/mongo-calendar-app-web");
            };
        }
    }
}