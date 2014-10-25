namespace MongoCSharpCalendarServer
{
    using MongoDB.Driver;
    using Nancy;
    using Nancy.Bootstrapper;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(context =>
            {
                context.Response.WithHeader("Access-Control-Allow-Origin", "*")
                                .WithHeader("Access-Control-Allow-Methods", "POST,GET,PUT,DELETE")
                                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
            });

            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("calendar");

            container.Register<MongoDatabase>(database);

            base.ApplicationStartup(container, pipelines);
        }
    }
}